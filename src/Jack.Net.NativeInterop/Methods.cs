using System;
using System.Runtime.InteropServices;

namespace Jack.Net.NativeInterop
{
    public static unsafe partial class Methods
    {
        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern byte* jack_get_internal_client_name([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("jack_intclient_t")] nuint intclient);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_internal_client_handle([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("const char *")] byte* client_name, [NativeTypeName("jack_status_t *")] JackStatus* status, [NativeTypeName("jack_intclient_t *")] nuint* handle);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_internal_client_load([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("const char *")] byte* client_name, [NativeTypeName("jack_options_t")] JackOptions options, [NativeTypeName("jack_status_t *")] JackStatus* status, [NativeTypeName("jack_intclient_t")] nuint param4, __arglist);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_status_t")]
        public static extern JackStatus jack_internal_client_unload([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("jack_intclient_t")] nuint intclient);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_client_t *")]
        public static extern _jack_client* jack_client_open([NativeTypeName("const char *")] byte* client_name, [NativeTypeName("jack_options_t")] JackOptions options, [NativeTypeName("jack_status_t *")] JackStatus* status, __arglist);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_client_t *")]
        [Obsolete]
        public static extern _jack_client* jack_client_new([NativeTypeName("const char *")] byte* client_name);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_client_close([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_client_name_size();

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern byte* jack_get_client_name([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern byte* jack_get_uuid_for_client_name([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("const char *")] byte* name);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern byte* jack_get_client_name_by_uuid([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("const char *")] byte* uuid);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int jack_internal_client_new([NativeTypeName("const char *")] byte* client_name, [NativeTypeName("const char *")] byte* load_name, [NativeTypeName("const char *")] byte* load_init);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void jack_internal_client_close([NativeTypeName("const char *")] byte* client_name);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_activate([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_deactivate([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_native_thread_t")]
        public static extern nuint jack_client_thread_id([NativeTypeName("jack_client_t *")] _jack_client* param0);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_is_realtime([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_nframes_t")]
        [Obsolete]
        public static extern uint jack_thread_wait([NativeTypeName("jack_client_t *")] _jack_client* param0, int status);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_nframes_t")]
        public static extern uint jack_cycle_wait([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_cycle_signal([NativeTypeName("jack_client_t *")] _jack_client* client, int status);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_set_process_thread([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("JackThreadCallback")] delegate* unmanaged[Cdecl]<void*, void*> fun, void* arg);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_set_thread_init_callback([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("JackThreadInitCallback")] delegate* unmanaged[Cdecl]<void*, void> thread_init_callback, void* arg);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_on_shutdown([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("JackShutdownCallback")] delegate* unmanaged[Cdecl]<void*, void> function, void* arg);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_on_info_shutdown([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("JackInfoShutdownCallback")] delegate* unmanaged[Cdecl]<JackStatus, byte*, void*, void> function, void* arg);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_set_process_callback([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("JackProcessCallback")] delegate* unmanaged[Cdecl]<uint, void*, int> process_callback, void* arg);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_set_freewheel_callback([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("JackFreewheelCallback")] delegate* unmanaged[Cdecl]<int, void*, void> freewheel_callback, void* arg);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_set_buffer_size_callback([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("JackBufferSizeCallback")] delegate* unmanaged[Cdecl]<uint, void*, int> bufsize_callback, void* arg);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_set_sample_rate_callback([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("JackSampleRateCallback")] delegate* unmanaged[Cdecl]<uint, void*, int> srate_callback, void* arg);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_set_client_registration_callback([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("JackClientRegistrationCallback")] delegate* unmanaged[Cdecl]<byte*, int, void*, void> registration_callback, void* arg);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_set_port_registration_callback([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("JackPortRegistrationCallback")] delegate* unmanaged[Cdecl]<uint, int, void*, void> registration_callback, void* arg);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_set_port_rename_callback([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("JackPortRenameCallback")] delegate* unmanaged[Cdecl]<uint, byte*, byte*, void*, void> rename_callback, void* arg);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_set_port_connect_callback([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("JackPortConnectCallback")] delegate* unmanaged[Cdecl]<uint, uint, int, void*, void> connect_callback, void* arg);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_set_graph_order_callback([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("JackGraphOrderCallback")] delegate* unmanaged[Cdecl]<void*, int> graph_callback, void* param2);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_set_xrun_callback([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("JackXRunCallback")] delegate* unmanaged[Cdecl]<void*, int> xrun_callback, void* arg);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_set_latency_callback([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("JackLatencyCallback")] delegate* unmanaged[Cdecl]<JackLatencyCallbackMode, void*, void> latency_callback, void* param2);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_set_freewheel([NativeTypeName("jack_client_t *")] _jack_client* client, int onoff);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_set_buffer_size([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("jack_nframes_t")] uint nframes);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_nframes_t")]
        public static extern uint jack_get_sample_rate([NativeTypeName("jack_client_t *")] _jack_client* param0);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_nframes_t")]
        public static extern uint jack_get_buffer_size([NativeTypeName("jack_client_t *")] _jack_client* param0);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int jack_engine_takeover_timebase([NativeTypeName("jack_client_t *")] _jack_client* param0);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float jack_cpu_load([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_port_t *")]
        public static extern _jack_port* jack_port_register([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("const char *")] byte* port_name, [NativeTypeName("const char *")] byte* port_type, [NativeTypeName("unsigned long")] nuint flags, [NativeTypeName("unsigned long")] nuint buffer_size);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_port_unregister([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("jack_port_t *")] _jack_port* param1);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* jack_port_get_buffer([NativeTypeName("jack_port_t *")] _jack_port* param0, [NativeTypeName("jack_nframes_t")] uint param1);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* jack_port_name([NativeTypeName("const jack_port_t *")] _jack_port* port);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_uuid_t")]
        public static extern nuint jack_port_uuid([NativeTypeName("const jack_port_t *")] _jack_port* port);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* jack_port_short_name([NativeTypeName("const jack_port_t *")] _jack_port* port);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_port_flags([NativeTypeName("const jack_port_t *")] _jack_port* port);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* jack_port_type([NativeTypeName("const jack_port_t *")] _jack_port* port);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_port_is_mine([NativeTypeName("const jack_client_t *")] _jack_client* param0, [NativeTypeName("const jack_port_t *")] _jack_port* port);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_port_connected([NativeTypeName("const jack_port_t *")] _jack_port* port);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_port_connected_to([NativeTypeName("const jack_port_t *")] _jack_port* port, [NativeTypeName("const char *")] byte* port_name);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char **")]
        public static extern byte** jack_port_get_connections([NativeTypeName("const jack_port_t *")] _jack_port* port);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char **")]
        public static extern byte** jack_port_get_all_connections([NativeTypeName("const jack_client_t *")] _jack_client* client, [NativeTypeName("const jack_port_t *")] _jack_port* port);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int jack_port_tie([NativeTypeName("jack_port_t *")] _jack_port* src, [NativeTypeName("jack_port_t *")] _jack_port* dst);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int jack_port_untie([NativeTypeName("jack_port_t *")] _jack_port* port);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int jack_port_set_name([NativeTypeName("jack_port_t *")] _jack_port* port, [NativeTypeName("const char *")] byte* port_name);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_port_rename([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("jack_port_t *")] _jack_port* port, [NativeTypeName("const char *")] byte* port_name);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_port_set_alias([NativeTypeName("jack_port_t *")] _jack_port* port, [NativeTypeName("const char *")] byte* alias);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_port_unset_alias([NativeTypeName("jack_port_t *")] _jack_port* port, [NativeTypeName("const char *")] byte* alias);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_port_get_aliases([NativeTypeName("const jack_port_t *")] _jack_port* port, [NativeTypeName("char *const[2]")] byte** aliases);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_port_request_monitor([NativeTypeName("jack_port_t *")] _jack_port* port, int onoff);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_port_request_monitor_by_name([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("const char *")] byte* port_name, int onoff);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_port_ensure_monitor([NativeTypeName("jack_port_t *")] _jack_port* port, int onoff);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_port_monitoring_input([NativeTypeName("jack_port_t *")] _jack_port* port);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_connect([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("const char *")] byte* source_port, [NativeTypeName("const char *")] byte* destination_port);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_disconnect([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("const char *")] byte* source_port, [NativeTypeName("const char *")] byte* destination_port);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_port_disconnect([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("jack_port_t *")] _jack_port* param1);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_port_name_size();

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_port_type_size();

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint jack_port_type_get_buffer_size([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("const char *")] byte* port_type);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void jack_port_set_latency([NativeTypeName("jack_port_t *")] _jack_port* param0, [NativeTypeName("jack_nframes_t")] uint param1);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_port_get_latency_range([NativeTypeName("jack_port_t *")] _jack_port* port, [NativeTypeName("jack_latency_callback_mode_t")] JackLatencyCallbackMode mode, [NativeTypeName("jack_latency_range_t *")] _jack_latency_range* range);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_port_set_latency_range([NativeTypeName("jack_port_t *")] _jack_port* port, [NativeTypeName("jack_latency_callback_mode_t")] JackLatencyCallbackMode mode, [NativeTypeName("jack_latency_range_t *")] _jack_latency_range* range);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_recompute_total_latencies([NativeTypeName("jack_client_t *")] _jack_client* param0);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_nframes_t")]
        [Obsolete]
        public static extern uint jack_port_get_latency([NativeTypeName("jack_port_t *")] _jack_port* port);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_nframes_t")]
        [Obsolete]
        public static extern uint jack_port_get_total_latency([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("jack_port_t *")] _jack_port* port);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int jack_recompute_total_latency([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("jack_port_t *")] _jack_port* port);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("const char **")]
        public static extern byte** jack_get_ports([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("const char *")] byte* port_name_pattern, [NativeTypeName("const char *")] byte* type_name_pattern, [NativeTypeName("unsigned long")] nuint flags);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_port_t *")]
        public static extern _jack_port* jack_port_by_name([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("const char *")] byte* port_name);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_port_t *")]
        public static extern _jack_port* jack_port_by_id([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("jack_port_id_t")] uint port_id);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_nframes_t")]
        public static extern uint jack_frames_since_cycle_start([NativeTypeName("const jack_client_t *")] _jack_client* param0);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_nframes_t")]
        public static extern uint jack_frame_time([NativeTypeName("const jack_client_t *")] _jack_client* param0);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_nframes_t")]
        public static extern uint jack_last_frame_time([NativeTypeName("const jack_client_t *")] _jack_client* client);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_get_cycle_times([NativeTypeName("const jack_client_t *")] _jack_client* client, [NativeTypeName("jack_nframes_t *")] uint* current_frames, [NativeTypeName("jack_time_t *")] nuint* current_usecs, [NativeTypeName("jack_time_t *")] nuint* next_usecs, float* period_usecs);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_time_t")]
        public static extern nuint jack_frames_to_time([NativeTypeName("const jack_client_t *")] _jack_client* client, [NativeTypeName("jack_nframes_t")] uint param1);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_nframes_t")]
        public static extern uint jack_time_to_frames([NativeTypeName("const jack_client_t *")] _jack_client* client, [NativeTypeName("jack_time_t")] nuint param1);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_time_t")]
        public static extern nuint jack_get_time();

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_set_error_function([NativeTypeName("void (*)(const char *)")] delegate* unmanaged[Cdecl]<byte*, void> func);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_set_info_function([NativeTypeName("void (*)(const char *)")] delegate* unmanaged[Cdecl]<byte*, void> func);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_free(void* ptr);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_set_property([NativeTypeName("jack_client_t *")] _jack_client* param0, [NativeTypeName("jack_uuid_t")] nuint subject, [NativeTypeName("const char *")] byte* key, [NativeTypeName("const char *")] byte* value, [NativeTypeName("const char *")] byte* type);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_get_property([NativeTypeName("jack_uuid_t")] nuint subject, [NativeTypeName("const char *")] byte* key, [NativeTypeName("char **")] byte** value, [NativeTypeName("char **")] byte** type);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_free_description(jack_description_t* desc, int free_description_itself);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_get_properties([NativeTypeName("jack_uuid_t")] nuint subject, jack_description_t* desc);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_get_all_properties(jack_description_t** descs);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_remove_property([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("jack_uuid_t")] nuint subject, [NativeTypeName("const char *")] byte* key);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_remove_properties([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("jack_uuid_t")] nuint subject);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_remove_all_properties([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_set_property_change_callback([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("JackPropertyChangeCallback")] delegate* unmanaged[Cdecl]<nuint, byte*, jack_property_change_t, void*, void> callback, void* arg);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void* jack_port_request_monitor(void* param0, [NativeTypeName("unsigned long")] nuint param1);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_nframes_t")]
        public static extern uint jack_midi_get_event_count(void* port_buffer);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_midi_event_get([NativeTypeName("jack_midi_event_t *")] _jack_midi_event* @event, void* port_buffer, [NativeTypeName("uint32_t")] uint event_index);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_midi_clear_buffer(void* port_buffer);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint jack_midi_max_event_size(void* port_buffer);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_midi_data_t *")]
        public static extern byte* jack_midi_event_reserve(void* port_buffer, [NativeTypeName("jack_nframes_t")] uint time, [NativeTypeName("size_t")] nuint data_size);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_midi_event_write(void* port_buffer, [NativeTypeName("jack_nframes_t")] uint time, [NativeTypeName("const jack_midi_data_t *")] byte* data, [NativeTypeName("size_t")] nuint data_size);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint jack_midi_get_lost_event_count(void* port_buffer);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern jack_ringbuffer_t* jack_ringbuffer_create([NativeTypeName("size_t")] nuint sz);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_ringbuffer_free(jack_ringbuffer_t* rb);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_ringbuffer_get_read_vector([NativeTypeName("const jack_ringbuffer_t *")] jack_ringbuffer_t* rb, jack_ringbuffer_data_t* vec);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_ringbuffer_get_write_vector([NativeTypeName("const jack_ringbuffer_t *")] jack_ringbuffer_t* rb, jack_ringbuffer_data_t* vec);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint jack_ringbuffer_read(jack_ringbuffer_t* rb, [NativeTypeName("char *")] byte* dest, [NativeTypeName("size_t")] nuint cnt);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint jack_ringbuffer_peek(jack_ringbuffer_t* rb, [NativeTypeName("char *")] byte* dest, [NativeTypeName("size_t")] nuint cnt);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_ringbuffer_read_advance(jack_ringbuffer_t* rb, [NativeTypeName("size_t")] nuint cnt);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint jack_ringbuffer_read_space([NativeTypeName("const jack_ringbuffer_t *")] jack_ringbuffer_t* rb);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_ringbuffer_mlock(jack_ringbuffer_t* rb);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_ringbuffer_reset(jack_ringbuffer_t* rb);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint jack_ringbuffer_write(jack_ringbuffer_t* rb, [NativeTypeName("const char *")] byte* src, [NativeTypeName("size_t")] nuint cnt);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_ringbuffer_write_advance(jack_ringbuffer_t* rb, [NativeTypeName("size_t")] nuint cnt);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("size_t")]
        public static extern nuint jack_ringbuffer_write_space([NativeTypeName("const jack_ringbuffer_t *")] jack_ringbuffer_t* rb);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int jack_set_session_callback([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("JackSessionCallback")] delegate* unmanaged[Cdecl]<_jack_session_event*, void*, void> session_callback, void* arg);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int jack_session_reply([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("jack_session_event_t *")] _jack_session_event* @event);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void jack_session_event_free([NativeTypeName("jack_session_event_t *")] _jack_session_event* @event);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("char *")]
        public static extern byte* jack_client_get_uuid([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern jack_session_command_t* jack_session_notify([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("const char *")] byte* target, [NativeTypeName("jack_session_event_type_t")] JackSessionEventType type, [NativeTypeName("const char *")] byte* path);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void jack_session_commands_free(jack_session_command_t* cmds);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_reserve_client_name([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("const char *")] byte* name, [NativeTypeName("const char *")] byte* uuid);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern int jack_client_has_session_callback([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("const char *")] byte* client_name);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float jack_get_max_delayed_usecs([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern float jack_get_xrun_delayed_usecs([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_reset_max_delayed_usecs([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_client_real_time_priority([NativeTypeName("jack_client_t *")] _jack_client* param0);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_client_max_real_time_priority([NativeTypeName("jack_client_t *")] _jack_client* param0);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_acquire_real_time_scheduling([NativeTypeName("jack_native_thread_t")] nuint thread, int priority);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_client_create_thread([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("jack_native_thread_t *")] nuint* thread, int priority, int realtime, [NativeTypeName("void *(*)(void *)")] delegate* unmanaged[Cdecl]<void*, void*> start_routine, void* arg);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_drop_real_time_scheduling([NativeTypeName("jack_native_thread_t")] nuint thread);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_set_thread_creator([NativeTypeName("jack_thread_creator_t")] delegate* unmanaged[Cdecl]<nuint*, pthread_attr_t*, delegate* unmanaged[Cdecl]<void*, void*>, void*, int> creator);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_release_timebase([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_set_sync_callback([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("JackSyncCallback")] delegate* unmanaged[Cdecl]<jack_transport_state_t, jack_position_t*, void*, int> sync_callback, void* arg);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_set_sync_timeout([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("jack_time_t")] nuint timeout);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_set_timebase_callback([NativeTypeName("jack_client_t *")] _jack_client* client, int conditional, [NativeTypeName("JackTimebaseCallback")] delegate* unmanaged[Cdecl]<jack_transport_state_t, uint, jack_position_t*, int, void*, void> timebase_callback, void* arg);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_transport_locate([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("jack_nframes_t")] uint frame);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern jack_transport_state_t jack_transport_query([NativeTypeName("const jack_client_t *")] _jack_client* client, jack_position_t* pos);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_nframes_t")]
        public static extern uint jack_get_current_transport_frame([NativeTypeName("const jack_client_t *")] _jack_client* client);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_transport_reposition([NativeTypeName("jack_client_t *")] _jack_client* client, [NativeTypeName("const jack_position_t *")] jack_position_t* pos);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_transport_start([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_transport_stop([NativeTypeName("jack_client_t *")] _jack_client* client);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void jack_get_transport_info([NativeTypeName("jack_client_t *")] _jack_client* client, jack_transport_info_t* tinfo);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [Obsolete]
        public static extern void jack_set_transport_info([NativeTypeName("jack_client_t *")] _jack_client* client, jack_transport_info_t* tinfo);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_uuid_t")]
        public static extern nuint jack_client_uuid_generate();

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("jack_uuid_t")]
        public static extern nuint jack_port_uuid_generate([NativeTypeName("uint32_t")] uint port_id);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint jack_uuid_to_index([NativeTypeName("jack_uuid_t")] nuint param0);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_uuid_compare([NativeTypeName("jack_uuid_t")] nuint param0, [NativeTypeName("jack_uuid_t")] nuint param1);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_uuid_copy([NativeTypeName("jack_uuid_t *")] nuint* dst, [NativeTypeName("jack_uuid_t")] nuint src);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_uuid_clear([NativeTypeName("jack_uuid_t *")] nuint* param0);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_uuid_parse([NativeTypeName("const char *")] byte* buf, [NativeTypeName("jack_uuid_t *")] nuint* param1);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_uuid_unparse([NativeTypeName("jack_uuid_t")] nuint param0, [NativeTypeName("char[37]")] byte* buf);

        [DllImport("libjack", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern int jack_uuid_empty([NativeTypeName("jack_uuid_t")] nuint param0);
    }
}
