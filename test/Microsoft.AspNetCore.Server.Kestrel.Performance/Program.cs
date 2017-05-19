// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Reflection;

namespace Microsoft.AspNetCore.Server.Kestrel.Performance
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var assembly = typeof(Program).GetTypeInfo().Assembly;

            if (args.Length == 0 || args[0] != "xunit")
            {
                BenchmarkDotNet.Running.BenchmarkSwitcher.FromAssembly(assembly).Run(args);
            }
            else
            {
                using (var p = new Microsoft.Xunit.Performance.Api.XunitPerformanceHarness(args))
                {
                    p.RunBenchmarks(assembly.Location);
                }
            }
        }
    }
}
