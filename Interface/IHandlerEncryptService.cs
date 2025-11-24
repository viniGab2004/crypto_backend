namespace crypto.Interface
{
    public interface IHandlerEncryptService
    {
        void possuiTextoEncriptado(string texto);
        void possuiTextoDesencriptado(string texto);
        void possuiVetorDeInicializacao(string texto);
        void possuiChaveDeCriptografia(string texto);
    }
}
