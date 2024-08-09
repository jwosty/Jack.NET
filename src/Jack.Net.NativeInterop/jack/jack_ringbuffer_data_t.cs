namespace Jack.Net.NativeInterop
{
    public unsafe partial struct jack_ringbuffer_data_t
    {
        [NativeTypeName("char *")]
        public byte* buf;

        [NativeTypeName("size_t")]
        public nuint len;
    }
}
