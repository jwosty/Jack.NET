namespace Jack.Net.Interop
{
    [NativeTypeName("unsigned int")]
    public enum JackLatencyCallbackMode : uint
    {
        JackCaptureLatency,
        JackPlaybackLatency,
    }
}
