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

        [HttpPost]
        [Route("encripta-RC2")]
        public async Task<IActionResult> EncriptaRC2([FromBody] StringEncriptada objeto)
        {
            try
            {
                StringEncriptada objetoEncriptado = await _services.EncriptarRC2(objeto.textoDesencriptado);
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

        [HttpPost]
        [Route("encripta-TripleDES")]
        public async Task<IActionResult> EncriptaTripleDES([FromBody] StringEncriptada objeto)
        {
            try
            {
                StringEncriptada objetoEncriptado = await _services.EncriptarTripleDES(objeto.textoDesencriptado);
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
