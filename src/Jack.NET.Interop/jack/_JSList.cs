namespace Jack.NET.Interop
{
    public unsafe partial struct _JSList
    {
        public void* data;

        [NativeTypeName("JSList *")]
        public _JSList* next;
    }
}
