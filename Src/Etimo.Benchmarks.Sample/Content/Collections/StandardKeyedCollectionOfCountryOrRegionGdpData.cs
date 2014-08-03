using System.Collections.ObjectModel;
using Etimo.Benchmarks.Sample.Content.Data;

namespace Etimo.Benchmarks.Sample.Content.Collections
{
    public class StandardKeyedCollectionOfCountryOrRegionGdpData : KeyedCollection<string, CountryOrRegionGdpData>
    {
        protected override string GetKeyForItem(CountryOrRegionGdpData item)
        {
            return item.CountryCode;
        }
    }
}