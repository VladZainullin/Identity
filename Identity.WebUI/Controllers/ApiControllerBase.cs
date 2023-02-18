using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Identity.WebUI.Controllers;

[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    protected IMediator Mediator => HttpContext.RequestServices.GetService<IMediator>()
                                    ??
                                    throw new NullReferenceException();
}