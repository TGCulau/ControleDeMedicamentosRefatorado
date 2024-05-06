namespace ControleDeMedicamentosRefatorado
{
    public class Paciente
    {
        public string Nome = "", Sobrenome = "", Email = "", CPFFormatado = "", Senha = "", Genero = "", Contato = "";
        public int Idade, CartaoSUS;

        public Paciente(string nome, string sobrenome, int idade, string genero, string cpfformatado, int cartaoSUS, string contato)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Idade = idade;
            Genero = genero;
            CPFFormatado = cpfformatado;
            CartaoSUS = cartaoSUS;
            Contato = contato;
        }
    }
}
