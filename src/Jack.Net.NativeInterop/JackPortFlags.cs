namespace Jack.Net.NativeInterop
{
    [NativeTypeName("unsigned int")]
    public enum JackPortFlags : uint
    {
        JackPortIsInput = 0x1,
        JackPortIsOutput = 0x2,
        JackPortIsPhysical = 0x4,
        JackPortCanMonitor = 0x8,
        JackPortIsTerminal = 0x10,
    }
}
