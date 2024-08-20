using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Jack.Net.Interop
{
    [StructLayout(LayoutKind.Explicit)]
    public partial struct jackctl_parameter_value
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
        public _str_e__FixedBuffer str;

        [FieldOffset(0)]
        [NativeTypeName("_Bool")]
        public byte b;

        [InlineArray(128)]
        public partial struct _str_e__FixedBuffer
        {
            public byte e0;
        }
    }
}
