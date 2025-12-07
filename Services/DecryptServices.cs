using crypto.Encryptations;
using crypto.Handler;
using crypto.Interface;
using crypto.Models;

namespace crypto.Services
{
    public class DecryptServices: IDecryptService
    {
        private AESService _serviceAES;
        private DESService _trpleDESService;
        private AesGcmServices _aesGcmService;
        private RC2Services _rc2Service;
        private EncryptHandler _encryptHandler;

        public DecryptServices(AESService serviceAES, EncryptHandler encryptHandler, DESService DESService, AesGcmServices aesGcmServices, RC2Services rc2Services)
        {
            _serviceAES = serviceAES;
            _trpleDESService = DESService;
            _aesGcmService = aesGcmServices;
            _encryptHandler = encryptHandler;
            _rc2Service = rc2Services;
        }

        public async Task<StringEncriptada> DesencriptarAES(StringEncriptada stringEncriptada)
        {
            _encryptHandler.possuiTextoEncriptado(stringEncriptada.textoEncriptado);
            _encryptHandler.possuiChaveDeCriptografia(stringEncriptada.chaveDeCriptografia);
            _encryptHandler.possuiVetorDeInicializacao(stringEncriptada.vetorDeInicializacao);
            return await _serviceAES.Desencriptar(stringEncriptada);
        }

        public StringEncriptada DesencriptarAesGcm(StringEncriptada stringEncriptada)
        {
            throw new NotImplementedException();
        }

        public async Task<StringEncriptada> DesencriptarRC2(StringEncriptada stringEncriptada)
        {
            _encryptHandler.possuiTextoEncriptado(stringEncriptada.textoEncriptado);
            _encryptHandler.possuiChaveDeCriptografia(stringEncriptada.chaveDeCriptografia);
            _encryptHandler.possuiVetorDeInicializacao(stringEncriptada.vetorDeInicializacao);
            return await _rc2Service.Desencriptar(stringEncriptada);
        }

        public Task<StringEncriptada> DesencriptarRC4(StringEncriptada stringEncriptada)
        {
            throw new NotImplementedException();
        }

        public Task<StringEncriptada> DesencriptarRSA(StringEncriptada stringEncriptada)
        {
            throw new NotImplementedException();
        }

        public async Task<StringEncriptada> DesencriptarTripleDES(StringEncriptada stringEncriptada)
        {
            _encryptHandler.possuiTextoEncriptado(stringEncriptada.textoEncriptado);
            _encryptHandler.possuiChaveDeCriptografia(stringEncriptada.chaveDeCriptografia);
            _encryptHandler.possuiVetorDeInicializacao(stringEncriptada.vetorDeInicializacao);
            return await _trpleDESService.Desencriptar(stringEncriptada);
        }
    }
}
