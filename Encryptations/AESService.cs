using crypto.Interface;
using crypto.Models;
using System.Security.Cryptography;

namespace crypto.Encryptations
{
    public class AESService : IEncryptMethods
    {
        private Aes _aesChave = Aes.Create();

        public async Task<StringEncriptada> Desencriptar(StringEncriptada objeto)
        {
            StringEncriptada retorno = new StringEncriptada();
            string textoDesencriptado = string.Empty;
            Aes aesDesencriptado = Aes.Create();

            byte[] conteudoEncriptado = Convert.FromBase64String(objeto.textoEncriptado);
            aesDesencriptado.Key = Convert.FromBase64String(objeto.chaveDeCriptografia);
            aesDesencriptado.IV = Convert.FromBase64String(objeto.vetorDeInicializacao);

            using ICryptoTransform cryptoTransform = aesDesencriptado.CreateDecryptor(aesDesencriptado.Key, aesDesencriptado.IV);

            using MemoryStream memoryStreamDecrypt = new MemoryStream(conteudoEncriptado);
            using CryptoStream cryptoStream = new CryptoStream(memoryStreamDecrypt, cryptoTransform, CryptoStreamMode.Read);
            using StreamReader reader = new StreamReader(cryptoStream);

            textoDesencriptado = await reader.ReadToEndAsync() ?? throw new InvalidOperationException("Erro ao desencriptografar o texto");
            retorno.textoDesencriptado = textoDesencriptado;

            return retorno;
        }

        public async Task<StringEncriptada> Encriptar(string input)
        {
            StringEncriptada retorno = new StringEncriptada();
            Aes aesEncriptacao = Aes.Create();
            InicializarEncriptacao();

            byte[] encriptado;

            aesEncriptacao.Key = _aesChave.Key;
            aesEncriptacao.IV = _aesChave.IV;

            using ICryptoTransform cryptoTransform = aesEncriptacao.CreateEncryptor(aesEncriptacao.Key, aesEncriptacao.IV);

            using MemoryStream memoryStreamEncrypt = new MemoryStream();
            using CryptoStream cryptoStream = new CryptoStream(memoryStreamEncrypt, cryptoTransform, CryptoStreamMode.Write);
            using StreamWriter streamWriter = new StreamWriter(cryptoStream);

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
