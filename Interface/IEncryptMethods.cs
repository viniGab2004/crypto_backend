using crypto.Models;

namespace crypto.Interface
{
    public interface IEncryptMethods
    {
        public Task<StringEncriptada> Encriptar(string input);
        public void InicializarEncriptacao();
        public Task<StringEncriptada> Desencriptar(StringEncriptada objeto);
    }
}
