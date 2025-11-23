using crypto.Models;

namespace crypto.Interface
{
    public interface IEncryptService
    {
        public Task<StringEncriptada> EncriptarAES(string texto);
        public Task<StringEncriptada> DesencriptarAES(string texto);
        public Task<StringEncriptada> EncriptarRSA(string texto);
        public Task<StringEncriptada> DesencriptarRSA(string texto);
        public Task<StringEncriptada> EncriptarDES(string texto);
        public Task<StringEncriptada> DesencriptarDES(string texto);
        public Task<StringEncriptada> EncriptarTripleDES(string texto);
        public Task<StringEncriptada> DesencriptarTripleDES(string texto);
        public Task<StringEncriptada> EncriptarRC2(string texto);
        public Task<StringEncriptada> DesencriptarRC2(string texto);
        public Task<StringEncriptada> EncriptarRC4(string texto);
        public Task<StringEncriptada> DesencriptarRC4(string texto);
        public Task<StringEncriptada> EncriptarAesGcm(string texto);
        public Task<StringEncriptada> DesencriptarAesGcm(string texto);
    }
}
