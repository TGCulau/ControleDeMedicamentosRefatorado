namespace ControleDeMedicamentosRefatorado
{
    public class TelaEqueleto
    {
        #region Caixa de Objetos
        TelaMensagens mensagem = new TelaMensagens();
        TelaPostinho telaPostinho = new TelaPostinho();
        TelaFuncionario telaFuncionario = new TelaFuncionario();
        TelaFornecedor telaFornecedor = new TelaFornecedor();
        TelaMedicamento telaMedicamento = new TelaMedicamento();
        TelaPaciente telaPaciente = new TelaPaciente();
        TelaProntuario telaProntuario = new TelaProntuario();
        FuncoesBasicas funcao = new FuncoesBasicas();

        public TelaLogin login = new TelaLogin();
        public TelaMedicamento medicamento = new TelaMedicamento();
        #endregion

        public void ChecagemPreLogin()
        {
            mensagem.Cabecalho();
            telaPostinho.CheckPostinho();
            telaFuncionario.CheckFuncionario();
            telaFornecedor.CheckFornecedor();
        }
        public int MenuPrincipal(int posicaoativafuncionario)
        {

            mensagem.Cabecalho();
            mensagem.Saudacao(posicaoativafuncionario);

            mensagem.AvisoParaSolicitarMaisRemédio();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\tMenu Principal");
            Console.ResetColor();
            int opmenu = funcao.LerInt("\n\n1. Novos cadastros internos\n2. Prontuario\n3. Solicitar Remedio\n4. Verficiar o Estoque\n5.Logout\n\nDigite sua opção: ");
            return opmenu;
        }
        public void NovoCadastro()
        {
            while (true)
            {
                mensagem.Cabecalho();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\tNovos cadastros internos");
                Console.ResetColor();
                int opmenucadastro = funcao.LerInt("\n\n1. Cadastrar medicamentos\n2. Cadastrar Paciente\n3. Alterar Fornecedor\n4. Voltar ao menu anterior\nSua opção: ");
                if (opmenucadastro != 1 && opmenucadastro != 2 && opmenucadastro != 3 && opmenucadastro != 4)
                {
                    mensagem.Erro();
                    continue;
                }
                switch (opmenucadastro)
                {
                    case 1:
                        telaMedicamento.Cadastro();
                        break;
                    case 2:
                        telaPaciente.Cadastro();
                        break;
                    case 3:
                        telaFornecedor.Alterar();
                        break;
                }
                break;
            }
        }
        public void MenuProntuario()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\tProntuario");
            Console.ResetColor();
            while (true)
            {
                int opmprontuario = funcao.LerInt("\n\n1. Criar prontuario\n2. Acessar e editar prontuario\nSua opção: ");
                if (opmprontuario != 1 && opmprontuario != 2)
                {
                    mensagem.Erro();
                    continue;
                }

                switch (opmprontuario)
                {
                    case 1:
                        telaProntuario.Cadastro();
                        break;

                    case 2:
                        telaProntuario.Selecionar();
                        break;
                }
                break;
            }
        }

    }
}