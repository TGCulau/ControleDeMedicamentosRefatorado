namespace ControleDeMedicamentosRefatorado
{
    public class RepositorioReceita
    {
        public Receita[] receitas { get; set; } = new Receita[43];
        public RepositorioReceita()
        {
            LeituraArquivo();
        }

        public void Salvar(Receita receita)
        {
            for (int i = 0; i < receitas.Length; i++)
            {
                if (receitas[i] == null)
                {
                    receitas[i] = receita;
                }
            }
            SalvarNoArquivo();
        }
        public Receita[] Leitura()
        {
            return receitas;
        }
        public bool LeituraArquivo()
        {
            string ReceitaBD = "ReceitaBD.txt";
            //Verifica se o arquivo existe
            if (!File.Exists(ReceitaBD))
            {
                // Cria o arquivo e fecha-o imediatamente
                File.Create(ReceitaBD).Close();
            }

            //Lê as linhas do arquivo MedicamentoBD.txt
            string[] linhadotxt = File.ReadAllLines(ReceitaBD);

            bool ExisteInformacaoNoArquivo = true;
            if (linhadotxt.Length == 0)
            {
                ExisteInformacaoNoArquivo = false;
            }

            int cont = 0;
            foreach (string linhalida in linhadotxt)
            {
                // Divide a linha em partes usando a vírgula como separador
                string[] coluna = linhalida.Split(',');

                string nomedoMedico = coluna[0];
                string nomedoRemedio = coluna[1];
                string tipo = coluna[2];
                int eControlado = int.Parse(coluna[3]);
                bool econtrolado = true;
                if (eControlado == 0)
                {
                    econtrolado = false;
                }
                int quantidadeDeComprimidosTotais = int.Parse(coluna[4]);
                string dataFormatada = coluna[5];
                string lote = coluna[6];

                receitas[cont] = new Receita(nomedoRemedio, nomedoMedico, tipo, econtrolado, quantidadeDeComprimidosTotais, dataFormatada);
                cont++;
            }

            return ExisteInformacaoNoArquivo;
        }
        public void SalvarNoArquivo()
        {
            string ReceitaBD = "ReceitaBD.txt";
            // Prepara a linha para ser escrita no arquivo
            string linha = "";
            int eControlado = 0;
            for (int i = 0; i < 43; i++)
            {
                if (receitas[i].EControlado == true)
                {
                    eControlado = 1;
                }
                else if (receitas[i].EControlado == false)
                {
                    eControlado = 0;
                }
                linha += $"{receitas[i].NomeDoMedico},{receitas[i].NomeDoRemedio},{receitas[i].Tipo},{eControlado},{receitas[i].QuantidadeDeComprimidosTotais},{receitas[i].DataFormatada},";
            }
            // Escreve a linha no arquivo
            File.AppendAllText(ReceitaBD, linha + Environment.NewLine);
        }
    }
}