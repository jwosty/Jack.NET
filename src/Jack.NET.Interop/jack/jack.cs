using System;
using System.Runtime.InteropServices;

namespace Jack.NET.Interop
{
    public static unsafe partial class jack
    {
        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_get_internal_client_name", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern byte* get_internal_client_name([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("jack_intclient_t")] nuint intclient);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_internal_client_handle", ExactSpelling = true)]
        public static extern int internal_client_handle([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("const char *")] byte* client_name, [NativeTypeName("jack_status_t *")] JackStatus* status, [NativeTypeName("jack_intclient_t *")] nuint* handle);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_internal_client_load", ExactSpelling = true)]
        public static extern int internal_client_load([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("const char *")] byte* client_name, [NativeTypeName("jack_options_t")] JackOptions options, [NativeTypeName("jack_status_t *")] JackStatus* status, [NativeTypeName("jack_intclient_t")] nuint param4, __arglist);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_internal_client_unload", ExactSpelling = true)]
        [return: NativeTypeName("jack_status_t")]
        public static extern JackStatus internal_client_unload([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("jack_intclient_t")] nuint intclient);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_client_open", ExactSpelling = true)]
        [return: NativeTypeName("jack_client_t *")]
        public static extern _jack_client* client_open([NativeTypeName("const char *")] byte* client_name, [NativeTypeName("jack_options_t")] JackOptions options, [NativeTypeName("jack_status_t *")] JackStatus* status, __arglist);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_client_new", ExactSpelling = true)]
        [return: NativeTypeName("jack_client_t *")]
        [Obsolete]
        public static extern _jack_client* client_new([NativeTypeName("const char *")] byte* client_name);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_client_close", ExactSpelling = true)]
        public static extern int client_close([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_client_name_size", ExactSpelling = true)]
        public static extern int client_name_size();

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_get_client_name", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern byte* get_client_name([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_get_uuid_for_client_name", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern byte* get_uuid_for_client_name([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("const char *")] byte* name);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_get_client_name_by_uuid", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern byte* get_client_name_by_uuid([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("const char *")] byte* uuid);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_internal_client_new", ExactSpelling = true)]
        [Obsolete]
        public static extern int internal_client_new([NativeTypeName("const char *")] byte* client_name, [NativeTypeName("const char *")] byte* load_name, [NativeTypeName("const char *")] byte* load_init);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_internal_client_close", ExactSpelling = true)]
        [Obsolete]
        public static extern void internal_client_close([NativeTypeName("const char *")] byte* client_name);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_activate", ExactSpelling = true)]
        public static extern int activate([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_deactivate", ExactSpelling = true)]
        public static extern int deactivate([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_client_thread_id", ExactSpelling = true)]
        [return: NativeTypeName("jack_native_thread_t")]
        public static extern nuint client_thread_id([NativeTypeName("jack_client_t *")] _jack_client* param0);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_is_realtime", ExactSpelling = true)]
        public static extern int is_realtime([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_thread_wait", ExactSpelling = true)]
        [return: NativeTypeName("jack_nframes_t")]
        [Obsolete]
        public static extern uint thread_wait([NativeTypeName("jack_client_t *")] _jack_client* param0, int status);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_cycle_wait", ExactSpelling = true)]
        [return: NativeTypeName("jack_nframes_t")]
        public static extern uint cycle_wait([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_cycle_signal", ExactSpelling = true)]
        public static extern void cycle_signal([NativeTypeName("jack_client_t *")] _jack_client* client, int status);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_process_thread", ExactSpelling = true)]
        public static extern int set_process_thread([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("JackThreadCallback")] delegate* unmanaged[Cdecl]<void*, void*> fun, void* arg);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_thread_init_callback", ExactSpelling = true)]
        public static extern int set_thread_init_callback([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("JackThreadInitCallback")] delegate* unmanaged[Cdecl]<void*, void> thread_init_callback, void* arg);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_on_shutdown", ExactSpelling = true)]
        public static extern void on_shutdown([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("JackShutdownCallback")] delegate* unmanaged[Cdecl]<void*, void> function, void* arg);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_on_info_shutdown", ExactSpelling = true)]
        public static extern void on_info_shutdown([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("JackInfoShutdownCallback")] delegate* unmanaged[Cdecl]<JackStatus, byte*, void*, void> function, void* arg);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_process_callback", ExactSpelling = true)]
        public static extern int set_process_callback([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("JackProcessCallback")] delegate* unmanaged[Cdecl]<uint, void*, int> process_callback, void* arg);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_freewheel_callback", ExactSpelling = true)]
        public static extern int set_freewheel_callback([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("JackFreewheelCallback")] delegate* unmanaged[Cdecl]<int, void*, void> freewheel_callback, void* arg);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_buffer_size_callback", ExactSpelling = true)]
        public static extern int set_buffer_size_callback([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("JackBufferSizeCallback")] delegate* unmanaged[Cdecl]<uint, void*, int> bufsize_callback, void* arg);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_sample_rate_callback", ExactSpelling = true)]
        public static extern int set_sample_rate_callback([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("JackSampleRateCallback")] delegate* unmanaged[Cdecl]<uint, void*, int> srate_callback, void* arg);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_client_registration_callback", ExactSpelling = true)]
        public static extern int set_client_registration_callback([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("JackClientRegistrationCallback")] delegate* unmanaged[Cdecl]<byte*, int, void*, void> registration_callback, void* arg);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_port_registration_callback", ExactSpelling = true)]
        public static extern int set_port_registration_callback([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("JackPortRegistrationCallback")] delegate* unmanaged[Cdecl]<uint, int, void*, void> registration_callback, void* arg);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_port_rename_callback", ExactSpelling = true)]
        public static extern int set_port_rename_callback([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("JackPortRenameCallback")] delegate* unmanaged[Cdecl]<uint, byte*, byte*, void*, void> rename_callback, void* arg);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_port_connect_callback", ExactSpelling = true)]
        public static extern int set_port_connect_callback([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("JackPortConnectCallback")] delegate* unmanaged[Cdecl]<uint, uint, int, void*, void> connect_callback, void* arg);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_graph_order_callback", ExactSpelling = true)]
        public static extern int set_graph_order_callback([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("JackGraphOrderCallback")] delegate* unmanaged[Cdecl]<void*, int> graph_callback, void* param2);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_xrun_callback", ExactSpelling = true)]
        public static extern int set_xrun_callback([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("JackXRunCallback")] delegate* unmanaged[Cdecl]<void*, int> xrun_callback, void* arg);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_latency_callback", ExactSpelling = true)]
        public static extern int set_latency_callback([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("JackLatencyCallback")] delegate* unmanaged[Cdecl]<JackLatencyCallbackMode, void*, void> latency_callback, void* param2);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_freewheel", ExactSpelling = true)]
        public static extern int set_freewheel([NativeTypeName("jack_client_t *")] _jack_client* client, int onoff);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_buffer_size", ExactSpelling = true)]
        public static extern int set_buffer_size([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("jack_nframes_t")] uint nframes);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_get_sample_rate", ExactSpelling = true)]
        [return: NativeTypeName("jack_nframes_t")]
        public static extern uint get_sample_rate([NativeTypeName("jack_client_t *")] _jack_client* param0);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_get_buffer_size", ExactSpelling = true)]
        [return: NativeTypeName("jack_nframes_t")]
        public static extern uint get_buffer_size([NativeTypeName("jack_client_t *")] _jack_client* param0);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_engine_takeover_timebase", ExactSpelling = true)]
        [Obsolete]
        public static extern int engine_takeover_timebase([NativeTypeName("jack_client_t *")] _jack_client* param0);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_cpu_load", ExactSpelling = true)]
        public static extern float cpu_load([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_register", ExactSpelling = true)]
        [return: NativeTypeName("jack_port_t *")]
        public static extern _jack_port* port_register([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("const char *")] byte* port_name, [NativeTypeName("const char *")] byte* port_type, [NativeTypeName("unsigned long")] nuint flags, [NativeTypeName("unsigned long")] nuint buffer_size);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_unregister", ExactSpelling = true)]
        public static extern int port_unregister([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("jack_port_t *")] _jack_port* param1);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_get_buffer", ExactSpelling = true)]
        public static extern void* port_get_buffer([NativeTypeName("jack_port_t *")] _jack_port* param0, [NativeTypeName("jack_nframes_t")] uint param1);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_name", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* port_name([NativeTypeName("const jack_port_t *")] _jack_port* port);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_uuid", ExactSpelling = true)]
        [return: NativeTypeName("jack_uuid_t")]
        public static extern nuint port_uuid([NativeTypeName("const jack_port_t *")] _jack_port* port);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_short_name", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* port_short_name([NativeTypeName("const jack_port_t *")] _jack_port* port);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_flags", ExactSpelling = true)]
        public static extern int port_flags([NativeTypeName("const jack_port_t *")] _jack_port* port);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_type", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* port_type([NativeTypeName("const jack_port_t *")] _jack_port* port);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_is_mine", ExactSpelling = true)]
        public static extern int port_is_mine([NativeTypeName("const jack_client_t *")] _jack_client* param0, [NativeTypeName("const jack_port_t *")] _jack_port* port);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_connected", ExactSpelling = true)]
        public static extern int port_connected([NativeTypeName("const jack_port_t *")] _jack_port* port);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_connected_to", ExactSpelling = true)]
        public static extern int port_connected_to([NativeTypeName("const jack_port_t *")] _jack_port* port, [NativeTypeName("const char *")] byte* port_name);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_get_connections", ExactSpelling = true)]
        [return: NativeTypeName("const char **")]
        public static extern byte** port_get_connections([NativeTypeName("const jack_port_t *")] _jack_port* port);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_get_all_connections", ExactSpelling = true)]
        [return: NativeTypeName("const char **")]
        public static extern byte** port_get_all_connections([NativeTypeName("const jack_client_t *")] _jack_client* client, [NativeTypeName("const jack_port_t *")] _jack_port* port);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_tie", ExactSpelling = true)]
        [Obsolete]
        public static extern int port_tie([NativeTypeName("jack_port_t *")] _jack_port* src, [NativeTypeName("jack_port_t *")] _jack_port* dst);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_untie", ExactSpelling = true)]
        [Obsolete]
        public static extern int port_untie([NativeTypeName("jack_port_t *")] _jack_port* port);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_set_name", ExactSpelling = true)]
        [Obsolete]
        public static extern int port_set_name([NativeTypeName("jack_port_t *")] _jack_port* port, [NativeTypeName("const char *")] byte* port_name);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_rename", ExactSpelling = true)]
        public static extern int port_rename([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("jack_port_t *")] _jack_port* port, [NativeTypeName("const char *")] byte* port_name);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_set_alias", ExactSpelling = true)]
        public static extern int port_set_alias([NativeTypeName("jack_port_t *")] _jack_port* port, [NativeTypeName("const char *")] byte* alias);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_unset_alias", ExactSpelling = true)]
        public static extern int port_unset_alias([NativeTypeName("jack_port_t *")] _jack_port* port, [NativeTypeName("const char *")] byte* alias);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_get_aliases", ExactSpelling = true)]
        public static extern int port_get_aliases([NativeTypeName("const jack_port_t *")] _jack_port* port, [NativeTypeName("char *const[2]")] byte** aliases);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_request_monitor", ExactSpelling = true)]
        public static extern int port_request_monitor([NativeTypeName("jack_port_t *")] _jack_port* port, int onoff);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_request_monitor_by_name", ExactSpelling = true)]
        public static extern int port_request_monitor_by_name([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("const char *")] byte* port_name, int onoff);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_ensure_monitor", ExactSpelling = true)]
        public static extern int port_ensure_monitor([NativeTypeName("jack_port_t *")] _jack_port* port, int onoff);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_monitoring_input", ExactSpelling = true)]
        public static extern int port_monitoring_input([NativeTypeName("jack_port_t *")] _jack_port* port);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_connect", ExactSpelling = true)]
        public static extern int connect([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("const char *")] byte* source_port, [NativeTypeName("const char *")] byte* destination_port);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_disconnect", ExactSpelling = true)]
        public static extern int disconnect([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("const char *")] byte* source_port, [NativeTypeName("const char *")] byte* destination_port);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_disconnect", ExactSpelling = true)]
        public static extern int port_disconnect([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("jack_port_t *")] _jack_port* param1);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_name_size", ExactSpelling = true)]
        public static extern int port_name_size();

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_type_size", ExactSpelling = true)]
        public static extern int port_type_size();

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_type_get_buffer_size", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint port_type_get_buffer_size([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("const char *")] byte* port_type);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_set_latency", ExactSpelling = true)]
        [Obsolete]
        public static extern void port_set_latency([NativeTypeName("jack_port_t *")] _jack_port* param0, [NativeTypeName("jack_nframes_t")] uint param1);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_get_latency_range", ExactSpelling = true)]
        public static extern void port_get_latency_range([NativeTypeName("jack_port_t *")] _jack_port* port, [NativeTypeName("jack_latency_callback_mode_t")] JackLatencyCallbackMode mode, [NativeTypeName("jack_latency_range_t *")] _jack_latency_range* range);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_set_latency_range", ExactSpelling = true)]
        public static extern void port_set_latency_range([NativeTypeName("jack_port_t *")] _jack_port* port, [NativeTypeName("jack_latency_callback_mode_t")] JackLatencyCallbackMode mode, [NativeTypeName("jack_latency_range_t *")] _jack_latency_range* range);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_recompute_total_latencies", ExactSpelling = true)]
        public static extern int recompute_total_latencies([NativeTypeName("jack_client_t *")] _jack_client* param0);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_get_latency", ExactSpelling = true)]
        [return: NativeTypeName("jack_nframes_t")]
        [Obsolete]
        public static extern uint port_get_latency([NativeTypeName("jack_port_t *")] _jack_port* port);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_get_total_latency", ExactSpelling = true)]
        [return: NativeTypeName("jack_nframes_t")]
        [Obsolete]
        public static extern uint port_get_total_latency([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("jack_port_t *")] _jack_port* port);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_recompute_total_latency", ExactSpelling = true)]
        [Obsolete]
        public static extern int recompute_total_latency([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("jack_port_t *")] _jack_port* port);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_get_ports", ExactSpelling = true)]
        [return: NativeTypeName("const char **")]
        public static extern byte** get_ports([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("const char *")] byte* port_name_pattern, [NativeTypeName("const char *")] byte* type_name_pattern, [NativeTypeName("unsigned long")] nuint flags);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_by_name", ExactSpelling = true)]
        [return: NativeTypeName("jack_port_t *")]
        public static extern _jack_port* port_by_name([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("const char *")] byte* port_name);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_by_id", ExactSpelling = true)]
        [return: NativeTypeName("jack_port_t *")]
        public static extern _jack_port* port_by_id([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("jack_port_id_t")] uint port_id);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_frames_since_cycle_start", ExactSpelling = true)]
        [return: NativeTypeName("jack_nframes_t")]
        public static extern uint frames_since_cycle_start([NativeTypeName("const jack_client_t *")] _jack_client* param0);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_frame_time", ExactSpelling = true)]
        [return: NativeTypeName("jack_nframes_t")]
        public static extern uint frame_time([NativeTypeName("const jack_client_t *")] _jack_client* param0);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_last_frame_time", ExactSpelling = true)]
        [return: NativeTypeName("jack_nframes_t")]
        public static extern uint last_frame_time([NativeTypeName("const jack_client_t *")] _jack_client* client);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_get_cycle_times", ExactSpelling = true)]
        public static extern int get_cycle_times([NativeTypeName("const jack_client_t *")] _jack_client* client, [NativeTypeName("jack_nframes_t *")] uint* current_frames, [NativeTypeName("jack_time_t *")] nuint* current_usecs, [NativeTypeName("jack_time_t *")] nuint* next_usecs, float* period_usecs);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_frames_to_time", ExactSpelling = true)]
        [return: NativeTypeName("jack_time_t")]
        public static extern nuint frames_to_time([NativeTypeName("const jack_client_t *")] _jack_client* client, [NativeTypeName("jack_nframes_t")] uint param1);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_time_to_frames", ExactSpelling = true)]
        [return: NativeTypeName("jack_nframes_t")]
        public static extern uint time_to_frames([NativeTypeName("const jack_client_t *")] _jack_client* client, [NativeTypeName("jack_time_t")] nuint param1);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_get_time", ExactSpelling = true)]
        [return: NativeTypeName("jack_time_t")]
        public static extern nuint get_time();

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_error_function", ExactSpelling = true)]
        public static extern void set_error_function([NativeTypeName("void (*)(const char *)")] delegate* unmanaged[Cdecl]<byte*, void> func);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_info_function", ExactSpelling = true)]
        public static extern void set_info_function([NativeTypeName("void (*)(const char *)")] delegate* unmanaged[Cdecl]<byte*, void> func);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_free", ExactSpelling = true)]
        public static extern void free(void* ptr);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_property", ExactSpelling = true)]
        public static extern int set_property([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("jack_uuid_t")] nuint subject, [NativeTypeName("const char *")] byte* key, [NativeTypeName("const char *")] byte* value, [NativeTypeName("const char *")] byte* type);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_get_property", ExactSpelling = true)]
        public static extern int get_property([NativeTypeName("jack_uuid_t")] nuint subject, [NativeTypeName("const char *")] byte* key, [NativeTypeName("char **")] byte** value, [NativeTypeName("char **")] byte** type);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_free_description", ExactSpelling = true)]
        public static extern void free_description(jack_description_t* desc, int free_description_itself);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_get_properties", ExactSpelling = true)]
        public static extern int get_properties([NativeTypeName("jack_uuid_t")] nuint subject, jack_description_t* desc);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_get_all_properties", ExactSpelling = true)]
        public static extern int get_all_properties(jack_description_t** descs);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_remove_property", ExactSpelling = true)]
        public static extern int remove_property([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("jack_uuid_t")] nuint subject, [NativeTypeName("const char *")] byte* key);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_remove_properties", ExactSpelling = true)]
        public static extern int remove_properties([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("jack_uuid_t")] nuint subject);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_remove_all_properties", ExactSpelling = true)]
        public static extern int remove_all_properties([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_property_change_callback", ExactSpelling = true)]
        public static extern int set_property_change_callback([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("JackPropertyChangeCallback")] delegate* unmanaged[Cdecl]<nuint, byte*, jack_property_change_t, void*, void> callback, void* arg);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_midi_get_event_count", ExactSpelling = true)]
        [return: NativeTypeName("jack_nframes_t")]
        public static extern uint midi_get_event_count(void* port_buffer);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_midi_event_get", ExactSpelling = true)]
        public static extern int midi_event_get([NativeTypeName("jack_midi_event_t *")] _jack_midi_event* @event, void* port_buffer, [NativeTypeName("uint32_t")] uint event_index);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_midi_clear_buffer", ExactSpelling = true)]
        public static extern void midi_clear_buffer(void* port_buffer);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_midi_max_event_size", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint midi_max_event_size(void* port_buffer);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_midi_event_reserve", ExactSpelling = true)]
        [return: NativeTypeName("jack_midi_data_t *")]
        public static extern byte* midi_event_reserve(void* port_buffer, [NativeTypeName("jack_nframes_t")] uint time, [NativeTypeName("size_t")] nuint data_size);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_midi_event_write", ExactSpelling = true)]
        public static extern int midi_event_write(void* port_buffer, [NativeTypeName("jack_nframes_t")] uint time, [NativeTypeName("const jack_midi_data_t *")] byte* data, [NativeTypeName("size_t")] nuint data_size);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_midi_get_lost_event_count", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint midi_get_lost_event_count(void* port_buffer);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_ringbuffer_create", ExactSpelling = true)]
        public static extern jack_ringbuffer_t* ringbuffer_create([NativeTypeName("size_t")] nuint sz);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_ringbuffer_free", ExactSpelling = true)]
        public static extern void ringbuffer_free(jack_ringbuffer_t* rb);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_ringbuffer_get_read_vector", ExactSpelling = true)]
        public static extern void ringbuffer_get_read_vector([NativeTypeName("const jack_ringbuffer_t *")] jack_ringbuffer_t* rb, jack_ringbuffer_data_t* vec);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_ringbuffer_get_write_vector", ExactSpelling = true)]
        public static extern void ringbuffer_get_write_vector([NativeTypeName("const jack_ringbuffer_t *")] jack_ringbuffer_t* rb, jack_ringbuffer_data_t* vec);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_ringbuffer_read", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint ringbuffer_read(jack_ringbuffer_t* rb, [NativeTypeName("char *")] byte* dest, [NativeTypeName("size_t")] nuint cnt);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_ringbuffer_peek", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint ringbuffer_peek(jack_ringbuffer_t* rb, [NativeTypeName("char *")] byte* dest, [NativeTypeName("size_t")] nuint cnt);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_ringbuffer_read_advance", ExactSpelling = true)]
        public static extern void ringbuffer_read_advance(jack_ringbuffer_t* rb, [NativeTypeName("size_t")] nuint cnt);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_ringbuffer_read_space", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint ringbuffer_read_space([NativeTypeName("const jack_ringbuffer_t *")] jack_ringbuffer_t* rb);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_ringbuffer_mlock", ExactSpelling = true)]
        public static extern int ringbuffer_mlock(jack_ringbuffer_t* rb);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_ringbuffer_reset", ExactSpelling = true)]
        public static extern void ringbuffer_reset(jack_ringbuffer_t* rb);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_ringbuffer_write", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint ringbuffer_write(jack_ringbuffer_t* rb, [NativeTypeName("const char *")] byte* src, [NativeTypeName("size_t")] nuint cnt);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_ringbuffer_write_advance", ExactSpelling = true)]
        public static extern void ringbuffer_write_advance(jack_ringbuffer_t* rb, [NativeTypeName("size_t")] nuint cnt);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_ringbuffer_write_space", ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint ringbuffer_write_space([NativeTypeName("const jack_ringbuffer_t *")] jack_ringbuffer_t* rb);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_session_callback", ExactSpelling = true)]
        [Obsolete]
        public static extern int set_session_callback([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("JackSessionCallback")] delegate* unmanaged[Cdecl]<_jack_session_event*, void*, void> session_callback, void* arg);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_session_reply", ExactSpelling = true)]
        [Obsolete]
        public static extern int session_reply([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("jack_session_event_t *")] _jack_session_event* @event);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_session_event_free", ExactSpelling = true)]
        [Obsolete]
        public static extern void session_event_free([NativeTypeName("jack_session_event_t *")] _jack_session_event* @event);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_client_get_uuid", ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern byte* client_get_uuid([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_session_notify", ExactSpelling = true)]
        public static extern jack_session_command_t* session_notify([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("const char *")] byte* target, [NativeTypeName("jack_session_event_type_t")] JackSessionEventType type, [NativeTypeName("const char *")] byte* path);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_session_commands_free", ExactSpelling = true)]
        [Obsolete]
        public static extern void session_commands_free(jack_session_command_t* cmds);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_reserve_client_name", ExactSpelling = true)]
        public static extern int reserve_client_name([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("const char *")] byte* name, [NativeTypeName("const char *")] byte* uuid);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_client_has_session_callback", ExactSpelling = true)]
        [Obsolete]
        public static extern int client_has_session_callback([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("const char *")] byte* client_name);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_get_max_delayed_usecs", ExactSpelling = true)]
        public static extern float get_max_delayed_usecs([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_get_xrun_delayed_usecs", ExactSpelling = true)]
        public static extern float get_xrun_delayed_usecs([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_reset_max_delayed_usecs", ExactSpelling = true)]
        public static extern void reset_max_delayed_usecs([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_client_real_time_priority", ExactSpelling = true)]
        public static extern int client_real_time_priority([NativeTypeName("jack_client_t *")] _jack_client* param0);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_client_max_real_time_priority", ExactSpelling = true)]
        public static extern int client_max_real_time_priority([NativeTypeName("jack_client_t *")] _jack_client* param0);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_acquire_real_time_scheduling", ExactSpelling = true)]
        public static extern int acquire_real_time_scheduling([NativeTypeName("jack_native_thread_t")] nuint thread, int priority);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_client_create_thread", ExactSpelling = true)]
        public static extern int client_create_thread([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("jack_native_thread_t *")] nuint* thread, int priority, int realtime, [NativeTypeName("void *(*)(void *)")] delegate* unmanaged[Cdecl]<void*, void*> start_routine, void* arg);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_drop_real_time_scheduling", ExactSpelling = true)]
        public static extern int drop_real_time_scheduling([NativeTypeName("jack_native_thread_t")] nuint thread);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_thread_creator", ExactSpelling = true)]
        public static extern void set_thread_creator([NativeTypeName("jack_thread_creator_t")] delegate* unmanaged[Cdecl]<nuint*, pthread_attr_t*, delegate* unmanaged[Cdecl]<void*, void*>, void*, int> creator);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_release_timebase", ExactSpelling = true)]
        public static extern int release_timebase([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_sync_callback", ExactSpelling = true)]
        public static extern int set_sync_callback([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("JackSyncCallback")] delegate* unmanaged[Cdecl]<jack_transport_state_t, jack_position_t*, void*, int> sync_callback, void* arg);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_sync_timeout", ExactSpelling = true)]
        public static extern int set_sync_timeout([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("jack_time_t")] nuint timeout);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_timebase_callback", ExactSpelling = true)]
        public static extern int set_timebase_callback([NativeTypeName("jack_client_t *")] _jack_client* client, int conditional, [NativeTypeName("JackTimebaseCallback")] delegate* unmanaged[Cdecl]<jack_transport_state_t, uint, jack_position_t*, int, void*, void> timebase_callback, void* arg);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_transport_locate", ExactSpelling = true)]
        public static extern int transport_locate([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("jack_nframes_t")] uint frame);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_transport_query", ExactSpelling = true)]
        public static extern jack_transport_state_t transport_query([NativeTypeName("const jack_client_t *")] _jack_client* client, jack_position_t* pos);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_get_current_transport_frame", ExactSpelling = true)]
        [return: NativeTypeName("jack_nframes_t")]
        public static extern uint get_current_transport_frame([NativeTypeName("const jack_client_t *")] _jack_client* client);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_transport_reposition", ExactSpelling = true)]
        public static extern int transport_reposition([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("const jack_position_t *")] jack_position_t* pos);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_transport_start", ExactSpelling = true)]
        public static extern void transport_start([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_transport_stop", ExactSpelling = true)]
        public static extern void transport_stop([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_get_transport_info", ExactSpelling = true)]
        [Obsolete]
        public static extern void get_transport_info([NativeTypeName("jack_client_t *")] _jack_client* client, jack_transport_info_t* tinfo);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_set_transport_info", ExactSpelling = true)]
        [Obsolete]
        public static extern void set_transport_info([NativeTypeName("jack_client_t *")] _jack_client* client, jack_transport_info_t* tinfo);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_client_uuid_generate", ExactSpelling = true)]
        [return: NativeTypeName("jack_uuid_t")]
        public static extern nuint client_uuid_generate();

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_port_uuid_generate", ExactSpelling = true)]
        [return: NativeTypeName("jack_uuid_t")]
        public static extern nuint port_uuid_generate([NativeTypeName("uint32_t")] uint port_id);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_uuid_to_index", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint uuid_to_index([NativeTypeName("jack_uuid_t")] nuint param0);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_uuid_compare", ExactSpelling = true)]
        public static extern int uuid_compare([NativeTypeName("jack_uuid_t")] nuint param0, [NativeTypeName("jack_uuid_t")] nuint param1);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_uuid_copy", ExactSpelling = true)]
        public static extern void uuid_copy([NativeTypeName("jack_uuid_t *")] nuint* dst, [NativeTypeName("jack_uuid_t")] nuint src);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_uuid_clear", ExactSpelling = true)]
        public static extern void uuid_clear([NativeTypeName("jack_uuid_t *")] nuint* param0);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_uuid_parse", ExactSpelling = true)]
        public static extern int uuid_parse([NativeTypeName("const char *")] byte* buf, [NativeTypeName("jack_uuid_t *")] nuint* param1);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_uuid_unparse", ExactSpelling = true)]
        public static extern void uuid_unparse([NativeTypeName("jack_uuid_t")] nuint param0, [NativeTypeName("char[37]")] byte* buf);

        [DllImport("libjack.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jack_uuid_empty", ExactSpelling = true)]
        public static extern int uuid_empty([NativeTypeName("jack_uuid_t")] nuint param0);
    }
}
