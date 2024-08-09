using JetBrains.Annotations;
// ReSharper disable InconsistentNaming

namespace Jack.Net.Interop
{
    [PublicAPI]
    public unsafe partial struct sigset_t
    {
        private void* __val;
    }
}
