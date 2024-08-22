using System.Runtime.CompilerServices;

namespace Jack.NET;

public static class InteropHelpers
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsSuccess(int errorCode) => errorCode == 0;

    public static void CheckResult(string errorMessage, int errorCode)
    {
        if (!IsSuccess(errorCode))
        {
            throw new JackException(errorMessage, errorCode);
        }
    }

    public static void CheckResult(string errorMessage, bool isSuccess)
    {
        if (!isSuccess)
        {
            throw new JackException(errorMessage);
        }
    }
}
