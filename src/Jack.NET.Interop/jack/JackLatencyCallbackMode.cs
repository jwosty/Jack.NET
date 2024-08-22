namespace Jack.NET.Interop
{
    [NativeTypeName("unsigned int")]
    public enum JackLatencyCallbackMode : uint
    {
        JackCaptureLatency,
        JackPlaybackLatency,
    }
}
