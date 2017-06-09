// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

// using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure;

namespace Microsoft.AspNetCore.Server.Kestrel.Performance
{
    [BenchmarkDotNet.Attributes.Config(typeof(CoreConfig))]
    public class StringUtilitiesBenchmark
    {
        private const int Iterations = 500; // *******************TODO******************: figure out good count; was 500_000, but that's taking a very long time

        // ***********TODO********************: This one is intended as a baseline, report the metrics as ratios to the ones from this.
        [Microsoft.Xunit.Performance.Benchmark(InnerIterationCount = Iterations)]
        public void UintToString_()
        {
            var obj = this; // new StringUtilitiesBenchmark();
            Microsoft.Xunit.Performance.Benchmark.Iterate(() => obj.UintToString());
        }
        [BenchmarkDotNet.Attributes.Benchmark(Baseline = true, OperationsPerInvoke = Iterations)]
        public void UintToString()
        {
            var connectionId = CorrelationIdGenerator.GetNextId();
            for (uint i = 0; i < Iterations; i++)
            {
                var id = connectionId + ':' + i.ToString("X8");
            }
        }

        [Microsoft.Xunit.Performance.Benchmark(InnerIterationCount = Iterations)]
        public void ConcatAsHexSuffix_()
        {
            var obj = this; // new StringUtilitiesBenchmark();
            Microsoft.Xunit.Performance.Benchmark.Iterate(() => obj.ConcatAsHexSuffix());
        }
        [BenchmarkDotNet.Attributes.Benchmark(OperationsPerInvoke = Iterations)]
        public void ConcatAsHexSuffix()
        {
            var connectionId = CorrelationIdGenerator.GetNextId();
            for (uint i = 0; i < Iterations; i++)
            {
                var id = StringUtilities.ConcatAsHexSuffix(connectionId, ':', i);
            }
        }
    }
}
