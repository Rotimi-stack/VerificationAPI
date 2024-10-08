﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VerificationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : Controller
    {
       
       private IMediator _mediator;
       protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        
    }
}
