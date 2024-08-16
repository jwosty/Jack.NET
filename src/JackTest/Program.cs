using System;

namespace JackTest;

using Jack.Net.Interop;
using Jack.Net.Interop.JackCtl;
using Jack.Net;

public static unsafe class Program
{
    public static void Main(string[] args)
    {
        // var client = Client.Open("foo", JackOptions.JackNullOption, out var status, null);
        var serverPtr = Server.Create();
        try
        {
            var drivers = Server.GetDriversList(serverPtr);
            Console.WriteLine("Drivers:");
            Console.WriteLine();
            foreach (var driver in drivers)
            {
                var driverName = Driver.GetName(driver);
                var driverParams = Driver.GetParameters(driver);
                Console.WriteLine("{0}:", driverName);
                foreach (var driverParam in driverParams)
                {
                    var pName = Parameter.GetName(driverParam);
                    var pType = Parameter.GetParameterType(driverParam);
                    var pValue = Parameter.GetValue(driverParam);
                    Console.WriteLine("{0} ({1}) = {2}", pName, pType, pValue);
                }
                Console.WriteLine("");
            }
        }
        finally
        {
            Server.Destroy(serverPtr);
        }
    }
}
