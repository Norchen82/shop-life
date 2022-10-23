using MediatR;
using ShopLife.Application.InfraTool.Example;

namespace ShopLife.Application.Controllers.Example.Commands;

internal class ExampleCommandHandler : IRequestHandler<ExampleRequest, ExampleResponse>
{
    /// <summary>
    /// 範例Service
    /// </summary>
    private readonly IExampleService _exampleService;

    /// <summary>
    /// 建構子注入
    /// </summary>
    public ExampleCommandHandler(IExampleService exampleService)
    {
        this._exampleService = exampleService;
    }

    public async Task<ExampleResponse> Handle(ExampleRequest request, CancellationToken cancellationToken)
    {
        ExampleVo vo = new() { Text = "Hello World!" };
        await this._exampleService.Say(vo);

        ExampleResponse result = new();
        return result;
    }
}
