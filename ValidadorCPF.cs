class Program
{
    class ValidadorCPF
    {
        private int[] cpf_digitos = new int[11];

        private void Exibir()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("       VALIDADOR DE CPF");
            Console.WriteLine("===============================");
            Console.Write("\nDigite o CPF: ");
        }
        public void ArmazenaEntrada(string cpf)
        {
            int conversor;

            for (int i = 0; i < cpf_digitos.Length; i++)
            {
                conversor = cpf[i] - '0';
                cpf_digitos[i] = conversor;
            }
        }
        public void ValidaEntrada()
        {
            bool validaNum;
            int quant_caractere;
            string cpf;

            do
            {
                Exibir();
                cpf = Console.ReadLine();
                quant_caractere = cpf.Length;

                if (quant_caractere == 11)
                {
                    validaNum = true;
                    for (int i = 0; i < quant_caractere; i++)
                    {
                        if (cpf[i] >= '0' && cpf[i] <= '9')
                        {
                            validaNum = true;
                        }
                        else
                        {
                            Console.WriteLine("\nERROR 2 / Não é possível prosseguir, entrada contêm caracteres além de números.");
                            Console.WriteLine("Necessário uma sequência de 11 dígitos númericos!!");
                            Console.WriteLine("[Tome cuidado com caracteres especiais, pontuações e espaços indevidos]");
                            Console.WriteLine("Digite novamente...");
                            Console.ReadKey();
                            validaNum = false;
                            i = 11; // sair do loop
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nERROR 1 / Quantidade de caracteres digitados inválido.");
                    Console.WriteLine("Um CPF é um cadastro composto por uma sequência de 11 dígitos númericos.");
                    Console.WriteLine("Pressione Enter e digite novamente...");
                    Console.ReadKey();
                    validaNum = false;
                }
            } while (!validaNum);

            ArmazenaEntrada(cpf);
        }
        public bool ValidaCPF()
        {
            int dig1 = 0, dig2 = 0;
            int soma = 0;
            int n = 10;

            for(int i = 0; i < 2; i++)
            {
                for (int j = 0; j < cpf_digitos.Length - 2; j++)
                {
                    soma += cpf_digitos[j] * n;
                    n--;
                }

                if(i == 0)//primeiro digito
                {
                    if(soma % 11 < 2)
                    {
                        dig1 = 0;
                    }
                    else
                    {
                        dig1 = 11 - (soma % 11);
                    }
                }
                else//segundo digito
                {
                    soma += cpf_digitos[9] * n;

                    if (soma % 11 < 2)
                    {
                        dig2 = 0;
                    }
                    else
                    {
                        dig2 = 11 - (soma % 11);
                    }
                }

                n = 11;
                soma = 0;
            }

            //CPF é valido?
            if (dig1 == cpf_digitos[9] && dig2 == cpf_digitos[10])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Reiniciar()
        {
            bool validaReiniciar;
            bool reiniciar = false;
            char letra_reiniciar;

            Console.WriteLine("\nDeseja Continuar? Digite S ou N");
            do
            {
                letra_reiniciar = char.ToUpper(Console.ReadKey().KeyChar);

                if (letra_reiniciar == 'S')
                {
                    Console.Clear();
                    reiniciar = true;
                    validaReiniciar = true;
                }
                else if (letra_reiniciar == 'N')
                {
                    reiniciar = false;
                    validaReiniciar = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("\nEntrada Inválida!! Escolha 'S' se deseja válidar outro\n CPF ou 'N' se deseja encerrar o programa");
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
            ValidadorCPF cadastro = new();
            cadastro.ValidaEntrada();

            //Mostrar o resultado na tela
            if(cadastro.ValidaCPF() == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nCPF é válido");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCPF não é válido");
            }
            Console.ResetColor();

            reiniciar = cadastro.Reiniciar();
        }

        Console.WriteLine("Programa Encerrado.");
    }
}
