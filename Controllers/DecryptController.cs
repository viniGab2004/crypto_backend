using crypto.Models;
using crypto.Services;
using Microsoft.AspNetCore.Mvc;

namespace crypto.Controllers
{
    [ApiController]
    [Route("desencriptar")]
    public class DecryptController : Controller
    {
        private DecryptServices _services;

        public DecryptController(DecryptServices services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("desencriptar-AES")]
        public async Task<IActionResult> DesencriptarAES([FromBody] StringEncriptada objeto)
        {
            try
            {
                StringEncriptada objetoDesencriptado = await _services.DesencriptarAES(objeto);
                return Ok(objetoDesencriptado);
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

        [HttpPost]
        [Route("desencripta-TripleDES")]
        public async Task<IActionResult> DesencriptarTripleDES([FromBody] StringEncriptada objeto)
        {
            try
            {
                StringEncriptada objetoDesencriptado = await _services.DesencriptarTripleDES(objeto);
                return Ok(objetoDesencriptado);
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

        [HttpPost]
        [Route("desencripta-RC2")]
        public async Task<IActionResult> DesencriptaRC2([FromBody] StringEncriptada objeto)
        {
            try
            {
                StringEncriptada objetoDesencriptado = await _services.DesencriptarRC2(objeto);
                return Ok(objetoDesencriptado);
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
