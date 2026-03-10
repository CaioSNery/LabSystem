using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemLab.Models;
using SystemLab.Repositories;

namespace SystemLab.Services
{
    public class ProdutoService
    {
        private readonly ProdutoRepository _repository;
        
        public ProdutoService(ProdutoRepository repository)
        {
            _repository=repository;
        }


        public List<Produto> GetProdutos()
        {
            Thread.Sleep(3000);
            return _repository.GetAll();
        }

        public void Create(Produto produto)
        {
            _repository.Add(produto);
        }
    }

}