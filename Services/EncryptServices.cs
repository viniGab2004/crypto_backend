using crypto.Encryptations;
using crypto.Handler;
using crypto.Interface;
using crypto.Models;

namespace crypto.Services
{
    public class EncryptServices : IEncryptService
    {
        private AESService _serviceAES;
        private DESService _trpleDESService;
        private EncryptHandler _encryptHandler;

        public EncryptServices(AESService serviceAES, EncryptHandler encryptHandler, DESService DESService) 
        {
            _serviceAES = serviceAES;
            _trpleDESService = DESService;
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
            return await _serviceAES.Encriptar(texto);     
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

        public async Task<StringEncriptada> EncriptarTripleDES(string texto)
        {
            _encryptHandler.possuiTextoDesencriptado(texto);
            return await _trpleDESService.Encriptar(texto);
        }
        #endregion

    }
}
