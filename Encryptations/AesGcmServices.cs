using crypto.Interface;
using crypto.Models;
using System.Security.Cryptography;

namespace crypto.Encryptations
{
    public class AesGcmServices : IEncryptMethods
    {
        public Task<StringEncriptada> Desencriptar(StringEncriptada objeto)
        {
            throw new NotImplementedException();
        }

        public async Task<StringEncriptada> Encriptar(string input)
        {
            throw new NotImplementedException();
        }

        public void InicializarEncriptacao()
        {
            throw new NotImplementedException();
        }
    }
}
