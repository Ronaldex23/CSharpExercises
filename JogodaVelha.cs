class Program
{
    class JogoVelha
    {
        private char[,] jogo = new char[3, 3];
        private int[,] user1 = new int[3, 3];
        private int[,] user2 = new int[3, 3];
        private char[] valoresIniciais = { '2', '9', '4', '7', '5', '3', '6', '1', '8' };
        public JogoVelha()
        {
            int x, y;
            int i = 0; //controlador do array valoresIniciais

            //recebendo os valores para o jogo da velha
            for (x = 0; x < 3; x++)
            {
                for (y = 0; y < 3; y++)
                {
                    jogo[x, y] = valoresIniciais[i];
                    i++;
                }
            }

            //setando 0 por padrão nas matrizes dos usuários
            for (x = 0; x < 3; x++)
            {
                for (y = 0; y < 3; y++)
                {
                    user1[x, y] = 0;
                    user2[x, y] = 0;
                }
            }

        }
        public void Exibir()
        {
            int x, y;

            Console.Clear();
            Console.WriteLine("<------ Jogo da Velha ------>");
            Console.WriteLine("Jogador 1 = X | Jogador 2 = O");
            Console.WriteLine();

            for (x = 0; x < 3; x++)
            {
                for (y = 0; y < 3; y++)
                {
                    char c = jogo[x, y];
                    switch (c) // muda a cor dependendo do caractere
                    {
                        case 'X': Console.ForegroundColor = ConsoleColor.Red; ; break;
                        case 'O': Console.ForegroundColor = ConsoleColor.Blue; break;
                        default: Console.ForegroundColor = ConsoleColor.White; break;
                    }
                    Console.Write($"{c} ");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
            Console.WriteLine();
        }
        public bool ValidaEntrada(int num_jogador)
        {
            bool entradaValida;
            char posicao;
            int numero;

            Console.Write("[Jogador {0}] Digite o número correspondente à posição desejada: ", num_jogador);

            do//validando a entrada do jogador
            {
                posicao = char.ToUpper(Console.ReadKey().KeyChar);
                if (posicao >= '1' && posicao <= '9')
                {
                    entradaValida = true;
                }
                else
                {
                    Console.WriteLine("\nEntrada não é válida. Digite um dos números (1 à 9) correspondentes à posição desejada que ainda não foi escolhida");
                    entradaValida = false;
                }
            } while (!entradaValida);

            //posicao já foi ocupada?
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (jogo[x, y] == posicao) //se não foi ocupada, prossiga...
                    {
                        numero = posicao - '0'; //convertendo o número para armazenar
                        ArmazenaJogada(num_jogador, numero, x, y);
                        return true;
                    }
                }
            }

            return false;//se chegou aqui, já foi ocupada, repita a entrada
        }
        private void ArmazenaJogada(int num_jogador, int numero, int x, int y)
        {
            if (num_jogador == 1)
            {
                user1[x, y] = numero;
                jogo[x, y] = 'X';
            }
            else
            {
                user2[x, y] = numero;
                jogo[x, y] = 'O';
            }
        }
        public bool ValidaVitoria(int num_jogador)
        {
            int[,] usuario = (num_jogador == 1) ? user1 : user2;
            int somaL, somaC; //somatórias de linhas e coluna
            int x, y;

            //fechou na linha?
            for (x = 0; x < 3; x++)
            {
                somaL = 0;
                for (y = 0; y < 3; y++)
                {
                    somaL += usuario[x, y];
                }
                if (somaL == 15)
                {
                    return true;
                }
            }

            //fechou na coluna?
            for (y = 0; y < 3; y++)
            {
                somaC = 0;
                for (x = 0; x < 3; x++)
                {
                    somaC += usuario[x, y];
                }
                if (somaC == 15)
                {
                    return true;
                }
            }

            //fechou as diagonais??
            if (usuario[0, 0] + usuario[1, 1] + usuario[2, 2] == 15 || usuario[2, 0] + usuario[1, 1] + usuario[0, 2] == 15)
            {
                return true;
            }

            //ainda não tem vencedor?
            return false;
        }
        public bool Reiniciar()
        {
            char reiniciar;
            bool validaReiniciar;

            Console.WriteLine("\nDeseja continuar? Digite S ou N");
            do
            {
                reiniciar = char.ToUpper(Console.ReadKey().KeyChar);
                if (reiniciar == 'S' || reiniciar == 'N')
                {
                    validaReiniciar = true;
                }
                else
                {
                    validaReiniciar = false;
                    Console.WriteLine();
                    Console.WriteLine("\nValor inválido!! Escolhe 'S' para sim ou 'N' para não");
                }
            } while (!validaReiniciar);

            switch (reiniciar)
            {
                case 'S': return true;
                default: return false;
            }
        }
    }

    static void Main(string[] args)
    {
        bool validaPosicao, reiniciar = true;
        int jogadas, n;

        while (reiniciar)
        {
            jogadas = 1;
            n = 1;
            JogoVelha jogador = new();

            while (jogadas <= 9)
            {
                do
                {
                    jogador.Exibir();
                    validaPosicao = jogador.ValidaEntrada(n);

                    if (!validaPosicao)
                    {
                        Console.Write("\nEssa posição já ocupada. Pressione Enter e tente novamente");
                        Console.ReadKey();
                    }
                } while (!validaPosicao);

                jogadas++;

                if (jogador.ValidaVitoria(n))
                {
                    jogador.Exibir(); //placar atualizado
                    Console.Write("Jogador {0} venceu!!", n);
                    jogadas = 10; //sair do loop ou break
                }
                else if (jogadas <= 9)
                {
                    Console.WriteLine();
                    Console.WriteLine("\nSua jogada foi computada!!");
                    Console.Write("Pressione Enter para continuar...");
                    Console.ReadKey();

                    if (jogadas % 2 == 1) //controle de jogador 1 ou 2
                    {
                        n = 1;
                    }
                    else
                    {
                        n = 2;
                    }
                }
                else
                {
                    jogador.Exibir(); //placar atualizado
                    Console.WriteLine("Vish!! Deu velha");
                    jogadas = 10; //sair do loop ou break
                }
            }

            reiniciar = jogador.Reiniciar();
        }
        Console.WriteLine();
        Console.WriteLine("\nPrograma encerrado");
    }
}
