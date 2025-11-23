using crypto.Interface;
using crypto.Models;
using System.Security.Cryptography;

namespace crypto.Services.Encryptations
{
    public class AESService : IEncryptMethods
    {
        private Aes _aesChave = Aes.Create();

        public async Task<StringEncriptada> Desencriptar(StringEncriptada objeto)
        {
            throw new NotImplementedException();
        }

        public async Task<StringEncriptada> Encriptar(string input)
        {
            StringEncriptada retorno = new StringEncriptada();
            Aes aesEncriptacao = Aes.Create();
            InicializarEncriptacao();

            byte[] encriptado;

            aesEncriptacao.Key = _aesChave.Key;
            aesEncriptacao.IV = _aesChave.IV;

            ICryptoTransform cryptoTransform = aesEncriptacao.CreateEncryptor(aesEncriptacao.Key, aesEncriptacao.IV);

            MemoryStream memoryStreamEncrypt = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStreamEncrypt, cryptoTransform, CryptoStreamMode.Write);
            StreamWriter streamWriter = new StreamWriter(cryptoStream);

            await streamWriter.WriteAsync(input);
            await streamWriter.FlushAsync();
            await cryptoStream.FlushFinalBlockAsync();

            encriptado = memoryStreamEncrypt.ToArray();

            retorno.chaveDeCriptografia = Convert.ToBase64String(aesEncriptacao.Key) ?? throw new InvalidOperationException("Erro ao criar chave de encriptação");
            retorno.vetorDeInicializacao = Convert.ToBase64String(aesEncriptacao.IV) ?? throw new InvalidOperationException("Erro ao criar vetor de incialização de encriptação");
            retorno.textoEncriptado = Convert.ToBase64String(encriptado) ?? throw new InvalidOperationException("Erro ao encriptar texto");

            return retorno;
        }

        public void InicializarEncriptacao()
        {
            _aesChave.GenerateKey();
            _aesChave.GenerateIV();
        }
    }
}
