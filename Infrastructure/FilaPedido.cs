using System.Collections.Concurrent;

namespace SystemLab.Infrastructure;

public class FilaPedidos
{
    public ConcurrentQueue<string> Fila { get; } = new();
}