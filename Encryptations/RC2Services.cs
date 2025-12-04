using crypto.Interface;
using System.Security.Cryptography;
using crypto.Models;

namespace crypto.Encryptations
{
    public class RC2Services : IEncryptMethods
    {
        private RC2 _rc2Chave = RC2.Create();

        public Task<StringEncriptada> Desencriptar(StringEncriptada objeto)
        {
            throw new NotImplementedException();
        }

        public async Task<StringEncriptada> Encriptar(string input)
        {
            StringEncriptada retorno = new StringEncriptada();
            RC2 rc2Encriptado = RC2.Create();
            InicializarEncriptacao();

            byte[] encriptado;

            rc2Encriptado.Key = _rc2Chave.Key;
            rc2Encriptado.IV = _rc2Chave.IV;

            ICryptoTransform cryptoTransform = rc2Encriptado.CreateEncryptor(rc2Encriptado.Key, rc2Encriptado.IV);

            using MemoryStream memoryStream = new MemoryStream();
            using CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);
            using StreamWriter streamWriter = new StreamWriter(cryptoStream);
            
            await streamWriter.WriteAsync(input);
            await streamWriter.FlushAsync();
            await cryptoStream.FlushFinalBlockAsync();

            encriptado = memoryStream.ToArray();

            retorno.vetorDeInicializacao = Convert.ToBase64String(rc2Encriptado.IV) ?? throw new InvalidOperationException("Erro ao criar vetor de inicialização");
            retorno.chaveDeCriptografia = Convert.ToBase64String(rc2Encriptado.Key) ?? throw new InvalidOperationException("Erro ao criar chave de encriptação");
            retorno.textoEncriptado = Convert.ToBase64String(encriptado) ?? throw new InvalidOperationException("Erro ao encriptar texto");

            return retorno;
        }

        public void InicializarEncriptacao()
        {
            _rc2Chave.GenerateKey();
            _rc2Chave.GenerateIV();
        }
    }
}
