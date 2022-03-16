using BlazorCompuTronica.Data.Model;

namespace BlazorCompuTronica.Data.Service
{
    public interface IClienteService
    {
        Task<bool> ClienteInsert(Cliente cliente);
    }
}