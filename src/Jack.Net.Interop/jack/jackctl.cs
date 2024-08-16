using System.Runtime.InteropServices;

namespace Jack.Net.Interop
{
    public static unsafe partial class jackctl
    {
        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_setup_signals", ExactSpelling = true)]
        public static extern sigset_t setup_signals([NativeTypeName("unsigned int")] uint flags);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_wait_signals", ExactSpelling = true)]
        public static extern void wait_signals(sigset_t signals);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_server_create", ExactSpelling = true)]
        [return: NativeTypeName("jackctl_server_t *")]
        public static extern jackctl_server* server_create([NativeTypeName("_Bool (*)(const char *)")] delegate* unmanaged[Cdecl]<byte*, byte> on_device_acquire, [NativeTypeName("void (*)(const char *)")] delegate* unmanaged[Cdecl]<byte*, void> on_device_release);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_server_destroy", ExactSpelling = true)]
        public static extern void server_destroy([NativeTypeName("jackctl_server_t *")] jackctl_server* server);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_server_start", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte server_start([NativeTypeName("jackctl_server_t *")] jackctl_server* server, [NativeTypeName("jackctl_driver_t *")] jackctl_driver* driver);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_server_stop", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte server_stop([NativeTypeName("jackctl_server_t *")] jackctl_server* server);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_server_get_drivers_list", ExactSpelling = true)]
        [return: NativeTypeName("const JSList *")]
        public static extern _JSList* server_get_drivers_list([NativeTypeName("jackctl_server_t *")] jackctl_server* server);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_server_get_parameters", ExactSpelling = true)]
        [return: NativeTypeName("const JSList *")]
        public static extern _JSList* server_get_parameters([NativeTypeName("jackctl_server_t *")] jackctl_server* server);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_server_get_internals_list", ExactSpelling = true)]
        [return: NativeTypeName("const JSList *")]
        public static extern _JSList* server_get_internals_list([NativeTypeName("jackctl_server_t *")] jackctl_server* server);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_server_load_internal", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte server_load_internal([NativeTypeName("jackctl_server_t *")] jackctl_server* server, [NativeTypeName("jackctl_internal_t *")] jackctl_internal* @internal);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_server_unload_internal", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte server_unload_internal([NativeTypeName("jackctl_server_t *")] jackctl_server* server, [NativeTypeName("jackctl_internal_t *")] jackctl_internal* @internal);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_server_add_slave", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte server_add_slave([NativeTypeName("jackctl_server_t *")] jackctl_server* server, [NativeTypeName("jackctl_driver_t *")] jackctl_driver* driver);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_server_remove_slave", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte server_remove_slave([NativeTypeName("jackctl_server_t *")] jackctl_server* server, [NativeTypeName("jackctl_driver_t *")] jackctl_driver* driver);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_server_switch_master", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte server_switch_master([NativeTypeName("jackctl_server_t *")] jackctl_server* server, [NativeTypeName("jackctl_driver_t *")] jackctl_driver* driver);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_driver_get_name", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* driver_get_name([NativeTypeName("jackctl_driver_t *")] jackctl_driver* driver);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_driver_get_parameters", ExactSpelling = true)]
        [return: NativeTypeName("const JSList *")]
        public static extern _JSList* driver_get_parameters([NativeTypeName("jackctl_driver_t *")] jackctl_driver* driver);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_internal_get_name", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* internal_get_name([NativeTypeName("jackctl_internal_t *")] jackctl_internal* @internal);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_internal_get_parameters", ExactSpelling = true)]
        [return: NativeTypeName("const JSList *")]
        public static extern _JSList* internal_get_parameters([NativeTypeName("jackctl_internal_t *")] jackctl_internal* @internal);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_parameter_get_name", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* parameter_get_name([NativeTypeName("jackctl_parameter_t *")] jackctl_parameter* parameter);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_parameter_get_short_description", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* parameter_get_short_description([NativeTypeName("jackctl_parameter_t *")] jackctl_parameter* parameter);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_parameter_get_long_description", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* parameter_get_long_description([NativeTypeName("jackctl_parameter_t *")] jackctl_parameter* parameter);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_parameter_get_type", ExactSpelling = true)]
        public static extern jackctl_param_type_t parameter_get_type([NativeTypeName("jackctl_parameter_t *")] jackctl_parameter* parameter);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_parameter_get_id", ExactSpelling = true)]
        [return: NativeTypeName("char")]
        public static extern byte parameter_get_id([NativeTypeName("jackctl_parameter_t *")] jackctl_parameter* parameter);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_parameter_is_set", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte parameter_is_set([NativeTypeName("jackctl_parameter_t *")] jackctl_parameter* parameter);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_parameter_reset", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte parameter_reset([NativeTypeName("jackctl_parameter_t *")] jackctl_parameter* parameter);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_parameter_get_value", ExactSpelling = true)]
        [return: NativeTypeName("union jackctl_parameter_value")]
        public static extern jackctl_parameter_value parameter_get_value([NativeTypeName("jackctl_parameter_t *")] jackctl_parameter* parameter);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_parameter_set_value", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte parameter_set_value([NativeTypeName("jackctl_parameter_t *")] jackctl_parameter* parameter, [NativeTypeName("const union jackctl_parameter_value *")] jackctl_parameter_value* value_ptr);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_parameter_get_default_value", ExactSpelling = true)]
        [return: NativeTypeName("union jackctl_parameter_value")]
        public static extern jackctl_parameter_value parameter_get_default_value([NativeTypeName("jackctl_parameter_t *")] jackctl_parameter* parameter);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_parameter_has_range_constraint", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte parameter_has_range_constraint([NativeTypeName("jackctl_parameter_t *")] jackctl_parameter* parameter);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_parameter_has_enum_constraint", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte parameter_has_enum_constraint([NativeTypeName("jackctl_parameter_t *")] jackctl_parameter* parameter);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_parameter_get_enum_constraints_count", ExactSpelling = true)]
        [return: NativeTypeName("uint32_t")]
        public static extern uint parameter_get_enum_constraints_count([NativeTypeName("jackctl_parameter_t *")] jackctl_parameter* parameter);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_parameter_get_enum_constraint_value", ExactSpelling = true)]
        [return: NativeTypeName("union jackctl_parameter_value")]
        public static extern jackctl_parameter_value parameter_get_enum_constraint_value([NativeTypeName("jackctl_parameter_t *")] jackctl_parameter* parameter, [NativeTypeName("uint32_t")] uint index);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_parameter_get_enum_constraint_description", ExactSpelling = true)]
        [return: NativeTypeName("const char *")]
        public static extern byte* parameter_get_enum_constraint_description([NativeTypeName("jackctl_parameter_t *")] jackctl_parameter* parameter, [NativeTypeName("uint32_t")] uint index);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_parameter_get_range_constraint", ExactSpelling = true)]
        public static extern void parameter_get_range_constraint([NativeTypeName("jackctl_parameter_t *")] jackctl_parameter* parameter, [NativeTypeName("union jackctl_parameter_value *")] jackctl_parameter_value* min_ptr, [NativeTypeName("union jackctl_parameter_value *")] jackctl_parameter_value* max_ptr);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_parameter_constraint_is_strict", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte parameter_constraint_is_strict([NativeTypeName("jackctl_parameter_t *")] jackctl_parameter* parameter);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackctl_parameter_constraint_is_fake_value", ExactSpelling = true)]
        [return: NativeTypeName("_Bool")]
        public static extern byte parameter_constraint_is_fake_value([NativeTypeName("jackctl_parameter_t *")] jackctl_parameter* parameter);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_error([NativeTypeName("const char *")] byte* format, __arglist);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_info([NativeTypeName("const char *")] byte* format, __arglist);

        [DllImport("libjackserver.so.0", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void jack_log([NativeTypeName("const char *")] byte* format, __arglist);
    }
}
