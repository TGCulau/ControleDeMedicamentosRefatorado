namespace ControleDeMedicamentosRefatorado
{
    public class Fornecedor
    {
        public string Nome = "", Email = "", CNPJFormatado = "";
        public int Prazo;

        public Fornecedor(string nome, string cnpjformatado, string email, int prazo)
        {
            Nome = nome;
            CNPJFormatado = cnpjformatado;
            Email = email;
            Prazo = prazo;
        }
    }
}
