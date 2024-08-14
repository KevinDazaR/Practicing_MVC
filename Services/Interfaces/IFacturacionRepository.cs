using NewCelsia.Data;
using NewCelsia.Models;

namespace NewCelsia.Services.Interfaces{
    public interface IFacturacionRepository{
        public void CrearFactura (Facturacion factura);
        Facturacion GetById (int Id);
        IEnumerable<Facturacion> GetAll ();
        public void UpdateFactura(int Id, Facturacion facturacion);
        public void DeleteFactura(int Id);
    }
}