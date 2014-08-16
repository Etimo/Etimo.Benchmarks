using System.Collections.Generic;
using System.Linq;
using Etimo.Benchmarks.Sample.CollectionBenchmarks.BenchmarkBase.OperationGroups;
using Etimo.Benchmarks.Sample.CollectionBenchmarks.BenchmarkBase.Operations;
using Etimo.Benchmarks.Sample.Collections;
using Etimo.Benchmarks.Sample.Data;

namespace Etimo.Benchmarks.Sample.CollectionBenchmarks.BenchmarkBase.BenchmarkComponents.KeyedCollection
{
    public class BenchmarkComponentKeyedCollection : BenchmarkComponentBase
    {
        public override string Name
        {
            get { return "KeyedCollection"; }
        }

        public BenchmarkComponentKeyedCollection(IEnumerable<CountryOrRegionGdpData> listOfCountryOrRegionGdpData)
        {
            StandardKeyedCollectionOfCountryOrRegionGdpData standardKeyedCollectionOfCountryOrRegionGdpData = new StandardKeyedCollectionOfCountryOrRegionGdpData();

            RootOperation = new CollectionBenchmarkRootOperationGroup()
            {
                Operation1 = new OperationInitialization()
                {
                    Delegate = () =>
                    {
                        foreach (var item in listOfCountryOrRegionGdpData)
                            standardKeyedCollectionOfCountryOrRegionGdpData.Add(item);
                    },
                },
                Operation2 = new OperationGetGdp2010ByCode()
                {
                    Delegate = () => standardKeyedCollectionOfCountryOrRegionGdpData["SWE500"].GdpYear2010.Value
                },
                Operation3 = new OperationGetGdp2010ByName()
                {
                    Delegate = () => standardKeyedCollectionOfCountryOrRegionGdpData.Single(q => q.CountryName == "Sweden500").GdpYear2010.Value,
                },
                Operation4 = new OperationGroupByIncrease()
                {
                    Operation1 = new OperationHasFiveDoubledCount()
                    {
                        Delegate = () => standardKeyedCollectionOfCountryOrRegionGdpData.Count(countryOrRegionGdpData => countryOrRegionGdpData.GdpYear2010 >= countryOrRegionGdpData.GdpYear1960 * 5),
                    },
                    Operation2 = new OperationHasTenDoubledCount()
                    {
                        Delegate = () => standardKeyedCollectionOfCountryOrRegionGdpData.Count(countryOrRegionGdpData => countryOrRegionGdpData.GdpYear2010 >= countryOrRegionGdpData.GdpYear1960 * 10),
                    },
                    Operation3 = new OperationHasTwentyDoubledCount()
                    {
                        Delegate = () => standardKeyedCollectionOfCountryOrRegionGdpData.Count(countryOrRegionGdpData => countryOrRegionGdpData.GdpYear2010 >= countryOrRegionGdpData.GdpYear1960 * 20),
                    },
                },
            };
        }
    }
}