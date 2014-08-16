using System.Collections.ObjectModel;
using Etimo.Benchmarks.Sample.Data;

namespace Etimo.Benchmarks.Sample.Collections
{
    public class StandardKeyedCollectionOfCountryOrRegionGdpData : KeyedCollection<string, CountryOrRegionGdpData>
    {
        protected override string GetKeyForItem(CountryOrRegionGdpData item)
        {
            return item.CountryCode;
        }
    }
}