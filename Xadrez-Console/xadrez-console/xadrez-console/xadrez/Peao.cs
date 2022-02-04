using tabuleiro;

namespace xadrez
{
    internal class Peao : Peca
    {
        public Peao(Cor cor, Tabuleiro tab) : base(cor, tab)
        {
        }
        public override string ToString()
        {
            return "P";
        }
        public override bool[,] movimentosPossiveis()
        {
            return null;
        }
    }
}
