namespace Jack.NET.Interop
{
    [NativeTypeName("unsigned int")]
    public enum JackSessionFlags : uint
    {
        JackSessionSaveError = 0x01,
        JackSessionNeedTerminal = 0x02,
    }
}
