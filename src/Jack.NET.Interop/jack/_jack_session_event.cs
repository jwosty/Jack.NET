namespace Jack.NET.Interop
{
    public unsafe partial struct _jack_session_event
    {
        [NativeTypeName("jack_session_event_type_t")]
        public JackSessionEventType type;

        [NativeTypeName("const char *")]
        public byte* session_dir;

        [NativeTypeName("const char *")]
        public byte* client_uuid;

        [NativeTypeName("char *")]
        public byte* command_line;

        [NativeTypeName("jack_session_flags_t")]
        public JackSessionFlags flags;

        [NativeTypeName("uint32_t")]
        public uint future;
    }
}
