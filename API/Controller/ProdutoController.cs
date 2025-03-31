using System;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/produto")]
public class ProdutoController : ControllerBase
{
    //Exemplo de método dentro de uma classe
    [HttpGet]
    public string Metodo()
    {
        return "";
    }

    //Exemplo de um EndPoint dentro de um Controller
    [HttpGet("helloworld")]
    public IActionResult HelloWorld()
    {
        return Ok("Hello World!");
    }
}
