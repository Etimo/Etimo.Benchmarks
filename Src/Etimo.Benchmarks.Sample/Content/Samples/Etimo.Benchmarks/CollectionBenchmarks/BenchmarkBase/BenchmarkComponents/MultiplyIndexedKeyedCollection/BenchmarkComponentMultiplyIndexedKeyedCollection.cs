using System.Collections.Generic;
using System.Linq;
using Samples.Etimo.Benchmarks.CollectionBenchmarks.BenchmarkBase.OperationGroups;
using Samples.Etimo.Benchmarks.CollectionBenchmarks.BenchmarkBase.Operations;
using Samples.Etimo.Benchmarks.Collections;
using Samples.Etimo.Benchmarks.Data;

namespace Samples.Etimo.Benchmarks.CollectionBenchmarks.BenchmarkBase.BenchmarkComponents.MultiplyIndexedKeyedCollection
{
public class BenchmarkComponentMultiplyIndexedKeyedCollection : BenchmarkComponentBase
{
    public override string Name
    {
        get { return "MultiplyIndexedKeyedCollection"; }
    }

    public BenchmarkComponentMultiplyIndexedKeyedCollection(IEnumerable<CountryOrRegionGdpData> listOfCountryOrRegionGdpData)
    {
        MultiplyIndexedKeyedCollectionOfCountryOrRegionGdpData multiplyIndexedKeyedCollectionOfCountryOrRegionGdpData = new MultiplyIndexedKeyedCollectionOfCountryOrRegionGdpData();

        RootOperation = new CollectionBenchmarkRootOperationGroup()
        {
            Operation1 = new OperationInitialization()
            {
                Delegate = () =>
                {
                    foreach (var item in listOfCountryOrRegionGdpData)
                        multiplyIndexedKeyedCollectionOfCountryOrRegionGdpData.Add(item);
                },
            },
            Operation2 = new OperationGetGdp2010ByCode()
            {
                Delegate = () => multiplyIndexedKeyedCollectionOfCountryOrRegionGdpData.ByCountryCode["SWE500"].GdpYear2010.Value
            },
            Operation3 = new OperationGetGdp2010ByName()
            {
                Delegate = () => multiplyIndexedKeyedCollectionOfCountryOrRegionGdpData.ByCountryName["Sweden500"].GdpYear2010.Value,
            },
            Operation4 = new OperationGroupByIncrease()
            {
                Operation1 = new OperationHasFiveDoubledCount()
                {
                    Delegate = () => multiplyIndexedKeyedCollectionOfCountryOrRegionGdpData.ByHasFiveDoubled[true].Count(),
                },
                Operation2 = new OperationHasTenDoubledCount()
                {
                    Delegate = () => multiplyIndexedKeyedCollectionOfCountryOrRegionGdpData.ByHasTenDoubled[true].Count(),
                },
                Operation3 = new OperationHasTwentyDoubledCount()
                {
                    Delegate = () => multiplyIndexedKeyedCollectionOfCountryOrRegionGdpData.ByHasTwentyDoubled[true].Count(),
                },
            },
        };
    }
}
}