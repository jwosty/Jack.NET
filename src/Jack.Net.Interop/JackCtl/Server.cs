using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace Jack.Net.Interop.JackCtl;

[PublicAPI]
public static unsafe class Server
{
    // TODO: callbacks
    public static jackctl_server* Create(delegate* unmanaged[Cdecl]<byte*, byte> onDeviceAcquire,
        delegate* unmanaged[Cdecl]<byte*, void> onDeviceRelease) =>
        jackctl.server_create(onDeviceAcquire, onDeviceRelease);

    public delegate byte DeviceAcquireHandler(byte* deviceName);
    public delegate void DeviceReleaseHandler(byte* deviceName);

    public static jackctl_server* Create(DeviceAcquireHandler? onDeviceAcquire, DeviceReleaseHandler? onDeviceRelease)
    {
        var onDeviceAcquirePtr = onDeviceAcquire is null ? default : Marshal.GetFunctionPointerForDelegate(onDeviceAcquire);
        var onDeviceReleasePtr = onDeviceRelease is null ? default : Marshal.GetFunctionPointerForDelegate(onDeviceRelease);
        return jackctl.server_create(
            (delegate* unmanaged[Cdecl]<byte*, byte>)onDeviceAcquirePtr,
            (delegate* unmanaged[Cdecl]<byte*, void>)onDeviceReleasePtr);
    }

    public static void Destroy(jackctl_server* server) => jackctl.server_destroy(server);

    public static bool Start(jackctl_server* server, jackctl_driver* driver) => jackctl.server_start(server, driver) != 0;

    public static bool Stop(jackctl_server* server) => jackctl.server_stop(server) != 0;

    public static IImmutableList<IntPtr<jackctl_driver>> GetDriversList(jackctl_server* server)
    {
        var driversRaw = jackctl.server_get_drivers_list(server);
        var drivers = ImmutableList.CreateBuilder<IntPtr<jackctl_driver>>();
        if (driversRaw is not null)
        {
            foreach (var driver in *driversRaw)
            {
                drivers.Add((jackctl_driver*)driver);
            }
        }
        return drivers.ToImmutable();
    }

    public static IImmutableList<IntPtr<jackctl_parameter>> GetParameters(jackctl_server* server)
    {
        var parametersRaw = jackctl.server_get_parameters(server);
        var parameters = ImmutableArray.CreateBuilder<IntPtr<jackctl_parameter>>();
        if (parametersRaw is not null)
        {
            foreach (var paramPtr in *parametersRaw)
            {
                parameters.Add((jackctl_parameter*)paramPtr);
            }
        }
        return parameters.ToImmutable();
    }
}
