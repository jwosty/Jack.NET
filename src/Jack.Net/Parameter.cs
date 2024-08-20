using System;
using System.Buffers;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Jack.Net.Interop;
using JetBrains.Annotations;
using ArgumentException = System.ArgumentException;
using P = Jack.Net.Interop.JackCtl.Parameter;

namespace Jack.Net;

public interface IParamEnumConstraint<out T>
{
    public string? Description { get; }
    public T Value { get; }
}

public readonly record struct ParamEnumConstraint<T>(string? Description, T Value) : IParamEnumConstraint<T>;

public interface IParameter
{
    public unsafe jackctl_parameter* Handle { get; }
    public string? Name { get; }
    public string? ShortDescription { get; }
    public string? LongDescription { get; }
    public jackctl_param_type_t ParameterType { get; }
    public byte Id { get; }
    public bool IsSet { get; }
    public bool ConstraintIsStrict { get; }
    public bool ConstraintIsFakeValue { get; }
    public bool Reset();
    public object? BoxedValue { get; }
    public bool HasRangeConstraint();
    public bool HasEnumConstraint();
}

public interface IParameter<out T> : IParameter
{
    public T Value { get; }
    public T DefaultValue { get; }
    public IReadOnlyList<IParamEnumConstraint<T>> EnumConstraints { get; }
    public T RangeConstraintMinValue { get; }
    public T RangeConstraintMaxValue { get; }
}

public interface IMutableParameter<T> : IParameter<T>
{
    public new T Value { get; set; }
}

public abstract unsafe class Parameter : IParameter
{
    public jackctl_parameter* Handle { get; }

    protected Parameter(jackctl_parameter* handle)
    {
        this.Handle = handle;
    }

    private string? _name;
    public string? Name => this._name ??= P.GetName(this.Handle);

    private string? _shortDescription;
    public string? ShortDescription => this._shortDescription ??= P.GetShortDescription(this.Handle);

    private string? _longDescription;
    public string? LongDescription => this._longDescription ??= P.GetLongDescription(this.Handle);

    private jackctl_param_type_t? _parameterType;
    public jackctl_param_type_t ParameterType => this._parameterType ??= P.GetParameterType(this.Handle);

    public static IParameter FromHandle(jackctl_parameter* paramPtr)
    {
        var pType = P.GetParameterType(paramPtr);
        return pType switch
        {
            jackctl_param_type_t.JackParamInt => new Parameter<int>(paramPtr, ParameterMarshaller.Int),
            jackctl_param_type_t.JackParamUInt => new Parameter<uint>(paramPtr, ParameterMarshaller.UInt),
            jackctl_param_type_t.JackParamChar => new Parameter<char>(paramPtr, ParameterMarshaller.Char),
            jackctl_param_type_t.JackParamBool => new Parameter<bool>(paramPtr, ParameterMarshaller.Bool),
            jackctl_param_type_t.JackParamString => new Parameter<string?>(paramPtr, ParameterMarshaller.String),
            _ => throw new InvalidOperationException($"Unknown parameter type: {Enum.GetName(pType)}")
        };
    }

    public static Parameter<T> FromHandle<T>(jackctl_parameter* paramPtr)
    {
        var pType = P.GetParameterType(paramPtr);
        var tType = typeof(T);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void ThrowIfNotParamType(jackctl_param_type_t expectedParamType)
        {
            if (pType != expectedParamType)
            {
                throw new ArgumentException($"Cannot convert native parameter type '{Enum.GetName(pType)}' tType");
            }
        }

        if (tType == typeof(int))
        {
            ThrowIfNotParamType(jackctl_param_type_t.JackParamInt);
            return (Parameter<T>)(Parameter)new Parameter<int>(paramPtr, ParameterMarshaller.Int);
        }
        else if (tType == typeof(uint))
        {
            ThrowIfNotParamType(jackctl_param_type_t.JackParamUInt);
            return (Parameter<T>)(Parameter)new Parameter<uint>(paramPtr, ParameterMarshaller.UInt);
        }
        else if (tType == typeof(char))
        {
            ThrowIfNotParamType(jackctl_param_type_t.JackParamChar);
            return (Parameter<T>)(Parameter)new Parameter<char>(paramPtr, ParameterMarshaller.Char);
        }
        else if (tType == typeof(bool))
        {
            ThrowIfNotParamType(jackctl_param_type_t.JackParamBool);
            return (Parameter<T>)(Parameter)new Parameter<bool>(paramPtr, ParameterMarshaller.Bool);
        }
        else if (tType == typeof(string))
        {
            ThrowIfNotParamType(jackctl_param_type_t.JackParamChar);
            return (Parameter<T>)(Parameter)new Parameter<string?>(paramPtr, ParameterMarshaller.String);
        }
        else
        {
            throw new ArgumentException($"Invalid parameter type: {tType.Name}");
        }
        // return pType switch
        // {
        //     jackctl_param_type_t.JackParamInt => new Parameter<int>(paramPtr, ParameterMarshaller.Int),
        //     jackctl_param_type_t.JackParamUInt => new Parameter<uint>(paramPtr, ParameterMarshaller.Uint),
        //     jackctl_param_type_t.JackParamChar => new Parameter<byte>(paramPtr, ParameterMarshaller.Byte),
        //     jackctl_param_type_t.JackParamBool => new Parameter<bool>(paramPtr, ParameterMarshaller.Bool),
        //     jackctl_param_type_t.JackParamString => new Parameter<string>(paramPtr, ParameterMarshaller.String),
        //     _ => throw new InvalidOperationException($"Unknown parameter type: {Enum.GetName(pType)}")
        // };
    }

    public byte Id => P.GetId(this.Handle);
    public bool IsSet => P.IsSet(this.Handle);
    public bool Reset() => P.Reset(this.Handle);
    public abstract object? BoxedValue { get; }
    public bool HasRangeConstraint() => P.HasRangeConstraint(this.Handle);
    public bool HasEnumConstraint() => P.HasEnumConstraint(this.Handle);
    public bool ConstraintIsStrict => P.ConstraintIsStrict(this.Handle);
    public bool ConstraintIsFakeValue => P.ConstraintIsFakeValue(this.Handle);
}

public interface IParameterMarshaller<T>
{
    public T UnmanagedToManaged(jackctl_parameter_value value);
    public jackctl_parameter_value ManagedToUnmanaged(T value);
}

internal static class ParameterMarshaller
{
    public static IntMarshaller Int { get; } = new IntMarshaller();
    public static UIntMarshaller UInt { get; } = new UIntMarshaller();
    public static CharMarshaller Char { get; } = new CharMarshaller();
    public static BoolMarshaller Bool { get; } = new BoolMarshaller();
    public static StringMarshaller String { get; } = new StringMarshaller();
}

internal sealed class IntMarshaller : IParameterMarshaller<int>
{
    public int UnmanagedToManaged(jackctl_parameter_value value) => value.i;

    public jackctl_parameter_value ManagedToUnmanaged(int value) =>
        new jackctl_parameter_value { i = value};
}

internal sealed class UIntMarshaller : IParameterMarshaller<uint>
{
    public uint UnmanagedToManaged(jackctl_parameter_value value) => value.ui;

    public jackctl_parameter_value ManagedToUnmanaged(uint value) =>
        new jackctl_parameter_value { ui = value};
}

internal sealed class CharMarshaller : IParameterMarshaller<char>
{
    public char UnmanagedToManaged(jackctl_parameter_value value) => (char)value.c;

    public jackctl_parameter_value ManagedToUnmanaged(char value) =>
        new jackctl_parameter_value { c = (byte)value};
}

internal sealed class BoolMarshaller : IParameterMarshaller<bool>
{
    public bool UnmanagedToManaged(jackctl_parameter_value value) => value.b != 0;

    public jackctl_parameter_value ManagedToUnmanaged(bool value) =>
        new jackctl_parameter_value { b = value ? (byte)1 : (byte)0};
}


internal sealed unsafe class StringMarshaller : IParameterMarshaller<string?>
{
    public string? UnmanagedToManaged(jackctl_parameter_value value)
    {
        byte* strPtr = &value.str.e0;
        return Marshal.PtrToStringUTF8((nint)strPtr);
    }

    public jackctl_parameter_value ManagedToUnmanaged(string? value)
    {
        // var theStruct = new jackctl_parameter_value { str = (byte*)Marshal.StringToCoTaskMemUTF8(value) };
        // var valStruct = new jackctl_parameter_value();
        // var x = new Span<byte>(valStruct.str, (nint)value.Length);
        // var y = new StringParameterValueOwner(valStruct);
        throw new NotImplementedException();
    }
}

internal sealed unsafe class ParamEnumConstraintCollection<T> : IReadOnlyList<IParamEnumConstraint<T>>
{
    private readonly Parameter _parameter;
    private readonly IParameterMarshaller<T> _marshaller;

    internal ParamEnumConstraintCollection(Parameter parameter, IParameterMarshaller<T> marshaller)
    {
        this._parameter = parameter;
        this._marshaller = marshaller;
    }

    public int Count => (int)P.EnumConstraintsCount(this._parameter.Handle);
    private ParamEnumConstraint<T> UnsafeGetItem(int index)
    {
        var description = P.EnumConstraintDescription(this._parameter.Handle, (uint)index);
        var valueStruct = P.EnumConstraintValue(this._parameter.Handle, (uint)index);
        var value = this._marshaller.UnmanagedToManaged(valueStruct);
        return new ParamEnumConstraint<T>(description, value);
    }

    public IParamEnumConstraint<T> this[int index] =>
        index < 0 || index >= this.Count
            ? throw new IndexOutOfRangeException("Index was outside the bounds of the collection.")
            : this.UnsafeGetItem(index);

    public IEnumerator<IParamEnumConstraint<T>> GetEnumerator()
    {
        for (int i = 0; i < this.Count; i++)
        {
            yield return this[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}


public sealed unsafe class Parameter<T> : Parameter, IParameter<T>, IMutableParameter<T>
{
    private readonly IParameterMarshaller<T> _marshaller;

    internal Parameter(jackctl_parameter* handle, IParameterMarshaller<T> marshaller) : base(handle)
    {
        this._marshaller = marshaller;
    }

    public override string ToString()
    {
        return $"{this.Name} = {this.Value}";
    }

    public T Value
    {
        get => this._marshaller.UnmanagedToManaged(P.GetValue(this.Handle));
        set
        {
            var valStruct = this._marshaller.ManagedToUnmanaged(value);
            P.SetValue(this.Handle, valStruct);
        }
    }

    public T DefaultValue => this._marshaller.UnmanagedToManaged(P.GetDefaultValue(this.Handle));

    public IReadOnlyList<IParamEnumConstraint<T>> EnumConstraints =>
        new ParamEnumConstraintCollection<T>(this, this._marshaller);

    public T RangeConstraintMinValue
    {
        get
        {
            P.GetRangeConstraint(this.Handle, out var minValue, out _);
            return this._marshaller.UnmanagedToManaged(minValue);
        }
    }

    public T RangeConstraintMaxValue
    {
        get
        {
            P.GetRangeConstraint(this.Handle, out _, out var maxValue);
            return this._marshaller.UnmanagedToManaged(maxValue);
        }
    }

    public override object? BoxedValue => this.Value;
}
