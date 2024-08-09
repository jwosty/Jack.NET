namespace Jack.Net.Interop
{
    [NativeTypeName("unsigned int")]
    public enum JackSessionFlags : uint
    {
        JackSessionSaveError = 0x01,
        JackSessionNeedTerminal = 0x02,
    }
}
