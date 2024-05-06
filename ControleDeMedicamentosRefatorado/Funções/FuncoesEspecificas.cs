namespace ControleDeMedicamentosRefatorado
{
    public class FuncoesEspecificas
    {
        #region Caixa de Objetos        
        FuncoesBasicas funcao = new FuncoesBasicas();
        TelaMensagens mensagem = new TelaMensagens();
        #endregion
        public string OrganizarCPF(string texto)
        {
            string cpf;
            while (true)
            {
                Console.Write(texto);
                cpf = Console.ReadLine();
                bool DigitouCerto = funcao.ChecagemLong(cpf);
                if (!DigitouCerto)
                {
                    mensagem.Erro();
                    continue;
                }
                if (cpf.Length > 11)
                {
                    mensagem.Erro();
                    continue;
                }
                break;
            }

            string cpforganizado = "";
            int cont = 0;
            char[] aux = new char[11];
            foreach (char numero in cpf)
            {

                if (cont <= 2)
                {
                    cpforganizado += numero;
                }
                if (cont == 3)
                {
                    cpforganizado = cpforganizado + ".";
                }
                if (cont >= 3 && cont <= 5)
                {
                    cpforganizado += numero;
                }
                if (cont == 6)
                {
                    cpforganizado = cpforganizado + ".";
                }
                if (cont >= 6 && cont <= 8)
                {
                    cpforganizado += numero;
                }
                if (cont == 9)
                {
                    cpforganizado = cpforganizado + "-";
                }
                if (cont >= 9)
                {
                    cpforganizado += numero;
                }
                cont++;
            }
            return cpforganizado;
        }
        public string CheckGenero(string texto)
        {
            while (true)
            {
                Console.Write(texto);
                var digitouNumero = int.TryParse(Console.ReadLine(), out var numero);
                if (!digitouNumero)
                {
                    mensagem.Erro();
                    continue;
                }
                if (numero != 1 && numero != 2)
                {
                    mensagem.Erro();
                    continue;
                }
                string genero = "";
                if (numero == 1)
                {
                    genero = "Homem";
                }
                else if (numero == 2)
                {
                    genero = "Mulher";
                }
                return genero;
            }
        }
        public bool RemedioEControlado(string texto)
        {
            while (true)
            {
                Console.Write(texto);
                var digitouNumero = int.TryParse(Console.ReadLine(), out var numero);
                if (!digitouNumero)
                {
                    mensagem.Erro();
                    continue;
                }
                if (numero != 1 && numero != 2)
                {
                    mensagem.Erro();
                    continue;
                }
                if (numero == 1)
                {
                    return true;
                }
                else if (numero == 2)
                {
                    return false;
                }
            }
        }
        public string OrganizarTelefone()
        {

            string telefone;
            while (true)
            {
                Console.Write("\nNumero de telefone fixo para contato (apenas numeros): ");
                telefone = Console.ReadLine();
                bool DigitouCerto = funcao.ChecagemLong(telefone);
                if (!DigitouCerto)
                {
                    mensagem.Erro();
                    continue;
                }
                if (telefone.Length > 10)
                {
                    mensagem.Erro();
                    continue;
                }
                break;
            }
            string telefoneFormatado = "";
            int cont = 0;
            char[] aux = new char[10];
            if (telefone.Length == 8)
            {
                foreach (char numero in telefone)
                {
                    if (cont <= 3)
                    {
                        telefoneFormatado += numero;
                    }
                    if (cont == 3)
                    {
                        telefoneFormatado += '-';
                    }
                    if (cont > 3)
                    {
                        telefoneFormatado += numero;
                    }
                    cont++;
                }
                telefoneFormatado = $"(49) {telefoneFormatado}";
            }
            else if (telefone.Length == 10)
            {
                foreach (char numero in telefone)
                {
                    if (cont == 0)
                    {
                        telefoneFormatado += '(';
                    }
                    if (cont < 2)
                    {
                        telefoneFormatado += numero;
                    }
                    if (cont == 2)
                    {
                        telefoneFormatado += ')';
                        telefoneFormatado += ' ';
                    }
                    if (cont >= 2 && cont <= 5)
                    {
                        telefoneFormatado += numero;
                    }
                    if (cont == 5)
                    {
                        telefoneFormatado += '-';
                    }
                    if (cont > 5)
                    {
                        telefoneFormatado += numero;
                    }
                    cont++;
                }
            }
            return telefoneFormatado;
        }
    }

}