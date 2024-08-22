namespace Jack.NET.Interop
{
    public unsafe partial struct jack_ringbuffer_t
    {
        [NativeTypeName("char *")]
        public byte* buf;

        [NativeTypeName("size_t")]
        public nuint write_ptr;

        [NativeTypeName("size_t")]
        public nuint read_ptr;

        [NativeTypeName("size_t")]
        public nuint size;

        [NativeTypeName("size_t")]
        public nuint size_mask;

        public int mlocked;
    }
}
