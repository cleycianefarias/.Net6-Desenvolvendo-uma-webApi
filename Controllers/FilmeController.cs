using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new List<Filme>();
    private static int id = 0;

    [HttpPost]
    //inserindo filmes
    public IActionResult AdicionaFilme([FromBody]Filme filme)
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

        filme.Id = id++;
        filmes.Add(filme);
        return CreatedAtAction(nameof(RecuperaFilmePorId), new {id = filme.Id}, filme);
    }


    [HttpGet]
    //recupera todos os filmes correspondentes
    public IEnumerable<Filme> RecuperaFilme([FromQuery]int skip = 0, [FromQuery]int take = 50)
    {
        return filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    //recupera filme por id
    public IActionResult RecuperaFilmePorId(int id)
    {
        var filme = filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme ==null)
        {
            return NotFound();

        }
        return Ok(filme);
    }

    //paginação: posso pegar trechos reduzidos em .nt


}
