//O Jogo do Marciano consiste de uma brincadeira de adivinhação. O jogador deve descobrir em que árvore o marciano está escondido. 
//Ele deve tentar acertar digitando o número da árvore onde o marciano estaria escondido. Esse número varia de 1 a 100. 
//A cada tentativa, o jogo informa se o marciano está naquela árvore ou em uma árvore de número menor ou maior. 
//Cada tentativa é computada para que no final seja exibido o número total de tentativas até encontrar o marciano.

using System;
using System.ComponentModel.Design;
using System.Dynamic;



    
void GameMarciano() 
{
    void ContarHistoria()
    {
        void Titulo()
        {
            foreach (char letra in "O Mistério do Marciano Perdido")
            {
                Console.Write(letra);
                Thread.Sleep(50); // Ajuste o tempo para controlar a velocidade do efeito
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        void PrimeiraEstrofe()
        {
            foreach (char letra in "Em um planeta distante chamado Xylox, um pequeno marciano chamado Zorp se perdeu enquanto explorava a Floresta das Mil Árvores. Ele adora brincar de esconde-esconde, mas dessa vez foi longe demais e agora ninguém consegue encontrá-lo!")
            {
                Console.Write(letra);
                Thread.Sleep(10); // Ajuste o tempo para controlar a velocidade do efeito
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        void SegundaEstrofe()
        {
            foreach (char letra in "Você é um explorador intergaláctico e recebeu uma missão muito importante: encontrar Zorp antes que a noite caia e ele fique com medo no meio da floresta.")
            {
                Console.Write(letra);
                Thread.Sleep(10); // Ajuste o tempo para controlar a velocidade do efeito
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        void TerceiraEstrofe()
        {
            foreach (char letra in "A única pista que você tem é que Zorp está escondido em uma árvore numerada de 1 a 100. Seu comunicador intergaláctico consegue detectar a posição aproximada de Zorp e te dirá se ele está escondido em uma árvore de número maior ou menor do que o que você tentou.")
            {
                Console.Write(letra);
                Thread.Sleep(10); // Ajuste o tempo para controlar a velocidade do efeito
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        void Conclusão()
        {
            foreach (char letra in "Será que você consegue encontrar o pequeno marciano antes que ele se assuste? Boa sorte, explorador! 🚀👽")
            {
                Console.Write(letra);
                Thread.Sleep(30); // Ajuste o tempo para controlar a velocidade do efeito
            }

            Console.WriteLine("\nPressione qualquer tecla para iniciar...");
            Console.ReadKey();
            Console.Clear();
        }

        Titulo();
        PrimeiraEstrofe();
        SegundaEstrofe();
        TerceiraEstrofe();
        Conclusão();
    }

    void Game()
    {
        Random rand = new Random();
        int arvoreMarciano = rand.Next(1, 101);
        int arvore = 0;
        int numeroTentativa = 0;
        bool marcianoEncontrado = false;
        int tempoLimite = 10; // Tempo em segundos para o jogador responder

        foreach (char letra in "Adivinhe a Árvore do Marciano")
        {
            Console.Write(letra);
            Thread.Sleep(50);
        }
        Console.WriteLine("\n");

        while (!marcianoEncontrado)
        {
            Console.WriteLine($"\nSua última tentativa: {arvore}");
            Console.WriteLine($"Número de Tentativas: {numeroTentativa}");
            Console.WriteLine($"Você tem {tempoLimite} segundos para responder!");
            Console.Write("Digite um número da árvore onde o Marciano possa estar: ");

            string opcaoEscolhida = "";
            Task<string?> inputTask = Task.Run(() => Console.ReadLine());

            // Espera a entrada do usuário ou o tempo limite
            Task completedTask = Task.WhenAny(inputTask, Task.Delay(TimeSpan.FromSeconds(tempoLimite))).Result;

            if (completedTask == inputTask) // O usuário digitou a tempo
            {
                opcaoEscolhida = inputTask.Result ?? "";

                // Evita erro caso o usuário digite algo que não seja um número
                if (!int.TryParse(opcaoEscolhida, out arvore) || arvore < 1 || arvore > 100)
                {
                    Console.WriteLine("Entrada inválida! Digite um número entre 1 e 100.");
                    Thread.Sleep(2000);
                    Console.Clear();
                    continue;
                }

                numeroTentativa++;

                if (arvore == arvoreMarciano)
                {
                    Console.Clear();
                    Console.WriteLine($"🎉 Parabéns! O Marciano estava na árvore {arvoreMarciano}.");
                    Console.WriteLine($"Você encontrou em {numeroTentativa} tentativas.");
                    marcianoEncontrado = true;
                    Thread.Sleep(5000);
                }
                else if (arvore > arvoreMarciano)
                {
                    Console.WriteLine("O Marciano está em uma árvore menor!");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("O Marciano está em uma árvore maior!");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            else // O tempo se esgotou antes da resposta
            {
                Console.WriteLine("\n⏳ Tempo esgotado! O Marciano fugiu para outra árvore!");
                arvoreMarciano = rand.Next(1, 101);
                Thread.Sleep(2000);
                Console.Clear();
            }
        }
    }


    void NovaPartida()
    {
        bool iraSair = false;

        while (!iraSair)
        {
            Console.Write("\nGostaria de Jogar Novamente? s/n:");
            string opcaoEscolhida = Console.ReadLine();

            opcaoEscolhida = opcaoEscolhida.ToLower();

            if (opcaoEscolhida == "s")
            {
                Console.Clear();
                Game();
            }
            else if (opcaoEscolhida == "n")
            {
                Console.Clear();
                Console.WriteLine("Até um outro dia.");
                Thread.Sleep(3000);
                iraSair = true;
            }
            else
            {
                Console.WriteLine("Opção Invalida");
            }
        }


    }

    ContarHistoria();
    Game();
    Console.Clear();
    NovaPartida();

}


void TelaInicial()
{
    Console.Clear();
    Console.WriteLine("\nJogo do Marciano");
    Console.WriteLine("Digite 1 para iniciar");
    Console.WriteLine("Digire 2 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);


    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            Console.Clear();
            GameMarciano();
            break;
        case 2:
            Console.WriteLine("Você digitou a opção " + opcaoEscolhida);
            Console.WriteLine("Tchau tchau :)");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}

GameMarciano();
