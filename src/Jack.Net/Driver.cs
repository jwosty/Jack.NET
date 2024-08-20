using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using Jack.Net.Interop;
using JetBrains.Annotations;
using D = Jack.Net.Interop.JackCtl.Driver;

namespace Jack.Net;

[PublicAPI]
[DebuggerDisplay("Name = {Name}")]
public unsafe class Driver(jackctl_driver* handle)
{
    public jackctl_driver* Handle { get; private set; } = handle;

    private string? _name;
    public string? Name => this._name ??= D.GetName(this.Handle);

    private IImmutableList<IParameter>? _parameters;
    public IImmutableList<IParameter> Parameters => this._parameters ??= this.GetParameters();

    private ImmutableArray<IParameter> GetParameters() =>
        [
            ..D.GetParameters(this.Handle)
                .Select(pPtr => Parameter.FromHandle(pPtr))
        ];
}
