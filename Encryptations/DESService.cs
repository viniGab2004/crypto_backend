using crypto.Interface;
using crypto.Models;
using System.Security.Cryptography;

namespace crypto.Encryptations
{
    public class DESService : IEncryptMethods
    {
        private TripleDES _chaveTripleDES = TripleDES.Create();

        public Task<StringEncriptada> Desencriptar(StringEncriptada objeto)
        {
            throw new NotImplementedException();
        }

        public async Task<StringEncriptada> Encriptar(string input)
        {
            StringEncriptada retorno = new StringEncriptada();
            TripleDES tripleDESEncriptado = TripleDES.Create();
            InicializarEncriptacao();

            byte[] encriptado;

            tripleDESEncriptado.Key = _chaveTripleDES.Key;
            tripleDESEncriptado.IV = _chaveTripleDES.IV;

            using ICryptoTransform cryptoTransform = tripleDESEncriptado.CreateEncryptor(tripleDESEncriptado.Key, tripleDESEncriptado.IV);
            using MemoryStream memoryStreamEncrypt = new MemoryStream();
            using CryptoStream cryptoStream = new CryptoStream(memoryStreamEncrypt, cryptoTransform, CryptoStreamMode.Write);
            using StreamWriter streamWriter = new StreamWriter(cryptoStream);

            await streamWriter.WriteAsync(input);
            await streamWriter.FlushAsync();
            await cryptoStream.FlushFinalBlockAsync();

            encriptado = memoryStreamEncrypt.ToArray();

            retorno.chaveDeCriptografia = Convert.ToBase64String(tripleDESEncriptado.Key) ?? throw new InvalidOperationException("Erro ao criar chave de encriptação");
            retorno.vetorDeInicializacao = Convert.ToBase64String(tripleDESEncriptado.IV) ?? throw new InvalidOperationException("Erro ao criar vetor de incialização de encriptação");
            retorno.textoEncriptado = Convert.ToBase64String(encriptado) ?? throw new InvalidOperationException("Erro ao encriptar texto");

            return retorno;
        }

        public void InicializarEncriptacao()
        {
            _chaveTripleDES.GenerateKey();
            _chaveTripleDES.GenerateIV();
        }
    }
}
