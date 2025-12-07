using crypto.Interface;
using crypto.Models;
using System.Security.Cryptography;
using System.Text;

namespace crypto.Encryptations
{
    public class AesGcmServices : IAesGcmServices
    {
        public StringEncriptada Desencriptar(StringEncriptada objeto)
        {
            throw new NotImplementedException();
        }

        public StringEncriptada Encriptar(string input)
        {
            StringEncriptada retorno = new StringEncriptada();
            byte[] _aesGcmChave = new byte[32];

            RandomNumberGenerator.Fill(_aesGcmChave);

            byte[] plainBytes = Encoding.UTF8.GetBytes(input);
            byte[] nonce = new byte[AesGcm.NonceByteSizes.MaxSize];
            byte[] tag = new byte[AesGcm.TagByteSizes.MaxSize];
            byte[] cipherByte = new byte[plainBytes.Length];

            RandomNumberGenerator.Fill(nonce);

            using var aesGcm = new AesGcm(_aesGcmChave, tag.Length);
            aesGcm.Encrypt(nonce, plainBytes, cipherByte, tag);

            byte[] combined = new byte[nonce.Length + tag.Length + cipherByte.Length];

            Buffer.BlockCopy(nonce, 0, combined, 0, nonce.Length);
            Buffer.BlockCopy(tag, 0, combined, nonce.Length, tag.Length);
            Buffer.BlockCopy(cipherByte, 0, combined, nonce.Length + tag.Length, cipherByte.Length);

            retorno.textoEncriptado = Convert.ToBase64String(combined) ?? throw new InvalidOperationException("erro ao encriptar AesGcm");
            retorno.chaveDeCriptografia = Convert.ToBase64String(_aesGcmChave) ?? throw new InvalidOperationException("erro ao gerar chave de criptografia AesGcm");

            return retorno;
        }
    }
}
