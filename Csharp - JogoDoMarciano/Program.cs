//O Jogo do Marciano consiste de uma brincadeira de adivinhação. O jogador deve descobrir em que árvore o marciano está escondido. 
//Ele deve tentar acertar digitando o número da árvore onde o marciano estaria escondido. Esse número varia de 1 a 100. 
//A cada tentativa, o jogo informa se o marciano está naquela árvore ou em uma árvore de número menor ou maior. 
//Cada tentativa é computada para que no final seja exibido o número total de tentativas até encontrar o marciano.



using System;

Random rand = new Random();

int arvoreMarciano = rand.Next(1, 101);
int arvore = 0;
int numeroTentativa = 0;
bool marcianoEncontrado = false;

while(marcianoEncontrado == false)
{
    Console.WriteLine("Adivinhe a Árvore do Marciano");
    Console.WriteLine($"Sua ultima tentativa: {arvore}");
    Console.WriteLine($"Numero de Tentativa {numeroTentativa}");
    Console.Write($"Digite um numero da árvore onde o Marciano possa estar: ");
    string opçãoEscolhida = Console.ReadLine()!;
    arvore = int.Parse(opçãoEscolhida);

    if (arvore == arvoreMarciano)
    {
        Console.WriteLine($"Parabéns o Marciano estava na arvore: {arvoreMarciano}");
        marcianoEncontrado = true;
    } else if (arvore > arvoreMarciano)
    {
        Console.WriteLine("O Marciano estar em uma arvore menor!");
        numeroTentativa++;
        Thread.Sleep(2000);
        Console.Clear();
    } else if (arvore < arvoreMarciano)
    {
        Console.WriteLine("O Marciano estar numa arvore maior!");
        numeroTentativa++;
        Thread.Sleep(2000);
        Console.Clear();
    }
    
}

