using System.Collections.Generic;
using Samples.Etimo.Benchmarks.Data;
using Etimo.Common.Collections.KeyedCollections;

namespace Samples.Etimo.Benchmarks.Collections
{
    public class MultiplyIndexedKeyedCollectionOfCountryOrRegionGdpData : MultiplyIndexedKeyedCollectionBase<CountryOrRegionGdpData>
    {
        public readonly IndexedMapping<string, CountryOrRegionGdpData, CountryOrRegionGdpData> ByCountryCode;
        public readonly IndexedMapping<string, CountryOrRegionGdpData, CountryOrRegionGdpData> ByCountryName;
        public readonly IndexedMapping<bool, CountryOrRegionGdpData, IEnumerable<CountryOrRegionGdpData>> ByHasFiveDoubled;
        public readonly IndexedMapping<bool, CountryOrRegionGdpData, IEnumerable<CountryOrRegionGdpData>> ByHasTenDoubled;
        public readonly IndexedMapping<bool, CountryOrRegionGdpData, IEnumerable<CountryOrRegionGdpData>> ByHasTwentyDoubled;

        public MultiplyIndexedKeyedCollectionOfCountryOrRegionGdpData()
        {
            this.ByCountryCode = CreateAndRegisterIndexedOneToOneMapping(countryOrRegionGdpData => countryOrRegionGdpData.CountryCode, null);
            this.ByCountryName = CreateAndRegisterIndexedOneToOneMapping(countryOrRegionGdpData => countryOrRegionGdpData.CountryName, EqualityComparer<string>.Default);
            this.ByHasFiveDoubled = CreateAndRegisterIndexedOneToManyMapping(countryOrRegionGdpData => countryOrRegionGdpData.GdpYear2010 >= countryOrRegionGdpData.GdpYear1960 * 5, EqualityComparer<bool>.Default);
            this.ByHasTenDoubled = CreateAndRegisterIndexedOneToManyMapping(countryOrRegionGdpData => countryOrRegionGdpData.GdpYear2010 >= countryOrRegionGdpData.GdpYear1960 * 10, EqualityComparer<bool>.Default);
            this.ByHasTwentyDoubled = CreateAndRegisterIndexedOneToManyMapping(countryOrRegionGdpData => countryOrRegionGdpData.GdpYear2010 >= countryOrRegionGdpData.GdpYear1960 * 20, EqualityComparer<bool>.Default);
        }
    }
}