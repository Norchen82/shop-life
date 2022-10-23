using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ShopLife.UI.Controllers;

/// <summary>
/// Api Controller 基底
/// </summary>
[ApiController]
[Route("api/[controller]/[action]")]
public class BaseApiController : ControllerBase
{
    private IMediator _mediator = null!;

    protected IMediator Mediator => _mediator ??= this.HttpContext.RequestServices.GetRequiredService<IMediator>();
}
