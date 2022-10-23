using Microsoft.AspNetCore.Mvc;
using ShopLife.Application.Controllers.Example.Commands;

namespace ShopLife.UI.Controllers;

/// <summary>
/// 範例Controller
/// </summary>
public class ExampleController : BaseApiController
{
    [HttpPost]
    public Task<ExampleResponse> Hello()
        => this.Mediator.Send(new ExampleRequest());
}
