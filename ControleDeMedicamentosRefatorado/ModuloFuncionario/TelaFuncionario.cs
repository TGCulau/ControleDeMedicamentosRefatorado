namespace ControleDeMedicamentosRefatorado
{
    public class TelaFuncionario
    {
        #region Caixa de objetos
        public RepositorioFuncionario RFuncionario = new RepositorioFuncionario();
        TelaMensagens mensagem = new TelaMensagens();
        FuncoesBasicas funcao = new FuncoesBasicas();
        FuncoesEspecificas funcaoespecifica = new FuncoesEspecificas();
        #endregion

        #region Estrutura principal
        public void Cadastro()
        {
            mensagem.Cabecalho();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\tCadastro de Funcionario");
            Console.ResetColor();
            Console.Write("\n\nNome: ");
            string nome = Console.ReadLine();
            Console.Write("\nUltimo nome: ");
            string sobrenome = Console.ReadLine();
            int idade = funcao.LerInt("\nIdade: ");
            string genero = funcaoespecifica.CheckGenero("\nGenero\n1. Homem\n2. Mulher\nSua opção: ");
            string saudacao = FuncaoSaudacao(genero, sobrenome);
            string cpfformatado = funcaoespecifica.OrganizarCPF("\nDigite o seu CPF: ");
            Console.Write("\nCargo: ");
            string cargo = Console.ReadLine();
            int matricula = funcao.LerInt("\nMatricula: ");
            Console.Write("\nEmail: ");
            string email = Console.ReadLine();
            Console.Write("\nSenha: ");
            string senha = Console.ReadLine();

            Funcionario funcionario = new Funcionario(nome, sobrenome, saudacao, idade, genero, cpfformatado, cargo, matricula, email, senha);

            RFuncionario.Salvar(funcionario);
            mensagem.CadastroComSucesso();
        }
        #endregion

        #region Funções
        public void CheckFuncionario()
        {
            bool existeInformacaoNoArquivo = RFuncionario.LeituraArquivo();
            if (existeInformacaoNoArquivo == false)
            {
                mensagem.ErroSemDadosCadastradosFuncionario();
                Console.ReadKey();
                Cadastro();
            }
        }
        public string FuncaoSaudacao(string genero, string sobrenome)
        {
            string bemvindo = "Bem-Vind", pronome = "";

            if (genero == "Homem")
            {
                bemvindo += "o";
                pronome = "Sr.";
            }
            else if (genero == "Mulher")
            {
                bemvindo += "a";
                pronome = "Sra.";
            }
            mensagem.Cabecalho();
            string saudacao = $"Seja {bemvindo} {pronome}{sobrenome}.";
            return saudacao;
        }
        #endregion
    }
}