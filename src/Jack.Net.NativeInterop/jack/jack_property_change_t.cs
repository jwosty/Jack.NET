namespace Jack.Net.NativeInterop
{
    [NativeTypeName("unsigned int")]
    public enum jack_property_change_t : uint
    {
        PropertyCreated,
        PropertyChanged,
        PropertyDeleted,
    }
}
