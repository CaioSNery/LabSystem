

using SystemLab.Models;

namespace SystemLab.Repositories
{
    public class ProdutoRepository
    {
        private static readonly List<Produto> _produtos = [
            new Produto{Id=1, Nome="Notebook",Valor=4000},
            new Produto{Id=2, Nome="Mouse",Valor=50}
        ];

        public List<Produto> GetAll()
        {
            return _produtos;
        }

        public void Add(Produto produto)
        {
            produto.Id=_produtos.Count+1;
            _produtos.Add(produto);
        }
    }
}