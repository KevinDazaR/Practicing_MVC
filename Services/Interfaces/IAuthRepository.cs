using NewCelsia.Data;
using NewCelsia.Models;

namespace NewCelsia.Services.Interfaces{
    public interface IAuthRepository{
        Administrador Login(string UserName, string Password);
        string GenerateToken(Administrador User);
        void LogOutAsync();
        IEnumerable<Administrador> GetAll();
    }
}