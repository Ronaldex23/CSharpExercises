class Program
{
    class ValidadorCNPJ
    {
        private int[] cnpj = new int[14];
        private int[] digito = { 0, 0 };
        private void Exibir()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("      VALIDADOR DE CNPJ");
            Console.WriteLine("===============================");
            Console.Write("\nDigite o CNPJ: ");
        }
        public void ArmazenaEntrada(string cnpj)
        {
            int conversor;
            for (int i = 0; i < cnpj.Length; i++)
            {
                conversor = cnpj[i] - '0';
                this.cnpj[i] = conversor;
            }
        }
        public void ValidaEntrada()
        {
            bool validaNum;
            int quant_caractere;
            string cnpj;
            do
            {
                Exibir();
                cnpj = Console.ReadLine();
                quant_caractere = cnpj.Length;
                if (quant_caractere == 14)
                {
                    validaNum = true;
                    for (int i = 0; i < quant_caractere; i++)
                    {
                        if (cnpj[i] >= '0' && cnpj[i] <= '9')
                        {
                            validaNum = true;
                        }
                        else
                        {
                            Console.WriteLine("\nERROR 2 / Não é possível prosseguir, entrada contêm caracteres além de números.");
                            Console.WriteLine("[Tome cuidado com caracteres especiais, pontuações e espaços indevidos]");
                            Console.WriteLine("Pressione Enter e digite novamente...");
                            Console.ReadKey();
                            validaNum = false;
                            i = 14; // sair do loop
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nERROR 1 / Quantidade de caracteres digitados inválido.");
                    Console.WriteLine("Um CNPJ (Cadastro de Pessoa Jurídica) é composto por uma sequência de 14 dígitos númericos.");
                    Console.WriteLine("Pressione Enter e digite novamente...");
                    Console.ReadKey();
                    validaNum = false;
                }
            } while (!validaNum);

            ArmazenaEntrada(cnpj);
        }
        public bool ValidaCNPJ()
        {
            int soma = 0;
            int verificador = 1;
            bool valido = false;
            int[] calculo = {6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2};

            for (int i = 0; i < 2; i++)//setar o digito
            {
                for (int j = 0; j < calculo.Length - verificador; j++)
                {
                    soma += cnpj[j] * calculo[j + verificador];
                }

                if(soma % 11 < 2)
                {
                    digito[i] = 0;
                }
                else
                {
                    digito[i] = 11 - (soma % 11);
                }

                //reiniciando as variáveis para o segundo digito
                verificador--;
                soma = 0;
            }

            if (cnpj[12] == digito[0] && cnpj[13] == digito[1])
            {
                valido = true;
            }
            else
            {
                valido = false;
            }
            
            return valido;
        }
        
        public bool Reiniciar()
        {
            char letra_reiniciar;
            bool validaReiniciar;
            bool reiniciar = false;

            Console.WriteLine("\nDeseja Continuar? Digite S ou N");
            do
            {
                letra_reiniciar = char.ToUpper(Console.ReadKey().KeyChar);
                if (letra_reiniciar == 'S')
                {
                    reiniciar = true;
                    validaReiniciar = true;
                }
                else if(letra_reiniciar == 'N')
                {
                    reiniciar = false;
                    validaReiniciar = true;
                }
                else
                {
                    Console.WriteLine("Entrada inválida!! Escolha entre 'S' para sim ou 'N' para não.");
                    Console.WriteLine("Digite novamente...");
                    validaReiniciar = false;
                }
            } while (!validaReiniciar);

            return reiniciar;
        }
    }
    static void Main(string[] args)
    {
        bool reiniciar = true;

        while (reiniciar)
        {
            ValidadorCNPJ cadastro = new();
            cadastro.ValidaEntrada();
            
            if (cadastro.ValidaCNPJ() == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nCNPJ é válido");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCNPJ não é válido");
            }
            Console.ResetColor();

            reiniciar = cadastro.Reiniciar();
        }

        Console.WriteLine("Programa Encerrado.");
    }
}