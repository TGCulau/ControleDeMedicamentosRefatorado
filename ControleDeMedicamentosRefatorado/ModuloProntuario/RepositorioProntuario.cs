namespace ControleDeMedicamentosRefatorado
{
    public class RepositorioProntuario
    {
        public Prontuario[] prontuarios { get; set; } = new Prontuario[43];
        public RepositorioProntuario()
        {
            LeituraArquivo();
        }

        public Prontuario[] Leitura()
        {
            return prontuarios;
        }
        public void Salvar(Prontuario prontuario)
        {
            for (int i = 0; i < prontuarios.Length; i++)
            {
                if (prontuarios[i] == null)
                {
                    prontuarios[i] = prontuario;
                }
            }
            SalvarNoArquivo();
        }
        public bool LeituraArquivo()
        {
            string ProntuarioBD = "ProntuarioBD.txt";
            //Verifica se o arquivo existe
            if (!File.Exists(ProntuarioBD))
            {
                // Cria o arquivo e fecha-o imediatamente
                File.Create(ProntuarioBD).Close();
            }

            //Lê as linhas do arquivo MedicamentoBD.txt
            string[] linhadotxt = File.ReadAllLines(ProntuarioBD);

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
                string sobrenome = coluna[1];
                int idade = int.Parse(coluna[2]);
                string genero = coluna[3];
                string cpfformatado = coluna[4];
                int cartaoSUS = int.Parse(coluna[5]);
                string contato = coluna[6];

                //pacientes[cont] = new Paciente(nome, sobrenome, idade, genero, cpfformatado, cartaoSUS, contato);
                cont++;
            }

            return ExisteInformacaoNoArquivo;
        }
        public void SalvarNoArquivo()
        {
            string PacienteBD = "PacienteBD.txt";
            // Prepara a linha para ser escrita no arquivo
            string linha = "";
            for (int i = 0; i < 43; i++)
            {
                // linha += $"{pacientes[i].Nome},{pacientes[i].Sobrenome},{pacientes[i].Idade},{pacientes[i].Genero},{pacientes[i].CPFFormatado},{pacientes[i].CartaoSUS},{pacientes[i].Contato},";
            }
            // Escreve a linha no arquivo
            File.AppendAllText(PacienteBD, linha + Environment.NewLine);
        }
    }
}