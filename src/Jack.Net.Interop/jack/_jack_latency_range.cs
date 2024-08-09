namespace Jack.Net.Interop
{
    public partial struct _jack_latency_range
    {
        [NativeTypeName("jack_nframes_t")]
        public uint min;

        [NativeTypeName("jack_nframes_t")]
        public uint max;
    }
}
