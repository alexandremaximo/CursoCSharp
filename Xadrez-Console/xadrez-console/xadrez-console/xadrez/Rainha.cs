using tabuleiro;

namespace xadrez
{
    internal class Rainha : Peca
    {
        public Rainha(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
        }
        public override string ToString()
        {
            return "r";
        }
        public override bool[,] movimentosPossiveis()
        {
            return null;
        }
    }
}
