using crypto.Interface;
using crypto.Models;
using crypto.Services.Encryptations;

namespace crypto.Services
{
    public class EncryptServices : IEncryptService
    {
        private readonly AESService _serviceAES;

        public EncryptServices(AESService serviceAES) 
        {
            _serviceAES = serviceAES;
        }

        #region [ DESENCRIPTAÇÕES ]
        public Task<StringEncriptada> DesencriptarAES(string texto)
        {
            throw new NotImplementedException();
        }

        public Task<StringEncriptada> DesencriptarAesGcm(string texto)
        {
            throw new NotImplementedException();
        }

        public Task<StringEncriptada> DesencriptarDES(string texto)
        {
            throw new NotImplementedException();
        }

        public Task<StringEncriptada> DesencriptarRC2(string texto)
        {
            throw new NotImplementedException();
        }

        public Task<StringEncriptada> DesencriptarRC4(string texto)
        {
            throw new NotImplementedException();
        }

        public Task<StringEncriptada> DesencriptarRSA(string texto)
        {
            throw new NotImplementedException();
        }

        public Task<StringEncriptada> DesencriptarTripleDES(string texto)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region [ ENCRIPTAÇÕES ]
        public async Task<StringEncriptada> EncriptarAES(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                throw new ArgumentException("O texto enviado é inválido!");
            }
            else 
            {
                StringEncriptada response = await _serviceAES.Encriptar(texto);
                return response;
            }
        }

        public Task<StringEncriptada> EncriptarAesGcm(string texto)
        {
            throw new NotImplementedException();
        }

        public Task<StringEncriptada> EncriptarDES(string texto)
        {
            throw new NotImplementedException();
        }

        public Task<StringEncriptada> EncriptarRC2(string texto)
        {
            throw new NotImplementedException();
        }

        public Task<StringEncriptada> EncriptarRC4(string texto)
        {
            throw new NotImplementedException();
        }

        public Task<StringEncriptada> EncriptarRSA(string texto)
        {
            throw new NotImplementedException();
        }

        public Task<StringEncriptada> EncriptarTripleDES(string texto)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
