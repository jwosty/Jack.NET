namespace Jack.Net.NativeInterop
{
    public unsafe partial struct jack_property_t
    {
        [NativeTypeName("const char *")]
        public byte* key;

        [NativeTypeName("const char *")]
        public byte* data;

        [NativeTypeName("const char *")]
        public byte* type;
    }
}
