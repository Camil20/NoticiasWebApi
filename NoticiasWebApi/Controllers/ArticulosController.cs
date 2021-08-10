using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoticiasWebApi.Data;
using NoticiasWebApi.Models;

namespace NoticiasWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly ApiNoticiasContext _context;

        public ArticulosController(ApiNoticiasContext context)
        {
            _context = context;
        }

        // GET: api/Articulos
        [HttpGet]
        [AllowAnonymous]
        public ActionResult GetArticles()
        {

            var query = _context.Articulos.AsQueryable();

            var articles = query.Select(articles => new ArticulosDto
            {
                Titulo = articles.Titulo,
                Descripcion = articles.Descripcion,
                Contenido = articles.Contenido,
                NombreAutor = articles.Autor.NombreAutor,
                UrlToImage = articles.UrlToImage,
                Url = articles.Url,
                FechaPublicacion = articles.FechaPublicacion
            }).ToArray();

            return Ok(articles);
        }

        [HttpGet("{busqueda}")]
        [AllowAnonymous]
        public async Task<ActionResult<Articulo>> GetArticle(String busqueda)
        {
            var query = _context.Articulos.AsQueryable().Where(a => a.Titulo.Contains(busqueda));

            if (!string.IsNullOrEmpty(busqueda))
            {
                query = query.Where(a => a.Titulo.Contains(busqueda));

                var articles = query.Select(articles => new ArticulosDto
                {
                    Titulo = articles.Titulo,
                    Descripcion = articles.Descripcion,
                    Contenido = articles.Contenido,
                    NombreAutor = articles.Autor.NombreAutor,
                    UrlToImage = articles.UrlToImage,
                    Url = articles.Url,
                    FechaPublicacion = articles.FechaPublicacion
                }).ToArray();

                return Ok(articles);

            }
            return NotFound();

        }

        //public async Task<ActionResult<IEnumerable<Articulo>>> GetArticulos()
        //{
        //    return await _context.Articulos.Select(item => new Articulo {

        //    ArticuloId = item.ArticuloId,
        //    Titulo = item.Titulo,
        //    Descripcion = item.Descripcion,
        //    Url = item.Url,
        //    UrlToImage = item.UrlToImage,
        //    FechaPublicacion = item.FechaPublicacion,
        //    Contenido = item.Contenido,
        //    AutorId = item.AutorId,
        //    //CategoriaId = item.CategoriaId,
        //    //PaisId = item.PaisId,
        //    //FuenteId = item.FuenteId

        //    }).ToListAsync();
        //}

        // GET: api/Articulos/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Articulo>> GetArticulo(int id)
        //{
        //    var articulo = await _context.Articulos.FindAsync(id);

        //    if (articulo == null)
        //    {
        //        return NotFound();
        //    }

        //    return articulo;
        //}

        // PUT: api/Articulos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticulo(int id, Articulo articulo)
        {
            if (id != articulo.ArticuloId)
            {
                return BadRequest();
            }

            _context.Entry(articulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticuloExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Articulos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Articulo>> PostArticulo(Articulo articulo)
        {
            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticulo", new { id = articulo.ArticuloId }, articulo);
        }

        // DELETE: api/Articulos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulo(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }

            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArticuloExists(int id)
        {
            return _context.Articulos.Any(e => e.ArticuloId == id);
        }
    }
}
