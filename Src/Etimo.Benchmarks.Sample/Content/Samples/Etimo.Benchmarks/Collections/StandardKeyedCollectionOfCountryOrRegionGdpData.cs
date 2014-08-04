using System.Collections.ObjectModel;
using Samples.Etimo.Benchmarks.Data;

namespace Samples.Etimo.Benchmarks.Collections
{
    public class StandardKeyedCollectionOfCountryOrRegionGdpData : KeyedCollection<string, CountryOrRegionGdpData>
    {
        protected override string GetKeyForItem(CountryOrRegionGdpData item)
        {
            return item.CountryCode;
        }
    }
}