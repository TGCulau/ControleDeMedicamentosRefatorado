namespace ControleDeMedicamentosRefatorado
{
    public class RepositorioPaciente
    {
        public Paciente[] pacientes { get; set; } = new Paciente[43];
        public RepositorioPaciente()
        {
            LeituraArquivo();
        }

        public Paciente[] Leitura()
        {
            return pacientes;
        }
        public void Salvar(Paciente paciente)
        {
            for (int i = 0; i < pacientes.Length; i++)
            {
                if (pacientes[i] == null)
                {
                    pacientes[i] = paciente;
                }
            }
            SalvarNoArquivo();
        }
        public bool LeituraArquivo()
        {
            string PacienteBD = "PacienteBD.txt";
            //Verifica se o arquivo existe
            if (!File.Exists(PacienteBD))
            {
                // Cria o arquivo e fecha-o imediatamente
                File.Create(PacienteBD).Close();
            }

            //Lê as linhas do arquivo MedicamentoBD.txt
            string[] linhadotxt = File.ReadAllLines(PacienteBD);

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

                pacientes[cont] = new Paciente(nome, sobrenome, idade, genero, cpfformatado, cartaoSUS, contato);
                cont++;
            }

            return ExisteInformacaoNoArquivo;
        }
        public void SalvarNoArquivo()
        {
            string PacienteBD = "PacienteBD.txt";
            // Prepara a linha para ser escrita no arquivo
            string linha = "";
            for (int i = 0; i < pacientes.Length; i++)
            {
                if (pacientes[i] != null)
                {

                    linha += $"{pacientes[i].Nome},{pacientes[i].Sobrenome},{pacientes[i].Idade},{pacientes[i].Genero},{pacientes[i].CPFFormatado},{pacientes[i].CartaoSUS},{pacientes[i].Contato},";

                }
            }
            // Escreve a linha no arquivo
            File.AppendAllText(PacienteBD, linha + Environment.NewLine);
        }
    }
}