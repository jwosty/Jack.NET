using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.InteropServices;
using Jack.NET.Interop;
using JetBrains.Annotations;
using S = Jack.NET.Interop.JackCtl.Server;

namespace Jack.NET;

[PublicAPI]
public unsafe class Server(jackctl_server* handle) : IDisposable
{
    public jackctl_server* Handle { get; } = handle;

    private bool _disposed = false;

    // References held by native code that we need to keep alive
    // It appears that JACK sometimes still calls these callbacks after we call jackctl_server_destroy, so I guess we
    // keep them alive indefinitely...
    private static ConcurrentBag<GCHandle> _permanentNativeReferences = new();

    [MustDisposeResource]
    public static Server Create(Func<string?, bool>? onDeviceAcquire = null, Action<string?>? onDeviceRelease = null)
    {
        S.DeviceAcquireHandler? onDeviceAcquireRaw = null;
        if (onDeviceAcquire is not null)
        {
            onDeviceAcquireRaw = (byte* deviceNamePtr) =>
            {
                var result = onDeviceAcquire(Marshal.PtrToStringUTF8((nint)deviceNamePtr));
                return result ? (byte)1 : (byte)0;
            };
        }

        S.DeviceReleaseHandler? onDeviceReleaseRaw = null;
        if (onDeviceRelease is not null)
        {
            onDeviceReleaseRaw = (byte* deviceNamePtr) => onDeviceRelease(Marshal.PtrToStringUTF8((nint)deviceNamePtr));
        }
        var server = new Server(S.Create(onDeviceAcquireRaw, onDeviceReleaseRaw));
        server.TrackNativeReference(onDeviceAcquireRaw);
        server.TrackNativeReference(onDeviceReleaseRaw);
        return server;
    }

    // Keep track of a given object as a native reference, preventing it from being GC'd or moved during the lifetime
    // of the Server object
    private void TrackNativeReference(object? d)
    {
        if (d is not null)
        {
            var handle = GCHandle.Alloc(d);
            _permanentNativeReferences.Add(handle);
        }
    }

    private void TrackNativeReference(GCHandle handle) => _permanentNativeReferences.Add(handle);

    private IImmutableList<Driver>? _driversList;
    public IImmutableList<Driver> DriversList => this._driversList ??= this.GetDriversList();

    private ImmutableArray<Driver> GetDriversList() =>
        [..S.GetDriversList(this.Handle).Select(dPtr => new Driver(dPtr))];

    private IImmutableList<IParameter>? _parameters;
    public IImmutableList<IParameter> Parameters => this._parameters ??= this.GetParameters();

    private ImmutableArray<IParameter> GetParameters() =>
        [..S.GetParameters(this.Handle).Select(pPtr => Parameter.FromHandle(pPtr))];

    private void Destroy()
    {
        S.Destroy(this.Handle);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            this.Destroy();
            this._disposed = true;
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
