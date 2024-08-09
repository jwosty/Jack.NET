namespace Jack.Net.NativeInterop
{
    [NativeTypeName("unsigned int")]
    public enum JackSessionFlags : uint
    {
        JackSessionSaveError = 0x01,
        JackSessionNeedTerminal = 0x02,
    }
}
