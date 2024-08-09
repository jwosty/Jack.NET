namespace Jack.Net.Interop
{
    [NativeTypeName("unsigned int")]
    public enum JackSessionEventType : uint
    {
        JackSessionSave = 1,
        JackSessionSaveAndQuit = 2,
        JackSessionSaveTemplate = 3,
    }
}
