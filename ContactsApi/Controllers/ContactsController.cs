using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IConfiguration _configuration;

        public ContactsController(ILogger<ContactsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from Contacts Controller - GET()");
        }

        [HttpPost]
        public IActionResult Post(Contact contact)
        {
            // Validation
            if (string.IsNullOrEmpty(contact.FirstName) || string.IsNullOrEmpty(contact.LastName))
            {
                return BadRequest("First and Last name are required");
            }
            return Ok("Hello " + contact.FirstName + " " + contact.LastName + " from Contacts Controller - POST()");
        }
    }
}
