using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigmatry.Shop.VendorClient.Models;

public class GetArticleResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
}