namespace Jack.Net.NativeInterop
{
    public unsafe partial struct jack_session_command_t
    {
        [NativeTypeName("const char *")]
        public byte* uuid;

        [NativeTypeName("const char *")]
        public byte* client_name;

        [NativeTypeName("const char *")]
        public byte* command;

        [NativeTypeName("jack_session_flags_t")]
        public JackSessionFlags flags;
    }
}
