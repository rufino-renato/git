using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loteria.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("loteria/api/v1/[controller]")]
    public class BaseController : Controller
    {
    }
}