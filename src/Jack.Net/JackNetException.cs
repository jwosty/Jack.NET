using System;
using JetBrains.Annotations;

namespace Jack.Net;

[PublicAPI]
public class JackNetException : Exception
{
    public JackNetException() { }

    public JackNetException(string message, Exception? innerException)
        : base(message, innerException)
    { }

    public JackNetException(string message)
        : base(message)
    { }
}
