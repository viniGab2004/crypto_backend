using crypto.Models;

namespace crypto.Interface
{
    public interface IDecryptService
    {
        Task<StringEncriptada> DesencriptarAES(StringEncriptada stringEncriptada);
        Task<StringEncriptada> DesencriptarRSA(StringEncriptada stringEncriptada);
        Task<StringEncriptada> DesencriptarTripleDES(StringEncriptada stringEncriptada);
        Task<StringEncriptada> DesencriptarRC2(StringEncriptada stringEncriptada);
        Task<StringEncriptada> DesencriptarRC4(StringEncriptada stringEncriptada);
        StringEncriptada DesencriptarAesGcm(StringEncriptada stringEncriptada);
    }
}
