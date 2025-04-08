using System;

namespace API.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Email { get; set; }      
    public string Senha { get; set; }      
    public DateTime CriadoEm { get; set; } = DateTime.Now; 
}
