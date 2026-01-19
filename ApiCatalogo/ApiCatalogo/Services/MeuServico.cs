namespace ApiCatalogo.Services
{
    public class MeuServico : IMeuServico
    {
        public string Saudacao(string nome)
        {
            return $"Olá {nome}, seja bem-vindo ao nosso sistema!";
        }
    }
}
