namespace ControleDeMedicamentosRefatorado
{
    public class RepositorioPosto
    {
        public Posto postinho { get; set; }
        public RepositorioPosto()
        {
            LeituraArquivo();
        }

        public void Salvar(Posto postinho)
        {
            SalvarNoArquivo(postinho);
        }
        public Posto Leitura()
        {
            return postinho;
        }
        public bool LeituraArquivo()
        {
            string PostinhoBD = "PostinhoBD.txt";
            //Verifica se o arquivo existe
            if (!File.Exists(PostinhoBD))
            {
                // Cria o arquivo e fecha-o imediatamente
                File.Create(PostinhoBD).Close();
            }

            //Lê as linhas do arquivo PostinhoBD.txt
            string[] linhadotxt = File.ReadAllLines(PostinhoBD);

            bool ExisteInformacaoNoArquivo = true;
            if (linhadotxt.Length == 0)
            {
                ExisteInformacaoNoArquivo = false;
            }

            string bairro = "", telefoneFormatado = "";
            int numerodaunidade = 0;

            foreach (string linhalida in linhadotxt)
            {
                // Divide a linha em partes usando a vírgula como separador
                string[] coluna = linhalida.Split(',');

                bairro = coluna[0];
                telefoneFormatado = coluna[1];
                numerodaunidade = int.Parse(coluna[2]);
                postinho = new Posto(bairro, telefoneFormatado, numerodaunidade);
            }

            return ExisteInformacaoNoArquivo;
        }
        public void SalvarNoArquivo(Posto postinho)
        {
            string PostinhoBD = "PostinhoBD.txt";
            // Prepara a linha para ser escrita no arquivo
            string linha = $"{postinho.Bairro},{postinho.TelefoneFormatado},{postinho.NumeroDaUnidade},";
            // Escreve a linha no arquivo
            File.AppendAllText(PostinhoBD, linha + Environment.NewLine);
        }

    }

}