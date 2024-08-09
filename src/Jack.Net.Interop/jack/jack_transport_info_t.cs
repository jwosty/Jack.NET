namespace Jack.Net.Interop
{
    public partial struct jack_transport_info_t
    {
        [NativeTypeName("jack_nframes_t")]
        public uint frame_rate;

        [NativeTypeName("jack_time_t")]
        public nuint usecs;

        public jack_transport_bits_t valid;

        public jack_transport_state_t transport_state;

        [NativeTypeName("jack_nframes_t")]
        public uint frame;

        [NativeTypeName("jack_nframes_t")]
        public uint loop_start;

        [NativeTypeName("jack_nframes_t")]
        public uint loop_end;

        [NativeTypeName("long")]
        public nint smpte_offset;

        public float smpte_frame_rate;

        public int bar;

        public int beat;

        public int tick;

        public double bar_start_tick;

        public float beats_per_bar;

        public float beat_type;

        public double ticks_per_beat;

        public double beats_per_minute;
    }
}
