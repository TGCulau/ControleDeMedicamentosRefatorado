namespace ControleDeMedicamentosRefatorado
{
    public class RepositorioFuncionario
    {
        public Funcionario[] funcionarios { get; set; } = new Funcionario[5];
        public RepositorioFuncionario()
        {
            LeituraArquivo();
        }

        public void Salvar(Funcionario funcionario)
        {
            for (int i = 0; i < funcionarios.Length; i++)
            {
                if (funcionarios[i] == null)
                {
                    funcionarios[i] = funcionario;
                }
            }
            SalvarNoArquivo(funcionario);
        }
        public Funcionario[] Leitura()
        {
            return funcionarios;
        }

        public bool LeituraArquivo()
        {
            string FuncionarioBD = "FuncionarioBD.txt";
            //Verifica se o arquivo existe
            if (!File.Exists(FuncionarioBD))
            {
                // Cria o arquivo e fecha-o imediatamente
                File.Create(FuncionarioBD).Close();
            }

            //Lê as linhas do arquivo FuncionarioBD.txt
            string[] linhadotxt = File.ReadAllLines(FuncionarioBD);

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
                string saudacao = coluna[2];
                int idade = int.Parse(coluna[3]);
                string genero = coluna[4];
                string cpfformatado = coluna[5];
                string cargo = coluna[6];
                int matricula = int.Parse(coluna[7]);
                string email = coluna[8];
                string senha = coluna[9];

                funcionarios[cont++] = new Funcionario(nome, sobrenome, saudacao, idade, genero, cpfformatado, cargo, matricula, email, senha);
            }

            return ExisteInformacaoNoArquivo;
        }
        public void SalvarNoArquivo(Funcionario funcionario)
        {
            string FuncionarioBD = "FuncionarioBD.txt";
            // Prepara a linha para ser escrita no arquivo
            string linha = "";
            for (int i = 0; i < 5; i++)
            {
                linha = $"{funcionarios[i].Nome},{funcionarios[i].Sobrenome},{funcionarios[i].Saudacao},{funcionarios[i].Idade},{funcionarios[i].Genero},{funcionarios[i].CPFFormatado},{funcionarios[i].Cargo},{funcionarios[i].Matricula},{funcionarios[i].Email},{funcionarios[i].Senha},";
            }
            // Escreve a linha no arquivo
            File.AppendAllText(FuncionarioBD, linha + Environment.NewLine);
        }
    }
}