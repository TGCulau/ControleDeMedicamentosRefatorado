namespace ControleDeMedicamentosRefatorado
{
    public class TelaMensagens
    {
        public RepositorioMedicamento RMedicamento = new RepositorioMedicamento();

        #region Apenas Mensagens
        public void Cabecalho()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Clear();
            Console.WriteLine("########################################################################################################################");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                           Secretaria de Saúde de Lages                                           ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                  Farmácia Básica                                                 ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("########################################################################################################################\n");
            Console.ResetColor();
        }
        public void Erro()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.WriteLine("\n\n\n########################################################################################################################");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                      ATENÇÃO                                                     ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                               Comando inválido. Por favor digite um comando válido.                              ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                      Precione qualquer tecla para continuar.                                     ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("########################################################################################################################");
            Console.ReadKey();
            Cabecalho();
        }
        public void ErroSemDadosCadastradosFuncionario()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.WriteLine("\n\n\n########################################################################################################################");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                      ATENÇÃO                                                     ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                             Nenhum cadastrado encontrado, direcionando para o cadastro                           ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                      Precione qualquer tecla para continuar.                                     ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("########################################################################################################################");
            Console.ReadKey();
        }
        public void DataInvalida()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.WriteLine("\n\n\n########################################################################################################################");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                      ATENÇÃO                                                     ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                      Data Inválida. Por favor digite um dia igual ou inferior ao dia atual.                      ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                      Precione qualquer tecla para continuar.                                     ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("########################################################################################################################");
            Console.ReadKey();
            Cabecalho();
        }
        public void CadastroComSucesso()
        {
            Cabecalho();
            Console.Write("Cadastro efetuado com sucesso!\n\nPrecione qualquer tecla para continuar.");
        }
        public void LoginErrado()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.WriteLine("\n\n\n########################################################################################################################");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                       ERRO                                                       ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                         Dados não reconhecidos. Por favor verifique os dados digitados.                          ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                      Precione qualquer tecla para continuar.                                     ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("########################################################################################################################");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.ReadKey();
            Cabecalho();
        }
        public void RemedioVencido()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.WriteLine("\n\n\n########################################################################################################################");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                                      ATENÇÃO                                                     ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                             Remédio vencido! Por favor verifique a data de validade.                             ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("###                                      Precione qualquer tecla para continuar.                                     ###");
            Console.WriteLine("###                                                                                                                  ###");
            Console.WriteLine("########################################################################################################################");
            Console.ReadKey();
            Cabecalho();
        }
        public void AlteracaoEfetuadaComSucesso()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\tAlteração efetuada com sucesso. Precione qualquer tecla para continuar");
            Console.ResetColor();
            Console.ReadKey();
        }
        #endregion

        #region Mensagens com Opções
        public void RemedioEControlado(bool eControlado)
        {
            if (eControlado)
            {
                Console.Write("é ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Controlado");
                Console.ResetColor();
            }
            else if (!eControlado)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Não controlado");
                Console.ResetColor();
            }
        }
        #endregion

        #region Mensagens com Funções
        public void AvisoParaSolicitarMaisRemédio()
        {
            Medicamento[] medicamentos = RMedicamento.Leitura();
            decimal margemdeerrode10pc;
            for (int i = 0; i < medicamentos.Length; i++)
            {
                margemdeerrode10pc = medicamentos[i].QuantidadeParaAviso * 1.1m;
                if (medicamentos[i].Estoque <= margemdeerrode10pc && medicamentos[i].Estoque >= medicamentos[i].QuantidadeParaAviso)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"\n\tATENÇÃO!! O medicamento {medicamentos[i].Nome} está próximo do limite mínimo recomendado.\nTem apenas {medicamentos[i].Estoque} unidades.\nSolicite mais com urgência.");
                    Console.ResetColor();
                }
                else if (medicamentos[i].Estoque <= medicamentos[i].QuantidadeParaAviso)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"\n\tATENÇÃO!!!! O medicamento {medicamentos[i].Nome} está a baixo do limite mínimo recomendado.\nTem apenas {medicamentos[i].Estoque} unidades.\nSolicite mais URGENTEMENTE.");
                    Console.ResetColor();
                }
            }
        }
        public void Saudacao(int posicaoativafuncionario)
        {
            RepositorioFuncionario RFuncionario = new RepositorioFuncionario();
            Funcionario[] funcionario = RFuncionario.Leitura();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(funcionario[posicaoativafuncionario].Saudacao);
            Console.ResetColor();
        }
        #endregion

    }
}
