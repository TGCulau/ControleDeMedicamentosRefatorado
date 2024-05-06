namespace ControleDeMedicamentosRefatorado
{
    public class TelaLogin
    {
        #region Caixa de Objetos
        TelaMensagens mensagem = new TelaMensagens();
        public RepositorioFuncionario RFuncionario = new RepositorioFuncionario();
        #endregion

        #region Estrutura principal
        public int Login()
        {
            mensagem.Cabecalho();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\tLogin");
            Console.ResetColor();
            int usuarioativo = Email("\n\nEmail: ");
            Senha("\n\nSenha: ", usuarioativo);
            return usuarioativo;
        }
        #endregion

        #region Funções
        public int Email(string texto)
        {
            Funcionario[] funcionarios = RFuncionario.Leitura();

            while (true)
            {
                Console.Write(texto);
                string email = Console.ReadLine();
                for (int i = 0; i < funcionarios.Length; i++)
                {
                    if (email == funcionarios[i].Email)
                    {
                        return i;
                    }
                }
                mensagem.LoginErrado();
            }
        }
        public void Senha(string texto, int usuarioativo)
        {
            Funcionario[] funcionarios = RFuncionario.Leitura();
            while (true)
            {
                Console.Write(texto);
                string senha = Console.ReadLine();
                if (senha != funcionarios[usuarioativo].Senha)
                {
                    mensagem.LoginErrado();
                    continue;
                }
                break;
            }
        }
        #endregion
    }
}