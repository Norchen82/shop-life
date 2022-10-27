using MediatR;

namespace ShopLife.Application.Controllers.Product.Commands;
public class ProductRequest : IRequest<ProductResponse>
{
    public int Id { get; set; }
}
