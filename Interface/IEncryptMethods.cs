using crypto.Models;

namespace crypto.Interface
{
    public interface IEncryptMethods
    {
       Task<StringEncriptada> Encriptar(string input);
       void InicializarEncriptacao();
       Task<StringEncriptada> Desencriptar(StringEncriptada objeto);
    }
}
