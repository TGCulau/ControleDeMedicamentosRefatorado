namespace ControleDeMedicamentosRefatorado
{
    public class TelaFornecedor
    {
        #region Caixa de objetos
        public RepositorioFornecedor RFornecedor = new RepositorioFornecedor();
        TelaMensagens mensagem = new TelaMensagens();
        FuncoesBasicas funcao = new FuncoesBasicas();
        #endregion

        #region Estrutura principal
        public void CheckFornecedor()
        {
            bool existeInformacaoNoArquivo = RFornecedor.LeituraArquivo();
            if (existeInformacaoNoArquivo == false)
            {
                mensagem.ErroSemDadosCadastradosFuncionario();
                Console.ReadKey();
                Cadastro(null, "\tCadastro Fornecedor");
            }
        }
        public void Cadastro(Fornecedor fornecedor, string texto)
        {
            mensagem.Cabecalho();
            Console.Write(texto);
            Console.Write("\n\nNome do fornecedor: ");
            string nome = Console.ReadLine();
            string cnpjformatado = OrganizarCNPJ();
            Console.Write("\nEmail: ");
            string email = Console.ReadLine();
            int prazo = funcao.LerInt("\nPrazo de entrega dos medicamentos: ");


            fornecedor = new Fornecedor(nome, cnpjformatado, email, prazo);

            RFornecedor.Salvar(fornecedor);
            mensagem.CadastroComSucesso();
        }
        public void Alterar()
        {
            Fornecedor fornecedor = RFornecedor.Leitura();
            mensagem.Cabecalho();
            Console.Write("\tAlteração de Fornecedor");
            string texto = Console.ReadLine();
            if (fornecedor.Nome == null)
            {
                Cadastro(fornecedor, "\tCadastro");
            }
            Console.Write($"\n\nO fornecedor {fornecedor.Nome} está cadastrado no sistema. Precione qualquer tecla para alterar os dados.");
            Console.ReadKey();
            Cadastro(fornecedor, texto);
        }
        #endregion

        #region Funções
        public string OrganizarCNPJ()
        {
            string CNPJ;
            while (true)
            {
                Console.Write("\nCNPJ: ");
                string auxiliar = Console.ReadLine();
                bool DigitouCerto = funcao.ChecagemLong(auxiliar);
                if (!DigitouCerto)
                {
                    mensagem.Erro();
                    continue;
                }
                CNPJ = Convert.ToString(auxiliar);
                if (CNPJ.Length > 14)
                {
                    mensagem.Erro();
                    continue;
                }
                break;
            }
            string CNPJFormatado = "";
            int cont = 0;
            char[] aux = new char[14];

            foreach (char numero in CNPJ)
            {
                if (cont < 2)
                {
                    CNPJFormatado += numero;
                }
                if (cont == 2)
                {
                    CNPJFormatado += '.';
                }
                if (cont >= 2 && cont < 5)
                {
                    CNPJFormatado += numero;
                }
                if (cont == 5)
                {
                    CNPJFormatado += '.';
                }
                if (cont >= 5 && cont < 8)
                {
                    CNPJFormatado += numero;
                }
                if (cont == 8)
                {
                    CNPJFormatado += '/';
                }
                if (cont >= 8 && cont < 12)
                {
                    CNPJFormatado += numero;
                }
                if (cont == 12)
                {
                    CNPJFormatado += '-';
                }
                if (cont >= 12 && cont < 14)
                {
                    CNPJFormatado += numero;
                }
                cont++;
            }

            return CNPJFormatado;
        }
        #endregion
    }
}