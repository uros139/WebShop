using Enigmatry.Shop.Models;
using Enigmatry.Shop.VendorClient;
using Enigmatry.Shop.WareHouseService;

namespace Enigmatry.Tests;

public class BestValueUnitTest
{
    [Fact]
    public void Test1()
    {
       var cachedArticles = new Dictionary<int, Article>();
       var warehouseService = new  WareHouseService();
        IDealer1Client _firstDealerClient;
        IDealer2Client _secondDealerClient;

    }
}