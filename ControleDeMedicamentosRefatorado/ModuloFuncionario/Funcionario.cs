namespace ControleDeMedicamentosRefatorado
{
    public class Funcionario
    {
        public string Nome = "", Email = "", CPFFormatado = "", Cargo = "", Senha = "", Genero = "", Sobrenome = "", Saudacao = "";
        public int Idade, Matricula;

        public Funcionario(string nome, string sobrenome, string saudacao, int idade, string genero, string cpfformatado, string cargo, int matricula, string email, string senha)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Saudacao = saudacao;
            Idade = idade;
            Genero = genero;
            CPFFormatado = cpfformatado;
            Cargo = cargo;
            Matricula = matricula;
            Email = email;
            Senha = senha;
        }
    }
}
