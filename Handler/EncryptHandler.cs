using crypto.Interface;

namespace crypto.Handler
{
    public class EncryptHandler : IHandlerEncryptService
    {
        public void possuiChaveDeCriptografia(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) 
            {
                throw new ArgumentException("Falha ao verificar a chave de criptografia do texto");
            }
        }

        public void possuiTextoDesencriptado(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                throw new ArgumentException("Falha ao verificar o texto desencriptografado enviado");
            }
        }

        public void possuiTextoEncriptado(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                throw new ArgumentException("Falha ao verificar texto encriptado");
            }
        }

        public void possuiVetorDeInicializacao(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                throw new ArgumentException("Falha ao verificar o vetor de inicialização");
            }
        }
    }
}
