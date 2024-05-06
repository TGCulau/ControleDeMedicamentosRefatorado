namespace ControleDeMedicamentosRefatorado
{

    public class TelaMedicamento
    {
        #region Caixa de objetos
        public RepositorioMedicamento RMedicamento = new RepositorioMedicamento();
        TelaMensagens mensagem = new TelaMensagens();
        FuncoesBasicas funcao = new FuncoesBasicas();
        FuncoesEspecificas funcaoespecifica = new FuncoesEspecificas();
        #endregion

        #region Estrutura principal
        public void Cadastro()
        {
            mensagem.Cabecalho();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\tCadastro de novo medicamento");
            Console.ResetColor();
            Console.Write("\n\nNome do medicamento: ");
            string nome = Console.ReadLine();
            Console.Write("\nTipo do medicamento: ");
            string tipo = Console.ReadLine();
            Console.Write("\n\tEste medicamento é controlado?");
            bool eControlado = funcaoespecifica.RemedioEControlado("\n1. Sim\n2. Não\nSua opção: ");
            int quantidadeDeComprimidosPorCaixa = funcao.LerInt("\nDigite quantos comprimidos por caixa este medicamento é disponibilizado: ");
            int quantidadeParaAviso = funcao.LerInt("\nDigite o limite mínimo em estoque deste medicamento: ");
            int estoque = funcao.LerInt("\nDigite quantas caixas estão sendo cadastradas: ");
            string dataValidadeFormatada = DataValidadeOrganizada();
            Console.Write("\n\nDigite o lote: ");
            string lote = Console.ReadLine();

            Medicamento medicamento = new Medicamento(nome, tipo, eControlado, quantidadeDeComprimidosPorCaixa, quantidadeParaAviso, estoque, dataValidadeFormatada, lote);

            RMedicamento.Salvar(medicamento);
            mensagem.CadastroComSucesso();
        }
        #endregion

        #region Funções
        public string DataValidadeOrganizada()
        {
            while (true)
            {
                DateTime dataAtual = DateTime.Now;
                int mesvalidade = funcao.LerInt($"\nDigite o mês, em numero, da validade do medicamento: ");
                if (mesvalidade < 0 || mesvalidade > 12)
                {
                    mensagem.Erro();
                    continue;
                }
                int anovalidade = funcao.LerInt($"\nDigite o ano da validade do medicamento: ");
                if (anovalidade < dataAtual.Year)
                {
                    mensagem.Erro();
                    continue;
                }


                string mesaux = $"{mesvalidade}";

                if (mesvalidade < 10)
                {
                    mesaux = $"0{mesvalidade}";
                }
                string data = $"{mesaux}/{anovalidade}";


                if (anovalidade < dataAtual.Year)
                {
                    mensagem.RemedioVencido();
                    data += " *vencido*";
                }


                return data;
            }
        }
        public void VerficicarEstoque()
        {
            mensagem.Cabecalho();
            Medicamento[] medicamento = RMedicamento.Leitura();
            Console.Write("\tEstoque");
            Console.WriteLine("");
        }
        public void SolicitarRemedio()
        {

        }

        #endregion
    }
}