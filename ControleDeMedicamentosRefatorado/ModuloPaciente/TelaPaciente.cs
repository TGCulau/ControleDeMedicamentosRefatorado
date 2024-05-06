namespace ControleDeMedicamentosRefatorado
{
    public class TelaPaciente
    {

        #region Caixa de Objetos
        public RepositorioPaciente RPaciente = new RepositorioPaciente();
        TelaMensagens mensagem = new TelaMensagens();
        FuncoesBasicas funcao = new FuncoesBasicas();
        FuncoesEspecificas funcaoespecifica = new FuncoesEspecificas();
        #endregion

        #region Estrutura principal
        public void Cadastro()
        {
            mensagem.Cabecalho();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\tCadastro de Pacientes");
            Console.ResetColor();
            Console.Write("\n\nNome: ");
            string nome = Console.ReadLine();
            Console.Write("\nUltimo nome: ");
            string sobrenome = Console.ReadLine();
            int idade = funcao.LerInt("\nIdade: ");
            string genero = funcaoespecifica.CheckGenero("\nGenero\n1. Homem\n2. Mulher\nSua opção: ");
            string cpfformatado = funcaoespecifica.OrganizarCPF("\nDigite o seu CPF: ");
            int cartaoSUS = funcao.LerInt("\nNumero do cartão SUS (apenas números): ");
            string contato = ContatoDoPaciente();

            Paciente paciente = new Paciente(nome, sobrenome, idade, genero, cpfformatado, cartaoSUS, contato);
            RPaciente.Salvar(paciente);

            mensagem.CadastroComSucesso();
        }
        public void Editar()
        {

        }//falta implementar
        #endregion

        #region Funções

        public string ContatoDoPaciente()
        {
            while (true)
            {
                int opcontato = funcao.LerInt("\nEscolha uma opção de contato:\n1. Celular\n2. Telefone fixo\n3. Não tem contato\nSua opção: ");
                switch (opcontato)
                {
                    case 1:

                        string contatoOrganizado = OrganizarCelular();
                        return contatoOrganizado;

                    case 2:
                        contatoOrganizado = funcaoespecifica.OrganizarTelefone();
                        return contatoOrganizado;

                    case 3:
                        contatoOrganizado = "Não possui telefone";
                        return contatoOrganizado;

                }
                mensagem.Erro();
            }
        }
        public string OrganizarCelular()
        {

            string telefone;
            while (true)
            {
                Console.Write("\nNumero de celular para contato (apenas numeros): ");
                telefone = Console.ReadLine();
                bool DigitouCerto = funcao.ChecagemLong(telefone);
                if (!DigitouCerto)
                {
                    mensagem.Erro();
                    continue;
                }
                if (telefone.Length > 12)
                {
                    mensagem.Erro();
                    continue;
                }
                break;
            }
            string telefoneFormatado = "";
            int cont = 0;
            char[] aux = new char[12];
            if (telefone.Length == 9)
            {
                foreach (char numero in telefone)
                {
                    if (cont <= 3)
                    {
                        telefoneFormatado += numero;
                    }
                    if (cont == 3)
                    {
                        telefoneFormatado += '-';
                    }
                    if (cont > 3)
                    {
                        telefoneFormatado += numero;
                    }
                    cont++;
                }
                telefoneFormatado = $"(49) {telefoneFormatado}";
            }
            else if (telefone.Length == 11)
            {
                foreach (char numero in telefone)
                {
                    if (cont == 0)
                    {
                        telefoneFormatado += '(';
                    }
                    if (cont < 2)
                    {
                        telefoneFormatado += numero;
                    }
                    if (cont == 2)
                    {
                        telefoneFormatado += ')';
                        telefoneFormatado += ' ';
                    }
                    if (cont >= 2 && cont <= 5)
                    {
                        telefoneFormatado += numero;
                    }
                    if (cont == 5)
                    {
                        telefoneFormatado += '-';
                    }
                    if (cont > 5)
                    {
                        telefoneFormatado += numero;
                    }
                    cont++;
                }
            }
            return telefoneFormatado;
        } //Tem que arrumar certinho os detalhes 
        #endregion
    }
}
