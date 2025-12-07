using crypto.Models;

namespace crypto.Interface
{
    public interface IEncryptService
    {
        Task<StringEncriptada> EncriptarAES(string texto);
        Task<StringEncriptada> EncriptarRSA(string texto);
        Task<StringEncriptada> EncriptarTripleDES(string texto);
        Task<StringEncriptada> EncriptarRC2(string texto);
        Task<StringEncriptada> EncriptarRC4(string texto);
        StringEncriptada EncriptarAesGcm(string texto);
    }
}
