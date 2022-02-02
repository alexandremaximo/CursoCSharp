using tabuleiro;

namespace xadrez_console
{
    internal class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int l = 0; l < tab.linhas; l++)
            {
                if (l == 0)
                {
                    Console.Write("x ");
                }
                else
                {
                    Console.Write(l.ToString() + " ");
                }
                for (int c = 1; c < tab.colunas; c++)
                {
                    if (l == 0)
                    {
                        Console.Write(c.ToString() + " ");
                    }
                    else
                    {
                        if (tab.peca(l, c) == null)
                        {
                            Console.Write("- ");
                        }
                        else
                        {
                            Console.Write(tab.peca(l, c) + " ");
                        }
                    }
                }
                Console.WriteLine();
            }

        }
    }
}

