using JetBrains.Annotations;
// ReSharper disable InconsistentNaming

namespace Jack.NET.Interop
{
    [PublicAPI]
    public unsafe partial struct sigset_t
    {
        private void* __val;
    }
}
