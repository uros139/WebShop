using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enigmatry.Vendor.Models;

namespace Enigmatry.Vendor.SupplierService;
public interface ISupplierService
{
    Task<bool> ArticleInInventory(int id);
    Task<Article> GetArticle(int id);

}
