using tabuleiro;

namespace xadrez
{
    internal class Bispo : Peca
    {
        public Bispo(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
        }
        public override string ToString()
        {
            return "B";
        }
        public override bool[,] movimentosPossiveis()
        {
            return null;
        }
    }
}
