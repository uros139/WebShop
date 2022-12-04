using Enigmatry.Vendor.Models;
using Enigmatry.Vendor.SupplierService;
using MediatR;

namespace Enigmatry.Vendor.Handlers;

public class GetArticle : IRequest<Article>
{
    public GetArticle(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}

public class GetArticleHandler : IRequestHandler<GetArticle, Article?>
{
    private readonly ISupplierService _supplierService;

    public GetArticleHandler(ISupplierService supplierService)
    {
        _supplierService = supplierService; 
    }

    public async Task<Article?> Handle(GetArticle request, CancellationToken cancellationToken)
    {
        var available = await _supplierService.ArticleInInventory(request.Id);
        if (!available) return null;

        var article = await _supplierService.GetArticle(request.Id);
        return article;

    }
}