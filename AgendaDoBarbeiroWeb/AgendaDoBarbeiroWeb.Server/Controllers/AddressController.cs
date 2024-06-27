using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService) {
            _addressService = addressService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return Content("Get successfully made!", "text/plain");
        }

        
    }
}
