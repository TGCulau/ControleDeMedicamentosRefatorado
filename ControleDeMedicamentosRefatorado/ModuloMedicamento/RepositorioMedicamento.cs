namespace ControleDeMedicamentosRefatorado
{
    public class RepositorioMedicamento
    {
        public Medicamento[] medicamentos { get; set; } = new Medicamento[43];
        public RepositorioMedicamento()
        {
            LeituraArquivo();
        }

        public void Salvar(Medicamento medicamento)
        {
            for (int i = 0; i < medicamentos.Length; i++)
            {
                if (medicamentos[i] == null)
                {
                    medicamentos[i] = medicamento;
                }
            }
            SalvarNoArquivo();
        }
        public Medicamento[] Leitura()
        {
            return medicamentos;
        }

        public bool LeituraArquivo()
        {
            string MedicamentoBD = "MedicamentoBD.txt";
            //Verifica se o arquivo existe
            if (!File.Exists(MedicamentoBD))
            {
                // Cria o arquivo e fecha-o imediatamente
                File.Create(MedicamentoBD).Close();
            }

            //Lê as linhas do arquivo MedicamentoBD.txt
            string[] linhadotxt = File.ReadAllLines(MedicamentoBD);

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

                string nome = coluna[0];
                string tipo = coluna[1];
                int econtrolado = int.Parse(coluna[2]);
                int quantidadeDeComprimidosPorCaixa = int.Parse(coluna[3]);
                int quantidadeParaAviso = int.Parse(coluna[4]);
                int estoque = int.Parse(coluna[5]);
                bool eControlado = true;
                if (econtrolado == 0)
                {
                    eControlado = false;
                }
                string dataValidadeFormatada = coluna[6];
                string lote = coluna[7];

                medicamentos[cont] = new Medicamento(nome, tipo, eControlado, quantidadeDeComprimidosPorCaixa, quantidadeParaAviso, estoque, dataValidadeFormatada, lote);
                cont++;
            }
            return ExisteInformacaoNoArquivo;
        }
        public void SalvarNoArquivo()
        {
            string MedicamentoBD = "MedicamentoBD.txt";
            // Prepara a linha para ser escrita no arquivo
            string linha = "";
            int eControlado = 0;
            for (int i = 0; i < 43; i++)
            {
                if (medicamentos[i].EControlado == true)
                {
                    eControlado = 1;
                }
                else if (medicamentos[i].EControlado == false)
                {
                    eControlado = 0;
                }
                linha += $"{medicamentos[i].Nome},{medicamentos[i].Tipo},{eControlado},{medicamentos[i].QuantidadeDeComprimidosPorCaixa},{medicamentos[i].QuantidadeParaAviso},{medicamentos[i].Estoque},{medicamentos[i].DataValidadeFormatada},{medicamentos[i].Lote},";
            }
            // Escreve a linha no arquivo
            File.AppendAllText(MedicamentoBD, linha + Environment.NewLine);
        }
    }




}