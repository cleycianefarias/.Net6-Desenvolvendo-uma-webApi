using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();

    [HttpPost]
    //inserindo filmes
    public void AdicionaFilme([FromBody]Filme filme)
    {
        #region
        // O método abaixo funciona, porém não é um método eficiente
        /*if (!string.IsNullOrEmpty(filme.Titulo) &&
            !string.IsNullOrEmpty(filme.Genero) &&
            filme.Duracao>=70){
            filmes.Add(filme);
            Console.WriteLine(filme.Titulo);
            Console.WriteLine(filme.Duracao);
        }*/
        #endregion

        filmes.Add(filme);
        Console.WriteLine(filme.Titulo);
        Console.WriteLine(filme.Duracao);
    }


    [HttpGet]
    //recupera todos os filmes correspondentes
    public IEnumerable<Filme> RecuperaFilme()
    {
        return filmes;
    }

}
