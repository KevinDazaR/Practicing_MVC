using NewCelsia.Data;
using NewCelsia.Models;

namespace NewCelsia.Services.Interfaces{
    public interface IClienteRepository{
        IEnumerable<Cliente> GetAll ();
        Cliente GetById (int Id);
        public void CrearCliente (Cliente cliente,string password);
        public void UpdateBook(int Id, Cliente book);
        public void DeleteBook(int Id);
    }
}