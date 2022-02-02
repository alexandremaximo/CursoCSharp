using tabuleiro;

namespace xadrez_console
{
    internal class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int l = 0; l < tab.linha; l++)
            {
                for (int c = 0; c < tab.colunas; c++)
                {
                    if (tab.peca(l, c) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.WriteLine(tab.peca(l, c) + " ");
                    }
                }
                Console.WriteLine();
            }
            
        }
    }
}

