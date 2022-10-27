using Microsoft.AspNetCore.Mvc;
using ShopLife.Application.Controllers.Product.Commands;

namespace ShopLife.UI.Controllers;

/// <summary>
/// 商品Controller
/// </summary>
public class ProductController : BaseApiController
{
    [HttpGet("product-category/{id}")]
    public Task<ProductResponse> GetList(ProductRequest request)
        => this.Mediator.Send(request);

    [HttpGet("product/{id}")]
    public Task<ProductResponse> GetItem(ProductRequest request)
        => this.Mediator.Send(request);
}