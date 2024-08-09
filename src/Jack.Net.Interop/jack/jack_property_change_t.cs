namespace Jack.Net.Interop
{
    [NativeTypeName("unsigned int")]
    public enum jack_property_change_t : uint
    {
        PropertyCreated,
        PropertyChanged,
        PropertyDeleted,
    }
}
