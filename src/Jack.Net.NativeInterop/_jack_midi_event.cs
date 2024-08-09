namespace Jack.Net.NativeInterop
{
    public unsafe partial struct _jack_midi_event
    {
        [NativeTypeName("jack_nframes_t")]
        public uint time;

        [NativeTypeName("size_t")]
        public nuint size;

        [NativeTypeName("jack_midi_data_t *")]
        public byte* buffer;
    }
}
