using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            PosicaoXadrez pos = new PosicaoXadrez('c', 7);
            Console.WriteLine(pos);
            Console.WriteLine(pos.toPosicao());

            //try
            //{
            //    Tabuleiro tab = new Tabuleiro(9, 9);
            //    tab.colocarPecas(new Torre(Cor.Preta, tab), new Posicao(1, 1));
            //    tab.colocarPecas(new Torre(Cor.Preta, tab), new Posicao(1, 3));
            //    tab.colocarPecas(new Rei(Cor.Preta, tab), new Posicao(5, 8));
            //    Tela.imprimirTabuleiro(tab);
            //}
            //catch (TabuleiroException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

        }
    }
}