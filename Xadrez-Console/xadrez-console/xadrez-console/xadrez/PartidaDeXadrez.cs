using tabuleiro;
using System.Collections.Generic;

namespace xadrez
{
    internal class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool xeque { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            xeque = false;
            colocarPecas();
        }
        public Peca executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPecas(p, destino);
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }

            //#Jogada especial ROQUE PEQUENO
            if (p is Rei && destino.coluna == origem.coluna + 2)
            {
                Posicao origemT = new Posicao(origem.linha, origem.coluna + 3);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna + 1);
                Peca T = tab.retirarPeca(origemT);
                T.incrementarQtdMovimentos();
                tab.colocarPecas(T, destinoT);
            }
            //#Jogada especial ROQUE GRANDE
            if (p is Rei && destino.coluna == origem.coluna - 2)
            {
                Posicao origemT = new Posicao(origem.linha, origem.coluna - 4);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna - 1);
                Peca T = tab.retirarPeca(origemT);
                T.incrementarQtdMovimentos();
                tab.colocarPecas(T, destinoT);
            }
            return pecaCapturada;
        }
        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.retirarPeca(destino);
            p.decrementarQtdMovimentos();
            if (pecaCapturada != null)
            {
                tab.colocarPecas(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.colocarPecas(p, origem);
            //#Jogada especial ROQUE PEQUENO
            if (p is Rei && destino.coluna == origem.coluna + 2)
            {
                Posicao origemT = new Posicao(origem.linha, origem.coluna + 3);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna + 1);
                Peca T = tab.retirarPeca(destinoT);
                T.incrementarQtdMovimentos();
                tab.colocarPecas(T, origemT);
            }
            //#Jogada especial ROQUE GRANDE
            if (p is Rei && destino.coluna == origem.coluna - 2)
            {
                Posicao origemT = new Posicao(origem.linha, origem.coluna - 4);
                Posicao destinoT = new Posicao(origem.linha, origem.coluna - 1);
                Peca T = tab.retirarPeca(destinoT);
                T.incrementarQtdMovimentos();
                tab.colocarPecas(T, origemT);
            }

        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = executaMovimento(origem, destino);
            if (estaEmXeque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
            }
            if (estaEmXeque(adversaria(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

            if (testaXequemate(adversaria(jogadorAtual)))
            {
                terminada = true;
            }
            else
            {
                turno++;
                mudaJogador();
            }
        }
        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }
            if (jogadorAtual != tab.peca(pos).cor)
            {
                throw new TabuleiroException("A peça esolhida não é sua");
            }
            if (!tab.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }
        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).movimentoPossivel(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }
        private void mudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }
        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }
        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas)
            {
                if (x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }
        private Cor adversaria(Cor cor)
        {
            if (cor == Cor.Preta)
            {
                return Cor.Branca;
            }
            else
            {
                return Cor.Preta;
            }

        }
        private Peca rei(Cor cor)
        {
            foreach (Peca x in pecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }

            }
            return null;
        }
        public bool estaEmXeque(Cor cor)
        {
            Peca R = rei(cor);
            if (R == null)
            {
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro!");
            }
            foreach (Peca x in pecasEmJogo(adversaria(cor)))
            {
                bool[,] mat = x.movimentosPossiveis();
                if (mat[R.posicao.linha, R.posicao.coluna])
                {
                    return true;
                }
            }
            return false;
        }
        public bool testaXequemate(Cor cor)
        {
            if (!estaEmXeque(cor))
            {
                return false;
            }
            foreach (Peca x in pecasEmJogo(cor))
            {
                bool[,] mat = x.movimentosPossiveis();
                for (int l = 0; l < tab.linhas; l++)
                {
                    for (int c = 0; c < tab.colunas; c++)
                    {
                        if (mat[l, c])
                        {
                            Posicao origem = x.posicao;
                            Posicao destino = new Posicao(l, c);
                            Peca pecaCapturada = executaMovimento(origem, destino);
                            bool testeXeque = estaEmXeque(cor);
                            desfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }

                }
            }
            return true;
        }
        private void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPecas(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }
        private void colocarPecas()
        {
            colocarNovaPeca('a', 1, new Torre(Cor.Branca, tab));
            colocarNovaPeca('b', 1, new Cavalo(Cor.Branca, tab));
            colocarNovaPeca('c', 1, new Bispo(Cor.Branca, tab));
            colocarNovaPeca('d', 1, new Rainha(Cor.Branca, tab));
            colocarNovaPeca('e', 1, new Rei(Cor.Branca, tab, this));
            colocarNovaPeca('f', 1, new Bispo(Cor.Branca, tab));
            colocarNovaPeca('g', 1, new Cavalo(Cor.Branca, tab));
            colocarNovaPeca('h', 1, new Torre(Cor.Branca, tab));

            colocarNovaPeca('a', 2, new Peao(Cor.Branca, tab));
            colocarNovaPeca('b', 2, new Peao(Cor.Branca, tab));
            colocarNovaPeca('c', 2, new Peao(Cor.Branca, tab));
            colocarNovaPeca('d', 2, new Peao(Cor.Branca, tab));
            colocarNovaPeca('e', 2, new Peao(Cor.Branca, tab));
            colocarNovaPeca('f', 2, new Peao(Cor.Branca, tab));
            colocarNovaPeca('g', 2, new Peao(Cor.Branca, tab));
            colocarNovaPeca('h', 2, new Peao(Cor.Branca, tab));

            colocarNovaPeca('a', 8, new Torre(Cor.Preta, tab));
            colocarNovaPeca('b', 8, new Cavalo(Cor.Preta, tab));
            colocarNovaPeca('c', 8, new Bispo(Cor.Preta, tab));
            colocarNovaPeca('d', 8, new Rainha(Cor.Preta, tab));
            colocarNovaPeca('e', 8, new Rei(Cor.Preta, tab, this));
            colocarNovaPeca('f', 8, new Bispo(Cor.Preta, tab));
            colocarNovaPeca('g', 8, new Cavalo(Cor.Preta, tab));
            colocarNovaPeca('h', 8, new Torre(Cor.Preta, tab));

            colocarNovaPeca('a', 7, new Peao(Cor.Preta, tab));
            colocarNovaPeca('b', 7, new Peao(Cor.Preta, tab));
            colocarNovaPeca('c', 7, new Peao(Cor.Preta, tab));
            colocarNovaPeca('d', 7, new Peao(Cor.Preta, tab));
            colocarNovaPeca('e', 7, new Peao(Cor.Preta, tab));
            colocarNovaPeca('f', 7, new Peao(Cor.Preta, tab));
            colocarNovaPeca('g', 7, new Peao(Cor.Preta, tab));
            colocarNovaPeca('h', 7, new Peao(Cor.Preta, tab));
        }
    }
}
