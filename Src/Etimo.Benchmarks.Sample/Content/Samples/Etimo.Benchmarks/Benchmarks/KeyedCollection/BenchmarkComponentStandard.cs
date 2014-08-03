using System.Collections.Generic;
using System.Linq;
using Etimo.Benchmarks.Sample.Content.Benchmarks.BenchmarkBase.BenchmarkComponents;
using Etimo.Benchmarks.Sample.Content.Benchmarks.BenchmarkBase.Operations;
using Etimo.Benchmarks.Sample.Content.Collections;
using Etimo.Benchmarks.Sample.Content.Data;

namespace Etimo.Benchmarks.Sample.Content.Benchmarks.KeyedCollection
{
    public class BenchmarkComponentStandard : BenchmarkComponentBase
    {
        public override string Name
        {
            get { return "KeyedCollection"; }
        }

        public BenchmarkComponentStandard(IEnumerable<CountryOrRegionGdpData> listOfCountryOrRegionGdpData)
        {
            StandardKeyedCollectionOfCountryOrRegionGdpData standardKeyedCollectionOfCountryOrRegionGdpData = new StandardKeyedCollectionOfCountryOrRegionGdpData();
            RootOperation = new CollectionBenchmarkRootOperation()
            {
                Operation1 = new OperationInitializationBase()
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