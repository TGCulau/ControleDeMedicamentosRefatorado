namespace ControleDeMedicamentosRefatorado
{
    public class TelaReceita
    {
        #region Caixa de objetos
        FuncoesBasicas funcao = new FuncoesBasicas();
        TelaMensagens mensagem = new TelaMensagens();
        FuncoesEspecificas funcaoespecifica = new FuncoesEspecificas();
        public RepositorioReceita RReceita = new RepositorioReceita();
        #endregion

        #region Estrutura principal
        public void Cadastro()
        {
            mensagem.Cabecalho();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\tCadastro de Receita");
            Console.ResetColor();
            Console.Write("\n\nNome do medicamento: ");
            string nomedoRemedio = Console.ReadLine();
            Console.Write("\n\nNome do médico: ");
            string nomedoMedico = Console.ReadLine();
            Console.Write("\nTipo do medicamento: ");
            string tipo = Console.ReadLine();
            Console.Write("\n\tEste medicamento é controlado?");
            bool eControlado = funcaoespecifica.RemedioEControlado("\n1. Sim\n2. Não\nSua opção: ");
            int quantidadeDeComprimidosTotais = CalculoDeComprimidos();
            string dataFormatada = DataReceitaOrganizada();


            Receita receita = new Receita(nomedoRemedio, nomedoMedico, tipo, eControlado, quantidadeDeComprimidosTotais, dataFormatada);
            RReceita.Salvar(receita);


            mensagem.CadastroComSucesso();
        }
        #endregion

        #region Funções
        public int CalculoDeComprimidos()
        {
            while (true)
            {
                int compaodia = funcao.LerInt("\nDigite a quantidade de comprimidos receitados por dia: ");
                if (compaodia <= 0)
                {
                    mensagem.Erro();
                    continue;
                }
                int diastratamento = funcao.LerInt("\nDigite o prazo em dias receitado: ");
                if (diastratamento <= 0)
                {
                    mensagem.Erro();
                    continue;
                }
                int totaldecomp = compaodia * diastratamento;
                return totaldecomp;
            }
        }
        public string DataReceitaOrganizada()
        {
            while (true)
            {
                int dia = funcao.LerInt($"\nDigite o dia da receita: ");
                if (dia < 0 || dia > 31)
                {
                    mensagem.Erro();
                    continue;
                }

                int mes = funcao.LerInt($"\nDigite o mês, em numero, da receita: ");
                if (mes < 0 || mes > 12)
                {
                    mensagem.Erro();
                    continue;
                }

                DateTime dataAtual = DateTime.Now;
                if (dia > dataAtual.Day && mes == dataAtual.Month || mes < dataAtual.Month)
                {
                    mensagem.DataInvalida();
                    continue;
                }
                int ano = funcao.LerInt($"\nDigite o ano da receita: ");
                if (ano > dataAtual.Year)
                {
                    mensagem.DataInvalida();
                    continue;
                }

                string mesaux = $"{mes}";
                string diaaux = $"{dia}";

                if (mes < 10)
                {
                    mesaux = $"0{mes}";
                }
                if (dia < 10)
                {
                    diaaux = $"0{dia}";
                }
                string data = $"{diaaux}/{mesaux}/{ano}";
                return data;
            }
        }
        #endregion
    }

}