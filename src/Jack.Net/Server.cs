using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Jack.Net.Interop;
using JetBrains.Annotations;
using S = Jack.Net.Interop.JackCtl.Server;

namespace Jack.Net;

[PublicAPI]
public unsafe class Server(jackctl_server* handle) : IDisposable
{
    public jackctl_server* Handle { get; private set; } = handle;

    [MustDisposeResource]
    public static Server Create() => new(S.Create());

    private IImmutableList<Driver>? _driversList;

    public IImmutableList<Driver> DriversList => this._driversList ??= this.GetDriversList();

    private ImmutableArray<Driver> GetDriversList() =>
        [
            ..S.GetDriversList(this.Handle)
                .Select(dPtr => new Driver(dPtr))
        ];


    private void Destroy() => S.Destroy(this.Handle);

    protected virtual void Dispose(bool disposing)
    {
        this.Destroy();
        if (disposing)
        {
            this.Handle = null;
        }
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~Server()
    {
        this.Dispose(false);
    }
}
