using tabuleiro;

namespace xadrez
{
    internal class Cavalo : Peca
    {
        public Cavalo(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
        }
        public override string ToString()
        {
            return "C";
        }
        public override bool[,] movimentosPossiveis()
        {
            return null;
        }
    }
}
