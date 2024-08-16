namespace Jack.Net;
using System;
using Jack.Net.Interop;
using JetBrains.Annotations;

[PublicAPI]
public unsafe class Client(_jack_client* handle) : IDisposable
{
    public _jack_client* Handle { get; private set; } = handle;

    public static Client Open(string name, JackOptions options, out JackStatus status, string? serverName = null)
    {
        var clientPtr = serverName is null
            ? Jack.ClientOpen(name, options, out status)
            : Jack.ClientOpen(name, options, out status, serverName);
        if (clientPtr is null)
        {
            throw new JackStatusException("Failed to open client", status);
        }

        return new Client(clientPtr);
    }

    public void Close()
    {
        if (this.Handle is not null)
        {
            InteropHelpers.CheckResult("Could not close client", Jack.ClientClose(this.Handle));
        }
    }

    public static int MaxNameLength => jack.client_name_size();

    public bool TryClose() =>
        this.Handle is not null && InteropHelpers.IsSuccess(Jack.ClientClose(this.Handle));

    public void Activate() =>
        InteropHelpers.CheckResult("Could not activate client", Jack.Activate(this.Handle));

    public bool TryActivate() =>
        InteropHelpers.IsSuccess(Jack.Activate(this.Handle));

    public void Deactivate() =>
        InteropHelpers.CheckResult("Could not deactivate client", Jack.Deactivate(this.Handle));

    public bool TryDeactivate() =>
        InteropHelpers.IsSuccess(Jack.Deactivate(this.Handle));

    public string? Name => Jack.GetClientName(this.Handle);

    public Guid? GetUuidForClientName(string clientName)
    {
        var uuidStr = Jack.GetUuidForClientName(this.Handle, clientName);
        return uuidStr is null ? null : Guid.Parse(uuidStr);
    }

    public string? GetClientNameByUuid(Guid clientId) =>
        Jack.GetClientNameByUuid(this.Handle, clientId.ToString());

    public uint ThreadId => (uint)Jack.ClientThreadId(this.Handle);

    private void ReleaseUnmanagedResources()
    {
        this.Close();
    }

    protected virtual void Dispose(bool disposing)
    {
        this.ReleaseUnmanagedResources();
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

    ~Client()
    {
        this.Dispose(false);
    }
}
