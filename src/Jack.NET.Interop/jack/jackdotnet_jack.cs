using System.Runtime.InteropServices;

namespace Jack.NET.Interop
{
    public static unsafe partial class jackdotnet_jack
    {
        [DllImport("jackdotnet.so", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackdotnet_jack_client_open_0", ExactSpelling = true)]
        [return: NativeTypeName("jack_client_t *")]
        public static extern _jack_client* client_open_0([NativeTypeName("const char *")] byte* client_name, [NativeTypeName("jack_options_t")] JackOptions options, [NativeTypeName("jack_status_t *")] JackStatus* status);

        [DllImport("jackdotnet.so", CallingConvention = CallingConvention.Cdecl, EntryPoint = "jackdotnet_jack_client_open_1", ExactSpelling = true)]
        [return: NativeTypeName("jack_client_t *")]
        public static extern _jack_client* client_open_1([NativeTypeName("const char *")] byte* client_name, [NativeTypeName("jack_options_t")] JackOptions options, [NativeTypeName("jack_status_t *")] JackStatus* status, [NativeTypeName("char *")] byte* server_name);
    }
}
