using xadrez;
using tabuleiro;


namespace xadrez_console
{
    internal class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int l = 0; l < tab.linhas; l++)
            {
                Console.Write(8 - l + " ");
                for (int c = 1; c < tab.colunas; c++)
                {

                    if (tab.peca(l, c) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        imprimirPeca(tab.peca(l, c));
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine(" a b c d e f g h");
        }
        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char linha = s[0];
            int coluna = int.Parse(s[1] + "");

            return new PosicaoXadrez( linha, coluna );
        }
        public static void imprimirPeca(Peca peca)
        {
            if (peca.cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}

