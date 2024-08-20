using System;
using Jack.Net.Interop;

namespace JackTest;

// using Jack.Net.Interop;
// using Jack.Net.Interop.JackCtl;
using Jack.Net;

public static unsafe class Program
{
    public static void Main(string[] args)
    {
        // var client = Client.Open("foo", JackOptions.JackNullOption, out var status, null);
        using var server = Server.Create();
        var drivers = server.DriversList;
        Console.WriteLine("Drivers:");
        Console.WriteLine();
        foreach (var driver in drivers)
        {
            var driverName = driver.Name;
            var driverParams = driver.Parameters;
            Console.WriteLine("{0}:", driverName);
            foreach (var driverParam in driverParams)
            {
                // Console.WriteLine("{0}: {1} = {2}", driverParam.Name, driverParam.ParameterType, driverParam.Value);
                // Console.WriteLine("{0}: {1} ({2} / {3})", driverParam.Name, driverParam.GetType().Name, driverParam.ShortDescription, driverParam.LongDescription);
                switch (driverParam)
                {
                    case IParameter<int> tp:
                        VisitDriverParam(tp);
                        break;
                    case IParameter<uint> tp:
                        VisitDriverParam(tp);
                        break;
                    case IParameter<char> tp:
                        VisitDriverParam(tp);
                        break;
                    case IParameter<byte> tp:
                        VisitDriverParam(tp);
                        break;
                    case IParameter<string?> tp:
                        VisitDriverParam(tp);
                        break;
                }
            }
            Console.WriteLine("");
        }
    }

    private static void VisitDriverParam<T>(IParameter<T> typedParam)
    {
        Console.WriteLine("  {0} ({1}) = {2}", typedParam.Name, typedParam.ShortDescription, typedParam.BoxedValue);
        if (typedParam.TryGetRangeConstraint(out var minValue, out var maxValue))
        {
            Console.WriteLine("    RangeConstraint = {0}..{1}", minValue, maxValue);
        }
    }
}
