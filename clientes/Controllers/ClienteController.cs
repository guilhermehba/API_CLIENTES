using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using clientes.Controllers;
using System.Collections.Generic;
using System.Web;
using System.ComponentModel.DataAnnotations;


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


                _clientes.Add(new clientes(1, "Guilherme", new DateTime(1998, 1, 23), "012345678900", 5000, "H"));
                _clientes.Add(new clientes(2, "Maria", new DateTime(2001, 1, 1), "012345678900", 2500, "M"));
                _clientes.Add(new clientes(3, "Daniel", new DateTime(2002, 5, 12), "012345678900", 1250, "H"));
                _clientes.Add(new clientes(4, "Marcielle", new DateTime(2000, 12, 25), "012345678900", 1234, "M"));
                _clientes.Add(new clientes(5, "Evellyn", new DateTime(1996, 8, 16), "012345678900", 7500, "M"));

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
       
               
         /* Tentei fazer uma validação de Sexo mas não consigo identificar porque o parametro "IsValid" não funciona...  
         encontrei esse codigo de validador de M e F no stackoverflow, não é de minha autoria

         
          public class StringRangeAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(string sexo, ValidationContext validationContext)
            {

                if(sexo.ToString() == "M" || sexo.ToString() == "F")
                {
                   // return ValidationResult.Success;
                }


                return new ValidationResult("Please Use um parametro de Sexo Valido");
            }
        }
         */
        public IActionResult GetByNome(string nome){
            var Cliente = _clientes.Where(b => b.Nome == nome).FirstOrDefault();
                if (Cliente == null)
                {
                    //Nome Não Identificado
                    return NotFound(new {message = "Não foi possivel encontrar o nome requisitado"});
                }
            return Ok(Cliente);
            }
            
        //checagem de data de nascimento
        protected static bool CheckDate(DateTime dataNascimento)
            {
                if(new DateTime() == dataNascimento)      
                    return false;       
                else        
                    return true;
            }

        

       
        
    }
    
    }
    
}