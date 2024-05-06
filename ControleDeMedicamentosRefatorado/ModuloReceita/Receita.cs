namespace ControleDeMedicamentosRefatorado
{
    public class Receita
    {
        public string NomeDoMedico = "", NomeDoRemedio = "", Tipo = "", DataFormatada = "";
        public bool EControlado;
        public int QuantidadeDeComprimidosTotais;

        public Receita(string nomedoRemedio, string nomedoMedico, string tipo, bool econtrolado, int quantidadeDeComprimidosTotais, string dataFormatada)
        {
            NomeDoRemedio = nomedoRemedio;
            NomeDoMedico = nomedoMedico;
            Tipo = tipo;
            EControlado = econtrolado;
            QuantidadeDeComprimidosTotais = quantidadeDeComprimidosTotais;
            DataFormatada = dataFormatada;
        }
    }
}
