Console.Write("<----Jogo da Velha---->");
Console.WriteLine("\n");

int[,] jogo = new int[3, 3]
{
    { 2,9,4 },
    { 7,5,3 },
    { 6,1,8 }
};
int[,] historico = new int[3, 3]
{
    { 0,0,0 },
    { 0,0,0 },
    { 0,0,0 }
};
int[,] user1 = new int[3, 3]
{
    { 0,0,0 },
    { 0,0,0 },
    { 0,0,0 }
};
int[,] user2 = new int[3, 3]
{
    { 0,0,0 },
    { 0,0,0 },
    { 0,0,0 }
};
int x = 0, y = 0; //Posição
int jogador = 1, somaL = 0, somaC = 0;
int q1 = 0, q2 = 0;//Quantidade de jogadas do jogador
bool valido, vitoria = false;

do
{
    //---JOGADOR 1---
    //EXIBICAO DO JOGO
    for (x = 0; x < 3; x++)
    {
        for (y = 0; y < 3; y++)
        {
            Console.Write("{0} ", historico[x, y]);
        }
        Console.WriteLine();
    }

    //Já foi escolhido antes??
    do
    {
        //Validação da Posição a Jogar
        do
        {
            Console.Write("\nJogador {0}, digite a linha: ", jogador);
            valido = int.TryParse(Console.ReadLine(), out x);

            if (!valido || x <= 0 || x > 3)
            {
                Console.WriteLine("Caractere não permitido, opção 1, 2 ou 3.");
                Console.WriteLine();
            }
        } while (!valido);

        do
        {
            Console.Write("Jogador {0}, digite a coluna: ", jogador);
            valido = int.TryParse(Console.ReadLine(), out y);

            if (!valido || y <= 0 || y > 3)
            {
                Console.WriteLine("Caractere não permitido, opção 1, 2 ou 3.");
                Console.WriteLine();
            }
        } while (!valido);

        x--;
        y--;
        if (historico[x, y] != 0)
        {
            Console.WriteLine("\nLocal já foi escolhido, tente novamente.");
        }
    } while (historico[x, y] != 0);
    q1++;
    jogador++;
    historico[x, y] = 1;
    user1[x, y] = jogo[x, y];

    //A partir de três entradas, verificar a soma
    if (q1 >= 3)
    {
        //fechou na linha?
        for (x = 0; x < 3; x++)
        {
            somaL = 0;
            for (y = 0; y < 3; y++)
            {
                somaL += user1[x, y];
            }
            if (somaL == 15)
            {
                vitoria = true;
            }
        }
        //fechou na coluna?
        for (y = 0; y < 3; y++)
        {
            somaC = 0;
            for (x = 0; x < 3; x++)
            {
                somaC += user1[x, y];
            }
            if (somaC == 15)
            {
                vitoria = true;
            }
        }
        //fechou as diagonais??
        if (user1[0, 0] + user1[1, 1] + user1[2, 2] == 15 || user1[2, 0] + user1[1, 1] + user1[0, 2] == 15)
        {
            vitoria = true;
        }
    }

    //-----------------------------
    if (!vitoria && q1 <= 4)
    {
        //---JOGADOR 2---
        Console.WriteLine();
        //EXIBICAO DA JOGO
        for (x = 0; x < 3; x++)
        {
            for (y = 0; y < 3; y++)
            {
                Console.Write("{0} ", historico[x, y]);
            }
            Console.WriteLine();
        }
        //Já foi escolhido antes??
        do
        {
            //Validação da Posição a Jogar
            do
            {
                Console.Write("\nJogador {0}, digite a linha: ", jogador);

                valido = int.TryParse(Console.ReadLine(), out x);

                if (!valido || x <= 0 || x > 3)
                {
                    Console.WriteLine("Caractere não permitido, opção 1, 2 ou 3.");
                    Console.WriteLine();

                }
            } while (!valido);
            do
            {
                Console.Write("Jogador {0}, digite a coluna: ", jogador);

                valido = int.TryParse(Console.ReadLine(), out y);

                if (!valido || y <= 0 || y > 3)
                {
                    Console.WriteLine("Caractere não permitido, opção 1, 2 ou 3.");
                    Console.WriteLine();
                }
            } while (!valido);

            x--;
            y--;
            if (historico[x, y] != 0)
            {
                Console.WriteLine("\nLocal já foi escolhido, tente novamente.");
            }
        } while (historico[x, y] != 0);

        q2++;
        jogador--;
        historico[x, y] = 2;
        user2[x, y] = jogo[x, y];

        //A partir de três entradas, verificar a soma
        if (q2 >= 3)
        {
            //fechou na linha?
            for (x = 0; x < 3; x++)
            {
                somaL = 0;
                for (y = 0; y < 3; y++)
                {
                    somaL += user2[x, y];
                }
                if (somaL == 15)
                {
                    vitoria = true;
                }
            }

            //fechou na coluna?
            for (y = 0; y < 3; y++)
            {
                somaC = 0;
                for (x = 0; x < 3; x++)
                {
                    somaC += user2[x, y];
                }
                if (somaC == 15)
                {
                    vitoria = true;
                }
            }
            //fechou pelas diagonais
            if (user2[0, 0] + user2[1, 1] + user2[2, 2] == 15 || user2[2, 0] + user2[1, 1] + user2[0, 2] == 15)
            {
                vitoria = true;
            }

            if (vitoria == true)
            {
                Console.WriteLine();
                //RESULTADO FINAL
                for (x = 0; x < 3; x++)
                {
                    for (y = 0; y < 3; y++)
                    {
                        Console.Write("{0} ", historico[x, y]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("\nJogador 2 venceu!!");
                break;
            }
        }
        Console.WriteLine();
    }
    else if (vitoria == true)
    {
        Console.WriteLine();
        //RESULTADO FINAL
        for (x = 0; x < 3; x++)
        {
            for (y = 0; y < 3; y++)
            {
                Console.Write("{0} ", historico[x, y]);
            }
            Console.WriteLine();
        }
        Console.WriteLine("\nJogador 1 venceu!!");
        break;
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Vish!! Deu velha.");
        break;
    }
} while (!vitoria);
