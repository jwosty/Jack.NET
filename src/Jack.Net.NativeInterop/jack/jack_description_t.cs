namespace Jack.Net.NativeInterop
{
    public unsafe partial struct jack_description_t
    {
        [NativeTypeName("jack_uuid_t")]
        public nuint subject;

        [NativeTypeName("uint32_t")]
        public uint property_cnt;

        public jack_property_t* properties;

        [NativeTypeName("uint32_t")]
        public uint property_size;
    }
}
