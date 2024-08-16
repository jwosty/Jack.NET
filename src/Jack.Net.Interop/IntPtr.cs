using JetBrains.Annotations;

namespace Jack.Net.Interop;

[PublicAPI]
public readonly unsafe struct IntPtr<T> where T : unmanaged
{
    public readonly T* Handle;

    public IntPtr(T* handle)
    {
        this.Handle = handle;
    }

    public IntPtr(nint value)
    {
        this.Handle = (T*)value;
    }

    public static implicit operator IntPtr<T>(T* value) => new(value);
    public static implicit operator T*(IntPtr<T> value) => value.Handle;
    public static implicit operator void*(IntPtr<T> value) => value.Handle;

    public static explicit operator IntPtr<T>(nint value) => new((T*)value);
    public static implicit operator nint(IntPtr<T> value) => new((T*)value);
}
