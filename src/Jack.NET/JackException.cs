using System;
using JetBrains.Annotations;

namespace Jack.NET;

[PublicAPI]
public class JackException : JackNetException
{
    public int? ErrorCode { get; }

    public JackException(string baseMessage, int? errorCode = null, Exception? innerException = null)
        : base($"{baseMessage} (error code: {errorCode})", innerException)
    {
        this.ErrorCode = errorCode;
    }

    // public JackException(string baseMessage, int errorCode)
    //     : base($"{baseMessage} (error code: {errorCode})")
    // {
    //     this.ErrorCode = errorCode;
    // }
}
