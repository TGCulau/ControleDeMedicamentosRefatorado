namespace ControleDeMedicamentosRefatorado
{
    public class Medicamento
    {
        public string Nome = "", Tipo = "", DataValidadeFormatada = "", Lote = "";
        public bool EControlado;
        public int QuantidadeDeComprimidosPorCaixa, QuantidadeParaAviso, Estoque;

        public Medicamento(string nome, string tipo, bool eControlado, int quantidadeDeComprimidosPorCaixa, int quantidadeParaAviso, int estoque, string dataValidadeFormatada, string lote)
        {
            Nome = nome;
            Tipo = tipo;
            EControlado = eControlado;
            QuantidadeDeComprimidosPorCaixa = quantidadeDeComprimidosPorCaixa;
            QuantidadeParaAviso = quantidadeParaAviso;
            Estoque = estoque;
            DataValidadeFormatada = dataValidadeFormatada;
            Lote = lote;
        }
    }


}
