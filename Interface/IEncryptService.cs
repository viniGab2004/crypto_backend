using crypto.Models;

namespace crypto.Interface
{
    public interface IEncryptService
    {
        Task<StringEncriptada> EncriptarAES(string texto);
        Task<StringEncriptada> DesencriptarAES(StringEncriptada stringEncriptada);
        Task<StringEncriptada> EncriptarRSA(string texto);
        Task<StringEncriptada> DesencriptarRSA(StringEncriptada stringEncriptada);
        Task<StringEncriptada> EncriptarTripleDES(string texto);
        Task<StringEncriptada> DesencriptarTripleDES(StringEncriptada stringEncriptada);
        Task<StringEncriptada> EncriptarRC2(string texto);
        Task<StringEncriptada> DesencriptarRC2(StringEncriptada stringEncriptada);
        Task<StringEncriptada> EncriptarRC4(string texto);
        Task<StringEncriptada> DesencriptarRC4(StringEncriptada stringEncriptada);
        Task<StringEncriptada> EncriptarAesGcm(string texto);
        Task<StringEncriptada> DesencriptarAesGcm(StringEncriptada stringEncriptada);
    }
}
