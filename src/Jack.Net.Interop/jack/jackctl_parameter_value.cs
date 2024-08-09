using System.Runtime.InteropServices;

namespace Jack.Net.Interop
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe partial struct jackctl_parameter_value
    {
        [FieldOffset(0)]
        [NativeTypeName("uint32_t")]
        public uint ui;

        [FieldOffset(0)]
        [NativeTypeName("int32_t")]
        public int i;

        [FieldOffset(0)]
        [NativeTypeName("char")]
        public byte c;

        [FieldOffset(0)]
        [NativeTypeName("char[128]")]
        public fixed byte str[128];

        [FieldOffset(0)]
        [NativeTypeName("_Bool")]
        public byte b;
    }
}
