using System;
using Jack.NET.Interop;
using JetBrains.Annotations;

namespace Jack.NET;

[PublicAPI]
public class JackStatusException : JackNetException
{
    public JackStatus Status { get; }

    public JackStatusException(string baseMessage, JackStatus status, Exception? innerException)
        : base($"{baseMessage} (status: {status})", innerException)
    {
        this.Status = status;
    }

    public JackStatusException(string baseMessage, JackStatus status)
        : base($"{baseMessage} (status: {status})")
    {
        this.Status = status;
    }
}
