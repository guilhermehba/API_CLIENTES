using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace clientes.Controllers
{
    public class ClienteController
    {
         [ApiController]
    [Route("[controller]")]
    public class clienteController : ControllerBase{
        private readonly ILogger<clienteController> _logger;
        private List<clientes> _clientes;

        public clienteController(ILogger<clienteController> logger){

            _logger = logger;

            _clientes = new List<clientes>();


                _clientes.Add(new clientes(1, "Guilherme", new DateTime(1998, 1, 23), "012345678900", 5000, "Homem"));
                _clientes.Add(new clientes(2, "Maria", new DateTime(2001, 1, 1), "012345678900", 2500, "Mulher"));
                _clientes.Add(new clientes(3, "Daniel", new DateTime(2002, 5, 12), "012345678900", 1250, "Homem"));
                _clientes.Add(new clientes(4, "Marcielle", new DateTime(2000, 12, 25), "012345678900", 1234, "Mulher"));
                _clientes.Add(new clientes(5, "Evellyn", new DateTime(1996, 8, 16), "012345678900", 7500, "Mulher"));

        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clientes);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var Cliente = _clientes.Where(a => a.Id == id).FirstOrDefault();

            if (Cliente == null)
            {
                //Não foi encontrado
                return NotFound(new { message = "Cliente não encontrado.", id = id });
            }

            return Ok(Cliente);
        }
    }
    }
}