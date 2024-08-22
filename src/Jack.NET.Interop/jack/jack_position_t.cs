using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Jack.NET.Interop
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct jack_position_t
    {
        [NativeTypeName("jack_unique_t")]
        public nuint unique_1;

        [NativeTypeName("jack_time_t")]
        public nuint usecs;

        [NativeTypeName("jack_nframes_t")]
        public uint frame_rate;

        [NativeTypeName("jack_nframes_t")]
        public uint frame;

        public jack_position_bits_t valid;

        [NativeTypeName("int32_t")]
        public int bar;

        [NativeTypeName("int32_t")]
        public int beat;

        [NativeTypeName("int32_t")]
        public int tick;

        public double bar_start_tick;

        public float beats_per_bar;

        public float beat_type;

        public double ticks_per_beat;

        public double beats_per_minute;

        public double frame_time;

        public double next_time;

        [NativeTypeName("jack_nframes_t")]
        public uint bbt_offset;

        public float audio_frames_per_video_frame;

        [NativeTypeName("jack_nframes_t")]
        public uint video_offset;

        public double tick_double;

        [NativeTypeName("int32_t[5]")]
        public _padding_e__FixedBuffer padding;

        [NativeTypeName("jack_unique_t")]
        public nuint unique_2;

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        [InlineArray(5)]
        public partial struct _padding_e__FixedBuffer
        {
            public int e0;
        }
    }
}
