using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
// ReSharper disable InconsistentNaming

namespace Jack.Net.Interop;

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

    public static _jack_client* ClientOpen(ReadOnlySpan<byte> clientName, JackOptions options, out JackStatus status, ReadOnlySpan<byte> serverName)
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

    public static _jack_client* ClientOpen(string clientName, JackOptions options, out JackStatus status, string serverName)
    {
        var clientNamePtr = (byte*)Marshal.StringToCoTaskMemUTF8(clientName);
        try
        {
            fixed (JackStatus* statusPtr = &status)
            {
                var serverNamePtr = (byte*)Marshal.StringToCoTaskMemUTF8(serverName);
                try
                {
                    return jack.client_open(clientNamePtr, options, statusPtr, __arglist(serverNamePtr));
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
}
