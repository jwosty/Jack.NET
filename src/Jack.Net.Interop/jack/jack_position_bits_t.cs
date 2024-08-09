namespace Jack.Net.Interop
{
    [NativeTypeName("unsigned int")]
    public enum jack_position_bits_t : uint
    {
        JackPositionBBT = 0x10,
        JackPositionTimecode = 0x20,
        JackBBTFrameOffset = 0x40,
        JackAudioVideoRatio = 0x80,
        JackVideoFrameOffset = 0x100,
        JackTickDouble = 0x200,
    }
}
