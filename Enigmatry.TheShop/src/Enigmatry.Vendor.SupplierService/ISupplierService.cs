using Enigmatry.Vendor.Models;

namespace Enigmatry.Vendor.SupplierService;
public interface ISupplierService
{
    Task<bool> ArticleInInventory(int id);
    Task<Article> GetArticle(int id);

}
