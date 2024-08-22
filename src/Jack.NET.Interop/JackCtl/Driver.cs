using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace Jack.NET.Interop.JackCtl;

[PublicAPI]
public static unsafe class Driver
{
    public static string? GetName(jackctl_driver* driver)
    {
        var strPtr = jackctl.driver_get_name(driver);
        return strPtr is null ? null : Marshal.PtrToStringUTF8((IntPtr)strPtr);
    }

    public static IImmutableList<IntPtr<jackctl_parameter>> GetParameters(jackctl_driver* driver)
    {
        var parametersRaw = jackctl.driver_get_parameters(driver);
        var parameters = ImmutableArray.CreateBuilder<IntPtr<jackctl_parameter>>();
        if (parametersRaw is not null)
        {
            foreach (var paramPtr in *parametersRaw)
            {
                parameters.Add((jackctl_parameter*)paramPtr);
            }
        }
        return parameters.ToImmutable();
    }
}
