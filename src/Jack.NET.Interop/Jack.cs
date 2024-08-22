using System;
using System.Collections;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
// ReSharper disable InconsistentNaming

namespace Jack.NET.Interop;

[PublicAPI]
public static unsafe class Jack
{
    public static _jack_client* ClientOpen(ReadOnlySpan<byte> clientName, JackOptions options, out JackStatus status)
    {
        fixed (byte* clientNamePtr = clientName)
        {
            fixed (JackStatus* statusPtr = &status)
            {
                return jack.client_open(clientNamePtr, options, statusPtr, __arglist());
            }
        }
    }

    public static _jack_client* ClientOpen(string clientName, JackOptions options, out JackStatus status)
    {
        var clientNamePtr = (byte*)Marshal.StringToCoTaskMemUTF8(clientName);
        try
        {
            fixed (JackStatus* statusPtr = &status)
            {
                return jackdotnet_jack.client_open_0(clientNamePtr, options, statusPtr);
            }
        }
        finally
        {
            Marshal.ZeroFreeCoTaskMemUTF8((IntPtr)clientNamePtr);
        }
    }

    public static _jack_client* ClientOpen(ReadOnlySpan<byte> clientName, JackOptions options, out JackStatus status,
        ReadOnlySpan<byte> serverName)
    {
        fixed (byte* clientNamePtr = clientName)
        {
            fixed (JackStatus* statusPtr = &status)
            {
                fixed (byte* serverNamePtr = serverName)
                {
                    return jackdotnet_jack.client_open_1(clientNamePtr, options, statusPtr, serverNamePtr);
                }
            }
        }
    }

    public static _jack_client* ClientOpen(string clientName, JackOptions options, out JackStatus status,
        string serverName)
    {
        var clientNamePtr = (byte*)Marshal.StringToCoTaskMemUTF8(clientName);
        try
        {
            fixed (JackStatus* statusPtr = &status)
            {
                var serverNamePtr = (byte*)Marshal.StringToCoTaskMemUTF8(serverName);
                try
                {
                    return jackdotnet_jack.client_open_1(clientNamePtr, options, statusPtr, serverNamePtr);
                }
                finally
                {
                    Marshal.ZeroFreeCoTaskMemUTF8((IntPtr)serverNamePtr);
                }
            }
        }
        finally
        {
            Marshal.ZeroFreeCoTaskMemUTF8((IntPtr)clientNamePtr);
        }
    }

    public static int ClientClose(_jack_client* client) => jack.client_close(client);

    public static int ClientNameSize() => jack.client_name_size();

    public static string? GetClientName(_jack_client* client) =>
        Marshal.PtrToStringUTF8((IntPtr)jack.get_client_name(client));

    public static string? GetUuidForClientName(_jack_client* client, ReadOnlySpan<byte> name)
    {
        fixed (byte* namePtr = name)
        {
            return Marshal.PtrToStringUTF8((IntPtr)jack.get_uuid_for_client_name(client, namePtr));
        }
    }

    public static string? GetUuidForClientName(_jack_client* client, string name)
    {
        var namePtr = (byte*)Marshal.StringToCoTaskMemUTF8(name);
        try
        {
            return Marshal.PtrToStringUTF8((IntPtr)jack.get_uuid_for_client_name(client, namePtr));
        }
        finally
        {
            Marshal.ZeroFreeCoTaskMemUTF8((IntPtr)namePtr);
        }
    }

    public static string? GetClientNameByUuid(_jack_client* client, ReadOnlySpan<byte> uuid)
    {
        fixed (byte* uuidPtr = uuid)
        {
            return Marshal.PtrToStringUTF8((IntPtr)jack.get_client_name_by_uuid(client, uuidPtr));
        }
    }

    public static string? GetClientNameByUuid(_jack_client* client, string uuid)
    {
        var uuidPtr = (byte*)Marshal.StringToCoTaskMemUTF8(uuid);
        try
        {
            return Marshal.PtrToStringUTF8((IntPtr)jack.get_client_name_by_uuid(client, uuidPtr));
        }
        finally
        {
            Marshal.ZeroFreeCoTaskMemUTF8((IntPtr)uuidPtr);
        }
    }

    public static int Activate(_jack_client* client) => jack.activate(client);

    public static int Deactivate(_jack_client* client) => jack.deactivate(client);

    public static nuint ClientThreadId(_jack_client* client) => jack.client_thread_id(client);

    public static bool IsRealtime(_jack_client* client) => jack.is_realtime(client) != 0;

    public static uint CycleWait(_jack_client* client) => jack.cycle_wait(client);

    public static void CycleSignal(_jack_client* client, int status) => jack.cycle_signal(client, status);

    public delegate void ThreadCallback(void* arg);

    public static int SetProcessThread(_jack_client* client, ThreadCallback fun, void* arg) =>
        jack.set_process_thread(
            client,
            (delegate* unmanaged[Cdecl]<void*, void*>)Marshal.GetFunctionPointerForDelegate(fun),
            arg);

    public delegate void ThreadInitCallback(void* arg);

    public static int SetThreadInitCallback(_jack_client* client, ThreadInitCallback threadInitCallback, void* arg) =>
        jack.set_thread_init_callback(
            client,
            (delegate* unmanaged[Cdecl]<void*, void>)Marshal.GetFunctionPointerForDelegate(threadInitCallback),
            arg);

    public delegate void ShutdownCallback(void* arg);

    public static void OnShutdown(_jack_client* client, ShutdownCallback function, void* arg) =>
        jack.on_shutdown(
            client,
            (delegate* unmanaged[Cdecl]<void*, void>)Marshal.GetFunctionPointerForDelegate(function),
            arg);

    public delegate void InfoShutdownCallback(JackStatus code, byte* reasonStr, void* arg);

    public static void OnInfoShutdown(_jack_client* client, InfoShutdownCallback function, void* arg) =>
        jack.on_info_shutdown(
            client,
            (delegate* unmanaged[Cdecl]<JackStatus, byte*, void*, void>)Marshal.GetFunctionPointerForDelegate(function),
            arg);

    public delegate int ProcessCallback(uint nFrames, void* arg);

    public static int SetProcessCallback(_jack_client* client, ProcessCallback processCallback, void* arg) =>
        jack.set_process_callback(
            client,
            (delegate* unmanaged[Cdecl]<uint, void*, int>)Marshal.GetFunctionPointerForDelegate(processCallback),
            arg);

    public delegate void FreewheelCallback(int starting, void* arg);

    public static int SetFreewheelCallback(_jack_client* client, FreewheelCallback freewheelCallback, void* arg) =>
        jack.set_freewheel_callback(
            client,
            (delegate* unmanaged[Cdecl]<int, void*, void>)Marshal.GetFunctionPointerForDelegate(freewheelCallback),
            arg);

    public delegate int BufferSizeCallback(uint nFrames, void* arg);

    public static int SetBufferSizeCallback(_jack_client* client, BufferSizeCallback bufsizeCallback, void* arg) =>
        jack.set_buffer_size_callback(
            client,
            (delegate* unmanaged[Cdecl]<uint, void*, int>)Marshal.GetFunctionPointerForDelegate(bufsizeCallback),
            arg);

    public delegate int SampleRateCallback(uint nFrames, void* arg);

    public static int SetSampleRateCallback(_jack_client* client, SampleRateCallback srateCallback, void* arg) =>
        jack.set_sample_rate_callback(
            client,
            (delegate* unmanaged[Cdecl]<uint, void*, int>)Marshal.GetFunctionPointerForDelegate(srateCallback),
            arg);

    public delegate void ClientRegistrationCallback(byte* name, int register, void* arg);

    public static int SetClientRegistrationCallback(_jack_client* client,
        ClientRegistrationCallback registrationCallback, void* arg) =>
        jack.set_client_registration_callback(
            client,
            (delegate* unmanaged[Cdecl]<byte*, int, void*, void>)Marshal.GetFunctionPointerForDelegate(
                registrationCallback),
            arg);

    public delegate void PortRenameCallback(uint port, byte* oldName, byte* newName, void* arg);

    public static int SetPortRenameCallback(_jack_client* client, PortRenameCallback renameCallback, void* arg) =>
        jack.set_port_rename_callback(
            client,
            (delegate* unmanaged[Cdecl]<uint, byte*, byte*, void*, void>)Marshal.GetFunctionPointerForDelegate(
                renameCallback),
            arg);

    public delegate void PortConnectCallback(uint portA, uint portB, int connect, void* arg);

    public static int SetPortConnectCallback(_jack_client* client, PortConnectCallback connectCallback, void* arg) =>
        jack.set_port_connect_callback(
            client,
            (delegate* unmanaged[Cdecl]<uint, uint, int, void*, void>)Marshal.GetFunctionPointerForDelegate(
                connectCallback),
            arg);

    public delegate int GraphOrderCallback(void* arg);

    public static int SetGraphOrderCallback(_jack_client* client, GraphOrderCallback graphCallback, void* arg) =>
        jack.set_graph_order_callback(
            client,
            (delegate* unmanaged[Cdecl]<void*, int>)Marshal.GetFunctionPointerForDelegate(graphCallback),
            arg);

    public delegate int XRunCallback(void* arg);

    public static int SetXRunCallback(_jack_client* client, XRunCallback xrunCallback, void* arg) =>
        jack.set_xrun_callback(
            client,
            (delegate* unmanaged[Cdecl]<void*, int>)Marshal.GetFunctionPointerForDelegate(xrunCallback),
            arg);

    public delegate void LatencyCallback(JackLatencyCallbackMode mode, void* arg);

    public static int SetLatencyCallback(_jack_client* client, LatencyCallback latencyCallback, void* arg) =>
        jack.set_latency_callback(
            client,
            (delegate* unmanaged[Cdecl]<JackLatencyCallbackMode, void*, void>)Marshal.GetFunctionPointerForDelegate(
                latencyCallback),
            arg);

    public static int SetFreewheel(_jack_client* client, bool onOff) => jack.set_freewheel(client, onOff ? 1 : 0);

    public static int SetBufferSize(_jack_client* client, uint nFrames) => jack.set_buffer_size(client, nFrames);

    public static uint GetSampleRate(_jack_client* client) => jack.get_sample_rate(client);

    public static uint GetBufferSize(_jack_client* client) => jack.get_buffer_size(client);

    public static float CpuLoad(_jack_client* client) => jack.cpu_load(client);

    public static _jack_port* PortRegister(_jack_client* client, string portName, string portType, JackPortFlags flags,
        ulong bufferSize)
    {
        var portNamePtr = (byte*)Marshal.StringToCoTaskMemUTF8(portName);
        try
        {
            var portTypePtr = (byte*)Marshal.StringToCoTaskMemUTF8(portType);
            try
            {
                return jack.port_register(client, portNamePtr, portTypePtr, (nuint)flags, (nuint)bufferSize);
            }
            finally
            {
                Marshal.ZeroFreeCoTaskMemUTF8((nint)portNamePtr);
            }
        }
        finally
        {
            Marshal.ZeroFreeCoTaskMemUTF8((nint)portNamePtr);
        }
    }

    public static int PortUnregister(_jack_client* client, _jack_port* port) => jack.port_unregister(client, port);

    public static bool PortIsMine(_jack_client* client, _jack_port* port) => jack.port_is_mine(client, port) != 0;

    // TODO: jack_port_get_connections

    public static int PortRename(_jack_client* client, _jack_port* port, string portName)
    {
        var portNamePtr = (byte*)Marshal.StringToCoTaskMemUTF8(portName);
        try
        {
            return jack.port_rename(client, port, portNamePtr);
        }
        finally
        {
            Marshal.ZeroFreeCoTaskMemUTF8((nint)portNamePtr);
        }
    }

    public static int PortRequestMonitorByName(_jack_client* client, string portName, bool onOff)
    {
        var portNamePtr = (byte*)Marshal.StringToCoTaskMemUTF8(portName);
        try
        {
            return jack.port_request_monitor_by_name(client, portNamePtr, onOff ? 1 : 0);
        }
        finally
        {
            Marshal.ZeroFreeCoTaskMemUTF8((nint)portNamePtr);
        }
    }

    public static int Connect(_jack_client* client, string sourcePort, string destinationPort)
    {
        var sourcePortPtr = (byte*)Marshal.StringToCoTaskMemUTF8(sourcePort);
        try
        {
            var destinationPortPtr = (byte*)Marshal.StringToCoTaskMemUTF8(destinationPort);
            try
            {
                return jack.connect(client, sourcePortPtr, destinationPortPtr);
            }
            finally
            {
                Marshal.ZeroFreeCoTaskMemUTF8((nint)destinationPortPtr);
            }
        }
        finally
        {
            Marshal.ZeroFreeCoTaskMemUTF8((nint)sourcePortPtr);
        }
    }

    public static int Disconnect(_jack_client* client, string sourcePort, string destinationPort)
    {
        var sourcePortPtr = (byte*)Marshal.StringToCoTaskMemUTF8(sourcePort);
        try
        {
            var destinationPortPtr = (byte*)Marshal.StringToCoTaskMemUTF8(destinationPort);
            try
            {
                return jack.disconnect(client, sourcePortPtr, destinationPortPtr);
            }
            finally
            {
                Marshal.ZeroFreeCoTaskMemUTF8((nint)destinationPortPtr);
            }
        }
        finally
        {
            Marshal.ZeroFreeCoTaskMemUTF8((nint)sourcePortPtr);
        }
    }

    public static int Disconnect(_jack_client* client, _jack_port* port) => jack.port_disconnect(client, port);

    public static nuint PortTypeGetBufferSize(_jack_client* client, string port_type)
    {
        var portTypePtr = (byte*)Marshal.StringToCoTaskMemUTF8(port_type);
        try
        {
            return jack.port_type_get_buffer_size(client, portTypePtr);
        }
        finally
        {
            Marshal.ZeroFreeCoTaskMemUTF8((nint)portTypePtr);
        }
    }

    public static int RecomputeTotalLatencies(_jack_client* client) => jack.recompute_total_latencies(client);

    // TODO: jack_get_ports

    public static _jack_port* PortByName(_jack_client* client, string portName)
    {
        var portNamePtr = (byte*)Marshal.StringToCoTaskMemUTF8(portName);
        try
        {
            return jack.port_by_name(client, portNamePtr);
        }
        finally
        {
            Marshal.ZeroFreeCoTaskMemUTF8((nint)portNamePtr);
        }
    }

    public static _jack_port* PortById(_jack_client* client, uint portId) => jack.port_by_id(client, portId);

    public static uint FramesSinceCycleStart(_jack_client* client) => jack.frames_since_cycle_start(client);

    public static uint FrameTime(_jack_client* client) => jack.frame_time(client);

    public static uint LastFrameTime(_jack_client* client) => jack.last_frame_time(client);

    public static bool TryGetCycleTimes(_jack_client* client, out uint currentFrames, out nuint currentUsecs,
        out nuint nextUsecs, out float periodUsecs)
    {
        fixed (uint* currentFramesPtr = &currentFrames)
        {
            fixed (nuint* currentUsecsPtr = &currentUsecs)
            {
                fixed (nuint* nextUsecsPtr = &nextUsecs)
                {
                    fixed (float* periodUsecsPtr = &periodUsecs)
                    {
                        return jack.get_cycle_times(client, currentFramesPtr, currentUsecsPtr, nextUsecsPtr,
                            periodUsecsPtr) != 0;
                    }
                }
            }
        }
    }

    public static nuint FramesToTime(_jack_client* client, uint nFrames) => jack.frames_to_time(client, nFrames);

    public static nuint jack_time_to_frames(_jack_client* client, nuint usecs) => jack.time_to_frames(client, usecs);
}
