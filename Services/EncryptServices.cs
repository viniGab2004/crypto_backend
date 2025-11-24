using crypto.Handler;
using crypto.Interface;
using crypto.Models;
using crypto.Services.Encryptations;

namespace crypto.Services
{
    public class EncryptServices : IEncryptService
    {
        private AESService _serviceAES;
        private EncryptHandler _encryptHandler;

        public EncryptServices(AESService serviceAES, EncryptHandler encryptHandler) 
        {
            _serviceAES = serviceAES;
            _encryptHandler = encryptHandler;
        }

        #region [ DESENCRIPTAÇÕES ]
        public async Task<StringEncriptada> DesencriptarAES(StringEncriptada stringEncriptada)
        {
            _encryptHandler.possuiTextoEncriptado(stringEncriptada.textoEncriptado);
            _encryptHandler.possuiChaveDeCriptografia(stringEncriptada.chaveDeCriptografia);
            _encryptHandler.possuiVetorDeInicializacao(stringEncriptada.vetorDeInicializacao);
            StringEncriptada response = await _serviceAES.Desencriptar(stringEncriptada);
            return response;
        }

        public Task<StringEncriptada> DesencriptarAesGcm(string texto)
        {
            throw new NotImplementedException();
        }

        public Task<StringEncriptada> DesencriptarAesGcm(StringEncriptada stringEncriptada)
        {
            throw new NotImplementedException();
        }

        public Task<StringEncriptada> DesencriptarDES(string texto)
        {
            throw new NotImplementedException();
        }

        public Task<StringEncriptada> DesencriptarDES(StringEncriptada stringEncriptada)
        {
            throw new NotImplementedException();
        }

        public Task<StringEncriptada> DesencriptarRC2(string texto)
        {
            throw new NotImplementedException();
        }

        public Task<StringEncriptada> DesencriptarRC2(StringEncriptada stringEncriptada)
        {
            throw new NotImplementedException();
        }

        public Task<StringEncriptada> DesencriptarRC4(string texto)
        {
            throw new NotImplementedException();
        }

        public Task<StringEncriptada> DesencriptarRC4(StringEncriptada stringEncriptada)
        {
            throw new NotImplementedException();
        }

        public Task<StringEncriptada> DesencriptarRSA(string texto)
        {
            throw new NotImplementedException();
        }

        public Task<StringEncriptada> DesencriptarRSA(StringEncriptada stringEncriptada)
        {
            throw new NotImplementedException();
        }

        public Task<StringEncriptada> DesencriptarTripleDES(string texto)
        {
            throw new NotImplementedException();
        }

        public Task<StringEncriptada> DesencriptarTripleDES(StringEncriptada stringEncriptada)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region [ ENCRIPTAÇÕES ]
        public async Task<StringEncriptada> EncriptarAES(string texto)
        {
            _encryptHandler.possuiTextoDesencriptado(texto);
            StringEncriptada response = await _serviceAES.Encriptar(texto);
            return response;
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
