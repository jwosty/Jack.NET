using System;
using Jack.Net.Interop;
using JetBrains.Annotations;
using P = Jack.Net.Interop.JackCtl.Parameter;

namespace Jack.Net;

[PublicAPI]
public unsafe class Parameter(jackctl_parameter* handle)
{
    public jackctl_parameter* Handle { get; private set; } = handle;

    private string? _name;
    public string? Name => this._name ??= P.GetName(this.Handle);

    private string? _shortDescription;
    public string? ShortDescription => this._shortDescription ??= P.GetShortDescription(this.Handle);

    private string? _longDescription;
    public string? LongDescription => this._longDescription ??= P.GetLongDescription(this.Handle);

    public jackctl_param_type_t ParameterType => P.GetParameterType(this.Handle);

    public byte Id => P.GetId(this.Handle);

    public bool IsSet => P.IsSet(this.Handle);

    public bool Reset() => P.Reset(this.Handle);

    public jackctl_parameter_value Value => P.GetValue(this.Handle);
}
