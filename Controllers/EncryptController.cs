using crypto.Models;
using crypto.Services;
using Microsoft.AspNetCore.Mvc;

namespace crypto.Controllers
{
    [ApiController]
    [Route("encriptar")]
    public class EncryptController : ControllerBase
    {
        private EncryptServices _services;

        public EncryptController(EncryptServices services) 
        {
            _services = services;
        }

        [HttpPost]
        [Route("encripta-AES")]
        public async Task<IActionResult> EncriptaAES([FromBody] StringEncriptada objeto) 
        {
            try
            {
                StringEncriptada objetoEncriptado = await _services.EncriptarAES(objeto.textoDesencriptado);
                return Ok(objetoEncriptado);
            }
            catch (InvalidOperationException ex) 
            {
                return StatusCode(500, ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
