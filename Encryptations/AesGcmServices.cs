using crypto.Interface;
using crypto.Models;
using System.Security.Cryptography;

namespace crypto.Encryptations
{
    public class AesGcmServices : IEncryptMethods
    {
        AesGcm _chaveAesGcm 

        public Task<StringEncriptada> Desencriptar(StringEncriptada objeto)
        {
            throw new NotImplementedException();
        }

        public Task<StringEncriptada> Encriptar(string input)
        {
            
        }

        public void InicializarEncriptacao()
        {
            throw new NotImplementedException();
        }
    }
}
