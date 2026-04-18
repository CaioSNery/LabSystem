
using Microsoft.Extensions.Caching.Memory;
using Polly;
using SystemLab.Models;
using SystemLab.Repositories;

namespace SystemLab.Services
{
    public class ProdutoService
    {
        private readonly ProdutoRepository _repository;

        private readonly IMemoryCache _cache;


        public ProdutoService(ProdutoRepository repository, IMemoryCache cache)
        {
            _repository = repository;
            _cache = cache;
        }


        public List<Produto> GetProdutos()
        {

            if (_cache.TryGetValue("produtos", out List<Produto> produtos))
            {
                return produtos;
            }
            Thread.Sleep(3000);
            produtos = _repository.GetAll();

            _cache.Set("produtos", produtos, TimeSpan.FromSeconds(30));

            return produtos;
        }

        public void Create(Produto produto)
        {
            _repository.Add(produto);

            _cache.Remove("produtos");
        }

        public List<Produto> GetProducts()
        {
            throw new Exception("Erro simulado para teste");
        }



        public void SimularChamadaExternaComRetry()
        {
            var retryPolicy = Policy
                .Handle<Exception>()
                .Retry(3, (exception, tentativa) =>
                {
                    Console.WriteLine($"Tentativa {tentativa} falhou: {exception.Message}");
                });

            retryPolicy.Execute(() =>
            {
                Console.WriteLine("Tentando chamar serviço externo...");

                throw new Exception("Erro simulado");
            });
        }




    }

}