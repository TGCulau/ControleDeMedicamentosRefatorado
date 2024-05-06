namespace ControleDeMedicamentosRefatorado
{
    public class Prontuario
    {
        public Paciente paciente;
        public Receita receita;
        public int NumeroDoProntuario;

        public Prontuario(int numeroDoProntuario)
        {
            NumeroDoProntuario = numeroDoProntuario;
        }
    }
}
