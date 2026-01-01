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
        private AesGcmServices _aesGcmService;
        private RC2Services _rc2Service;
        private RC4Services _rc4Service;
        private EncryptHandler _encryptHandler;

        public EncryptServices(AESService serviceAES, EncryptHandler encryptHandler, DESService DESService, AesGcmServices aesGcmServices, RC2Services rc2Services, RC4Services rc4Services) 
        {
            _serviceAES = serviceAES;
            _trpleDESService = DESService;
            _aesGcmService = aesGcmServices;
            _encryptHandler = encryptHandler;
            _rc2Service = rc2Services;
            _rc4Service = rc4Services;
        }

        public async Task<StringEncriptada> EncriptarAES(string texto)
        {
            _encryptHandler.possuiTextoDesencriptado(texto);
            return await _serviceAES.Encriptar(texto);     
        }

        public StringEncriptada EncriptarAesGcm(string texto)
        {
            _encryptHandler.possuiTextoDesencriptado(texto);
            return _aesGcmService.Encriptar(texto);
        }

        public async Task<StringEncriptada> EncriptarRC2(string texto)
        {
            _encryptHandler.possuiTextoDesencriptado(texto);
            return await _rc2Service.Encriptar(texto);
        }

        public Task<StringEncriptada> EncriptarRC4(string texto)
        {
            _encryptHandler.possuiTextoDesencriptado(texto);
            return _rc4Service.Encriptar(texto);
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
    }
}
