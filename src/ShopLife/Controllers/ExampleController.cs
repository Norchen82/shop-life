using Microsoft.AspNetCore.Mvc;
using ShopLife.Application.CommandHandler.Example;

namespace ShopLife.Controllers;

/// <summary>
/// 範例Controller
/// </summary>
public class ExampleController : BaseApiController
{
    [HttpPost]
    public Task<ExampleResponse> Hello()
        => this.Mediator.Send(new ExampleRequest());
}
