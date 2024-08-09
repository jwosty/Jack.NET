namespace Jack.Net.NativeInterop
{
    [NativeTypeName("unsigned int")]
    public enum JackSessionEventType : uint
    {
        JackSessionSave = 1,
        JackSessionSaveAndQuit = 2,
        JackSessionSaveTemplate = 3,
    }
}
