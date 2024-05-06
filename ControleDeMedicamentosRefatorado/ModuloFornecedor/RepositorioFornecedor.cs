namespace ControleDeMedicamentosRefatorado
{
    public class RepositorioFornecedor
    {
        public Fornecedor fornecedor { get; set; }
        public RepositorioFornecedor()
        {
            LeituraArquivo();
        }

        public void Salvar(Fornecedor fornecedor)
        {
            SalvarNoArquivo(fornecedor);
        }
        public Fornecedor Leitura()
        {
            return fornecedor;
        }
        public bool LeituraArquivo()
        {
            string FornecedorBD = "FornecedorBD.txt";
            //Verifica se o arquivo existe
            if (!File.Exists(FornecedorBD))
            {
                // Cria o arquivo e fecha-o imediatamente
                File.Create(FornecedorBD).Close();
            }

            //Lê as linhas do arquivo FornecedorBD.txt
            string[] linhadotxt = File.ReadAllLines(FornecedorBD);

            bool ExisteInformacaoNoArquivo = true;
            if (linhadotxt.Length == 0)
            {
                ExisteInformacaoNoArquivo = false;
            }

            string nome = "", cnpjformatado = "", email = "";
            int prazo = 0;

            foreach (string linhalida in linhadotxt)
            {
                // Divide a linha em partes usando a vírgula como separador
                string[] coluna = linhalida.Split(',');

                nome = coluna[0];
                cnpjformatado = coluna[1];
                email = coluna[2];
                prazo = int.Parse(coluna[3]);
            }
            fornecedor = new Fornecedor(nome, cnpjformatado, email, prazo);

            return ExisteInformacaoNoArquivo;
        }
        public void SalvarNoArquivo(Fornecedor fornecedor)
        {
            string FornecedorBD = "FornecedorBD.txt";
            // Prepara a linha para ser escrita no arquivo
            string linha = $"{fornecedor.Nome},{fornecedor.CNPJFormatado},{fornecedor.Email},{fornecedor.Prazo}";
            // Escreve a linha no arquivo
            File.AppendAllText(FornecedorBD, linha + Environment.NewLine);
        }
    }
}