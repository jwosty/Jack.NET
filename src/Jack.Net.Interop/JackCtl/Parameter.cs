using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace Jack.Net.Interop.JackCtl;

[PublicAPI]
public static unsafe class Parameter
{
    public static string? GetName(jackctl_parameter* parameter)
    {
        var strPtr = jackctl.parameter_get_name(parameter);
        return strPtr is null ? null : Marshal.PtrToStringUTF8((IntPtr)strPtr);
    }

    public static string? GetShortDescription(jackctl_parameter* parameter)
    {
        var strPtr = jackctl.parameter_get_short_description(parameter);
        return strPtr is null ? null : Marshal.PtrToStringUTF8((IntPtr)strPtr);
    }

    public static string? GetLongDescription(jackctl_parameter* parameter)
    {
        var strPtr = jackctl.parameter_get_long_description(parameter);
        return strPtr is null ? null : Marshal.PtrToStringUTF8((IntPtr)strPtr);
    }

    public static jackctl_param_type_t GetParameterType(jackctl_parameter* parameter) =>
        jackctl.parameter_get_type(parameter);

    public static byte GetId(jackctl_parameter* parameter) => jackctl.parameter_get_id(parameter);

    public static bool IsSet(jackctl_parameter* parameter) => jackctl.parameter_is_set(parameter) != 0;

    public static bool Reset(jackctl_parameter* parameter) => jackctl.parameter_reset(parameter) != 0;

    public static jackctl_parameter_value GetValue(jackctl_parameter* parameter) =>
        jackctl.parameter_get_value(parameter);

    public static bool SetValue(jackctl_parameter* parameter, jackctl_parameter_value value) =>
        jackctl.parameter_set_value(parameter, &value) != 0;

    public static jackctl_parameter_value GetDefaultValue(jackctl_parameter* parameter) =>
        jackctl.parameter_get_default_value(parameter);

    public static bool HasRangeConstraint(jackctl_parameter* parameter) =>
        jackctl.parameter_has_range_constraint(parameter) != 0;

    public static bool HasEnumConstraint(jackctl_parameter* parameter) =>
        jackctl.parameter_has_enum_constraint(parameter) != 0;

    public static uint EnumConstraintsCount(jackctl_parameter* parameter) =>
        jackctl.parameter_get_enum_constraints_count(parameter);

    public static jackctl_parameter_value EnumConstraintValue(jackctl_parameter* parameter, uint index) =>
        jackctl.parameter_get_enum_constraint_value(parameter, index);

    public static string? EnumConstraintDescription(jackctl_parameter* parameter, uint index) =>
        Marshal.PtrToStringUTF8((IntPtr)jackctl.parameter_get_enum_constraint_description(parameter, index));

    public static void GetRangeConstraint(jackctl_parameter* parameter, out jackctl_parameter_value minValue,
        out jackctl_parameter_value maxValue)
    {
        fixed (jackctl_parameter_value* minValuePtr = &minValue)
        {
            fixed (jackctl_parameter_value* maxValuePtr = &maxValue)
            {
                jackctl.parameter_get_range_constraint(parameter, minValuePtr, maxValuePtr);
            }
        }
    }

    public static bool ConstraintIsStrict(jackctl_parameter* parameter) =>
        jackctl.parameter_constraint_is_strict(parameter) != 0;

    public static bool ConstraintIsFakeValue(jackctl_parameter* parameter) =>
        jackctl.parameter_constraint_is_fake_value(parameter) != 0;
}
