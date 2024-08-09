namespace Jack.Net.Interop
{
    [NativeTypeName("unsigned int")]
    public enum jack_transport_bits_t : uint
    {
        JackTransportState = 0x1,
        JackTransportPosition = 0x2,
        JackTransportLoop = 0x4,
        JackTransportSMPTE = 0x8,
        JackTransportBBT = 0x10,
    }
}
