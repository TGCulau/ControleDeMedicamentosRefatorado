namespace ControleDeMedicamentosRefatorado
{
    public class TelaPostinho
    {
        #region Caixa de objetos
        public RepositorioPosto RPosto = new RepositorioPosto();
        TelaMensagens mensagem = new TelaMensagens();
        FuncoesBasicas funcao = new FuncoesBasicas();
        FuncoesEspecificas funcaoespecifica = new FuncoesEspecificas();
        #endregion

        #region Estrutura principal
        public void Cadastrar()
        {
            mensagem.Cabecalho();
            Console.Write("O sistema não detectou nenhum posto cadastrado, por favor insira os seguintes dados.\n\nNome do bairro: ");
            string bairro = Console.ReadLine();
            string telefoneFormatado = funcaoespecifica.OrganizarTelefone();
            int numerodaunidade = funcao.LerInt("\nDigite o numero da unidade: ");

            Posto postinho = new Posto(bairro, telefoneFormatado, numerodaunidade);
            RPosto.Salvar(postinho);

            mensagem.CadastroComSucesso();
        }
        #endregion

        #region Funções
        public void CheckPostinho()
        {
            bool existeInformacaoNoArquivo = RPosto.LeituraArquivo();
            if (existeInformacaoNoArquivo == false)
            {
                Cadastrar();
            }
        }
        #endregion
    }
}
