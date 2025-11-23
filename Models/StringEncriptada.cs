namespace crypto.Models
{
    public class StringEncriptada
    {
        public string textoDesencriptado { get; set; } = string.Empty;
        public string textoEncriptado { get; set; } = string.Empty;
        public string chaveDeCriptografia { get; set; } = string.Empty;
        public string vetorDeInicializacao { get; set; } = string.Empty;
    }
}
