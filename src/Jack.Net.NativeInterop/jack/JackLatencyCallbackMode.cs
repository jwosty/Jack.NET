namespace Jack.Net.NativeInterop
{
    [NativeTypeName("unsigned int")]
    public enum JackLatencyCallbackMode : uint
    {
        JackCaptureLatency,
        JackPlaybackLatency,
    }
}
