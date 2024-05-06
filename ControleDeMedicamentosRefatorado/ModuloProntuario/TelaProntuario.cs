namespace ControleDeMedicamentosRefatorado
{
    public class TelaProntuario
    {
        #region Caixa de objetos
        public RepositorioProntuario RProntuario = new RepositorioProntuario();
        public RepositorioPaciente RPaciente = new RepositorioPaciente();
        public RepositorioReceita RReceita = new RepositorioReceita();

        private int numerodoprontuario = -1;

        TelaMensagens telaMensagem = new TelaMensagens();
        TelaPaciente telaPaciente = new TelaPaciente();
        TelaReceita telaReceita = new TelaReceita();
        FuncoesBasicas funcao = new FuncoesBasicas();
        FuncoesEspecificas funcaoespecifica = new FuncoesEspecificas();
        #endregion

        #region Estrutura principal
        public void Cadastro()
        {
            int numerodoprontuario = NovoProntuario();
            AdicionarReceita(numerodoprontuario);
        }
        #endregion

        #region Função
        public int NovoProntuario()
        {
            telaMensagem.Cabecalho();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\tNovo Prontuario");
            Console.ResetColor();

            numerodoprontuario++;

            Prontuario[] prontuario = RProntuario.Leitura();
            prontuario[numerodoprontuario].NumeroDoProntuario = numerodoprontuario;
            Console.Write($"\nO sistema gerou um numero automático para o prontuario. O numero deste prontuário é {prontuario[numerodoprontuario].NumeroDoProntuario}");

            Paciente[] pacientes = RPaciente.Leitura();

            int cont = 0;
            for (int i = 0; i < pacientes.Length; i++)
            {
                if (pacientes[i].Nome == null)
                {
                    cont++;
                }
            }
            if (cont == pacientes.Length)
            {
                Console.Write("\nNenhum paciente cadastrado ainda, você será redirecionado ao cadastro de paciente e depois será retornado a esta pagina. Precione qualquer tecla para continuar.");
                Console.ReadKey();
                telaPaciente.Cadastro();
            }


            Console.Write("\nEscolha qual paciente você quer adiconar a este prontuario\n\n");
            for (int i = 0; i <= pacientes.Length; i++)
            {
                Console.Write($"\t| ID {i} | Nome do paciente {pacientes[i].Nome} |\n");
            }
            int opprontuario = funcao.LerInt("\nDigite o ID correspondente: ");
            prontuario[numerodoprontuario].paciente = pacientes[opprontuario];

            RProntuario.Salvar(prontuario[numerodoprontuario]);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\tPaciente adicionado com sucesso. Precione qualquer tecla para continuar");
            Console.ReadKey();
            int aux = prontuario[numerodoprontuario].NumeroDoProntuario;
            return aux;
        }
        public void Selecionar()
        {
            if (numerodoprontuario < 0)
            {
                Console.Write("\nNenhum prontuario cadastrado ainda, você será redirecionado ao cadastro de prontuario e depois será retornado a esta pagina. Precione qualquer tecla para continuar.");
                Console.ReadKey();
                NovoProntuario();
            }
            Prontuario[] prontuario = RProntuario.Leitura();
            int ideditarprontuario = 0;
            while (true)
            {
                Console.Write("\nEscolha qual ID de prontuario você quer editar\n\n");
                for (int i = 0; i <= prontuario.Length; i++)
                {
                    Console.Write($"\t| ID {i} | Nome do paciente do prontuario {prontuario[i].paciente.Nome} | Numero do prontuario {prontuario[i].NumeroDoProntuario} |\n");
                }

                ideditarprontuario = funcao.LerInt("\nSua opção: ");
                if (prontuario.Length < ideditarprontuario && prontuario.Length > ideditarprontuario)
                {
                    telaMensagem.Erro();
                    continue;
                }
                break;
            }
            Editar(ideditarprontuario);
        }
        public void Editar(int ideditarprontuario)
        {
            while (true)
            {
                int opeditarprontuario = funcao.LerInt("\nEscolha qual campo você quer editar?\n1. Dados do paciente\n2. Dados da receita\nSua opção: ");
                if (opeditarprontuario != 1 && opeditarprontuario != 2)
                {
                    telaMensagem.Erro();
                    continue;
                }

                Console.Write("\n\nEscolha qual campo você deseja alterar");

                Prontuario[] prontuario = RProntuario.Leitura();

                switch (opeditarprontuario)
                {
                    case 1:
                        int opsubmenu = funcao.LerInt("\n1. Nome\n2. Ultimo nome\n3. Idade\n4. Genero\n5. CPF\n6. Cartão SUS\n7. Contato");
                        switch (opsubmenu)
                        {
                            case 1:
                                Console.Write($"\nNome atualmente cadastrado: {prontuario[ideditarprontuario].paciente.Nome}.\nDigite o novo nome: ");
                                prontuario[ideditarprontuario].paciente.Nome = Console.ReadLine();
                                telaMensagem.AlteracaoEfetuadaComSucesso();
                                break;

                            case 2:
                                Console.Write($"\nSobrenome atualmente cadastrado: {prontuario[ideditarprontuario].paciente.Sobrenome}.\nDigite o novo sobrenome: ");
                                prontuario[ideditarprontuario].paciente.Sobrenome = Console.ReadLine();
                                telaMensagem.AlteracaoEfetuadaComSucesso();
                                break;

                            case 3:
                                Console.Write($"\nIdade atualmente cadastrado: {prontuario[ideditarprontuario].paciente.Idade}.\nDigite a nova idade: ");
                                prontuario[ideditarprontuario].paciente.Idade = Convert.ToInt32(Console.ReadLine());
                                telaMensagem.AlteracaoEfetuadaComSucesso();
                                break;

                            case 4:
                                Console.Write($"\nGenero atualmente cadastrado: {prontuario[ideditarprontuario].paciente.Genero}.");
                                string genero = funcaoespecifica.CheckGenero("\nEscolha o novo genero a ser cadastrado:\n1. Homem\n2. Mulher\nSua opção: ");
                                prontuario[ideditarprontuario].paciente.Genero = genero;
                                telaMensagem.AlteracaoEfetuadaComSucesso();
                                break;

                            case 5:
                                Console.Write($"\nCPF atualmente cadastrado: {prontuario[ideditarprontuario].paciente.CPFFormatado}.\n");
                                string cpfformatado = funcaoespecifica.OrganizarCPF("\nDigite o novo CPF: ");
                                prontuario[ideditarprontuario].paciente.CPFFormatado = cpfformatado;
                                telaMensagem.AlteracaoEfetuadaComSucesso();
                                break;

                            case 6:
                                Console.Write($"\nCartão SUS atualmente cadastrado: {prontuario[ideditarprontuario].paciente.CartaoSUS}.\nDigite o novo numero do cartão SUS (apenas numeros): ");
                                prontuario[ideditarprontuario].paciente.CartaoSUS = Convert.ToInt32(Console.ReadLine());
                                telaMensagem.AlteracaoEfetuadaComSucesso();
                                break;

                            case 7:
                                Console.Write($"\nContato atualmente cadastrado: {prontuario[ideditarprontuario].paciente.Contato}.");
                                string contato = telaPaciente.ContatoDoPaciente();
                                prontuario[ideditarprontuario].paciente.Contato = contato;
                                telaMensagem.AlteracaoEfetuadaComSucesso();
                                break;

                        }
                        break;

                    case 2:
                        opsubmenu = funcao.LerInt("\n1. Nome do medicamento\n2. Nome do médico\n3. Tipo de medicamento\n4. Controlado\n5. Dosagem\n6. Data da receita");
                        switch (opsubmenu)
                        {
                            case 1:
                                Console.Write($"\nNome do medicamento atualmente cadastrado: {prontuario[ideditarprontuario].receita.NomeDoRemedio}.\nDigite o novo nome: ");
                                prontuario[ideditarprontuario].receita.NomeDoRemedio = Console.ReadLine();
                                telaMensagem.AlteracaoEfetuadaComSucesso();
                                break;

                            case 2:
                                Console.Write($"\nNome do médico atualmente cadastrado: {prontuario[ideditarprontuario].receita.NomeDoMedico}.\nDigite o novo nome: ");
                                prontuario[ideditarprontuario].receita.NomeDoMedico = Console.ReadLine();
                                telaMensagem.AlteracaoEfetuadaComSucesso();
                                break;

                            case 3:
                                Console.Write($"\nO atual tipo de medicamento cadastrado é: {prontuario[ideditarprontuario].receita.Tipo}.\nDigite o novo tipo de medicamento: ");
                                prontuario[ideditarprontuario].receita.NomeDoMedico = Console.ReadLine();
                                telaMensagem.AlteracaoEfetuadaComSucesso();
                                break;

                            case 4:
                                bool eControlado = prontuario[ideditarprontuario].receita.EControlado;
                                Console.Write($"\nAtualmente o status do medicamento é de que ele ");
                                telaMensagem.RemedioEControlado(eControlado);
                                Console.Write("\nEscolha o novo status desejado");
                                eControlado = funcaoespecifica.RemedioEControlado("\n1. Controlado\n2. Não Controlado\nSua opção: ");

                                prontuario[ideditarprontuario].receita.NomeDoMedico = Console.ReadLine();
                                telaMensagem.AlteracaoEfetuadaComSucesso();
                                break;

                            case 5:
                                Console.Write($"\nAtualmente a dosagem total é de {prontuario[ideditarprontuario].receita.QuantidadeDeComprimidosTotais}.\nPrecione qualquer tecla para cadastrar a nova dose.");
                                Console.ReadKey();
                                prontuario[ideditarprontuario].receita.QuantidadeDeComprimidosTotais = telaReceita.CalculoDeComprimidos();
                                break;

                            case 6:
                                Console.Write($"\nA data atual cadastrada é: {prontuario[ideditarprontuario].receita.DataFormatada}.\nDigite o novo tipo de medicamento: ");
                                prontuario[ideditarprontuario].receita.NomeDoMedico = Console.ReadLine();
                                telaMensagem.AlteracaoEfetuadaComSucesso();
                                break;
                        }
                        break;
                }
                break;
            }
        }
        public void AdicionarReceita(int numerodoprontuario)
        {
            telaReceita.Cadastro();
            Receita[] receita = RReceita.Leitura();
            Prontuario[] prontuario = RProntuario.Leitura();

            prontuario[numerodoprontuario].receita = receita[numerodoprontuario];

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\tReceita adicionada com sucesso. Precione qualquer tecla para continuar");
            Console.ResetColor();
            Console.ReadKey();
        }
        #endregion
    }
}