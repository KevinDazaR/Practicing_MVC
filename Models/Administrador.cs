
using System.Text.Json.Serialization;
using NewCelsia.Data;

namespace NewCelsia.Models{
    public class Administrador{
        public int Id { get; set;}       
        public string? Correo {get; set;}
        public string? Contraseña {get; set;}
        
    }
}