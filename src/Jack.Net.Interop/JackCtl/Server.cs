using System.Collections.Generic;
using JetBrains.Annotations;

namespace Jack.Net.Interop.JackCtl;

[PublicAPI]
public static unsafe class Server
{
    // TODO: callbacks
    public static jackctl_server* Create() => jackctl.server_create(null, null);

    public static void Destroy(jackctl_server* server) => jackctl.server_destroy(server);

    public static IEnumerable<IntPtr<jackctl_driver>> GetDriversList(jackctl_server* server)
    {
        var driversRaw = jackctl.server_get_drivers_list(server);
        var drivers = new List<IntPtr<jackctl_driver>>();
        if (driversRaw is not null)
        {
            foreach (var driver in *driversRaw)
            {
                drivers.Add((jackctl_driver*)driver);
            }
        }
        return drivers;
    }
}
