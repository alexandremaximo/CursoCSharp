using tabuleiro;
using xadrez;


namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            //PosicaoXadrez pos = new PosicaoXadrez('c', 7);
            //Console.WriteLine(pos);
            //Console.WriteLine(pos.toPosicao());

            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tab);
                    Console.WriteLine();
                    Console.Write("Origem:");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                    Console.Write("Destino:");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                    partida.executaMovimento(origem, destino);
                }
                //Tabuleiro tab = new Tabuleiro(8, 8);
                //tab.colocarPecas(new Torre(Cor.Preta, tab), new Posicao(1, 1));
                //tab.colocarPecas(new Torre(Cor.Preta, tab), new Posicao(1, 3));
                //tab.colocarPecas(new Rei(Cor.Branca, tab), new Posicao(5, 7));
                //Tela.imprimirTabuleiro(tab);
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}