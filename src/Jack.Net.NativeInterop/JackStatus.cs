namespace Jack.Net.NativeInterop
{
    [NativeTypeName("unsigned int")]
    public enum JackStatus : uint
    {
        JackFailure = 0x01,
        JackInvalidOption = 0x02,
        JackNameNotUnique = 0x04,
        JackServerStarted = 0x08,
        JackServerFailed = 0x10,
        JackServerError = 0x20,
        JackNoSuchClient = 0x40,
        JackLoadFailure = 0x80,
        JackInitFailure = 0x100,
        JackShmFailure = 0x200,
        JackVersionError = 0x400,
        JackBackendError = 0x800,
        JackClientZombie = 0x1000,
    }
}
