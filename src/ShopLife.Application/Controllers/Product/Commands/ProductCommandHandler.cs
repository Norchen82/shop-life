using MediatR;
using ShopLife.Application.InfraTool.Example;

namespace ShopLife.Application.Controllers.Product.Commands;
internal class ProductCommandHandler : IRequestHandler<ProductRequest, ProductResponse>
{
    /// <summary>
    /// 範例Service
    /// </summary>
    private readonly IExampleService _exampleService;

    /// <summary>
    /// 建構子注入
    /// </summary>
    public ProductCommandHandler(IExampleService exampleService)
    {
        this._exampleService = exampleService;
    }

    public async Task<ProductResponse> Handle(ProductRequest request, CancellationToken cancellationToken)
    {
        return new ProductResponse();
    }
}
