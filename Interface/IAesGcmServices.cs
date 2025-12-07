using crypto.Models;

namespace crypto.Interface
{
    public interface IAesGcmServices
    {
        StringEncriptada Encriptar(string input);
        StringEncriptada Desencriptar(StringEncriptada stringEncriptada);
    }
}
