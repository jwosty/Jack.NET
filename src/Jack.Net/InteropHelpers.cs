namespace Jack.Net;

public static class InteropHelpers
{
    public static void CheckResult(string errorMessage, int errorCode)
    {
        if (errorCode != 0)
        {
            throw new JackException(errorMessage, errorCode);
        }
    }

    public static bool IsSuccess(int errorCode) => errorCode != 0;
}
