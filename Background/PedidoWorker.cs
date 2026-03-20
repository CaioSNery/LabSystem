

using SystemLab.Infrastructure;

namespace LabSystem.Background
{
    public class PedidoWorker : BackgroundService
    {

        private readonly FilaPedidos _fila;

        public PedidoWorker(FilaPedidos fila)
        {
            _fila = fila;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                if (_fila.Fila.TryDequeue(out var pedido))
                {
                    Console.WriteLine($"Processando: {pedido}");
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}