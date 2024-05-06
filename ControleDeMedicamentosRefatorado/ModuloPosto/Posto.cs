namespace ControleDeMedicamentosRefatorado
{
    public class Posto
    {
        public string Bairro = "", TelefoneFormatado = "";
        public int NumeroDaUnidade;

        public Posto(string bairro, string telefoneFormatado, int numerodaunidade)
        {
            Bairro = bairro;
            NumeroDaUnidade = numerodaunidade;
            TelefoneFormatado = telefoneFormatado;
        }
    }
}
