using Microsoft.AspNetCore.Mvc;

namespace IM.web1.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public abstract class BaseController : ControllerBase, IDisposable
    {
        public abstract void Dispose();
        
    }
}