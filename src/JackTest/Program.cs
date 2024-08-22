using System;
using System.Diagnostics;
using Jack.NET.Interop;

namespace JackTest;

// using Jack.NET.Interop;
// using Jack.NET.Interop.JackCtl;
using Jack.NET;

public static unsafe class Program
{
    public static void Main(string[] args)
    {
        DumpServerInfo();
        GC.Collect();
        Console.WriteLine("== Client ==");
        using var client = Client.Open("Jack.NET Test (◪)", JackOptions.JackNullOption, out var status);
        Console.WriteLine("Client name: {0}", client.Name);
        Console.WriteLine("Done.");
    }

    private static void DumpServerInfo()
    {
        using var server = Server.Create();
        server.DeviceAcquired += (_, deviceName) =>
        {
            Console.WriteLine("Device acquired: {0}", deviceName);
        };
        server.DeviceReleased += (_, deviceName) =>
        {
            Console.WriteLine("Device released: {0}", deviceName);
        };
        Console.WriteLine("== Server ==");
        foreach (var serverParam in server.Parameters)
        {
            VisitParam(serverParam);
        }
        Console.WriteLine();
        Console.WriteLine("== Server Drivers ==");
        Console.WriteLine();
        foreach (var driver in server.DriversList)
        {
            var driverName = driver.Name;
            var driverParams = driver.Parameters;
            Console.WriteLine("{0}:", driverName);
            foreach (var driverParam in driverParams)
            {
                VisitParam(driverParam);
            }
            Console.WriteLine("");
        }
    }

    private static void VisitParam(IParameter driverParam)
    {
        switch (driverParam)
        {
            case IParameter<int> tp:
                VisitParam(tp);
                break;
            case IParameter<uint> tp:
                VisitParam(tp);
                break;
            case IParameter<char> tp:
                VisitParam(tp);
                break;
            case IParameter<bool> tp:
                VisitParam(tp);
                break;
            case IParameter<string?> tp:
                VisitParam(tp);
                break;
            default:
                throw new UnreachableException();
        }
    }

    private static void VisitParam<T>(IParameter<T> typedParam)
    {
        Console.WriteLine("  {0} ({1}) = {2}", typedParam.Name, typedParam.ShortDescription, typedParam.BoxedValue);
        if (typedParam.TryGetRangeConstraint(out var minValue, out var maxValue))
        {
            Console.WriteLine("    RangeConstraint = {0}..{1}", minValue, maxValue);
        }
    }
}
