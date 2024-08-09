namespace Jack.Net.NativeInterop
{
    [NativeTypeName("unsigned int")]
    public enum JackOptions : uint
    {
        JackNullOption = 0x00,
        JackNoStartServer = 0x01,
        JackUseExactName = 0x02,
        JackServerName = 0x04,
        JackLoadName = 0x08,
        JackLoadInit = 0x10,
        JackSessionID = 0x20,
    }
}
