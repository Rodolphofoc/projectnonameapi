using Microsoft.AspNetCore.Mvc;
using project.noname.api.Model;
using project.noname.service.Interface;
using System;

namespace project.noname.api.Controllers
{
    [Route("api/[controller]")]
    public class MusicController : BaseController
    {
        private IMusicService services;

        /// <summary>
        /// Controler de Musicas
        /// </summary>
        /// <param name="services"></param>
        public MusicController(IMusicService services)
        {
            this.services = services;
        }

        /// <summary>
        /// Retorna a musca detalhada pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetMusic(int id)
        {
            try
            {
                var result = services.GetMusic(id);

                return Response(result);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }


        }

        /// <summary>
        /// Retorna uma musica detalhada pelo id do autor
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("byauthor")]
        public IActionResult GetMusicByAuthor(int author)
        {
            try
            {
                var result = services.GetMusicByAuthor(author);

                return Response(result);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        /// <summary>
        /// Retornar todas as musicas detalhada
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = services.GetMusicAll();

                return Response(result);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        /// <summary>
        /// Insere uma musica
        /// </summary>
        /// <param name="music"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InserMusic([FromBody]MusicViewModel music)
        {
            try
            {
                if (string.IsNullOrEmpty(music.Music) || music.IdAuthor <= 0 || music.TypeMusic <= 0)
                {
                    NotificaErroModelState();
                    return BadRequest(new
                    {
                        success = false,
                        errors = "Dados invalidos, verificar os ids ( autor e tipo de musica deve ser maior que zero )"
                    });
                }


                var result = services.InsertMusic(new domain.Models.Music()
                {
                    MusicName = music.Music,
                    TypeMusic = new domain.Models.TypeMusic()
                    {
                        IdTypeMusic = music.TypeMusic
                    }
                }, music.IdAuthor);

                return Response(result);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        /// <summary>
        /// Atualiza uma musica pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="music"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateMusic(int id, [FromBody] MusicViewModel music)
        {
            try
            {
                if (string.IsNullOrEmpty(music.Music) || music.IdAuthor <= 0 || music.TypeMusic <= 0)
                {
                    NotificaErroModelState();
                    return BadRequest(new
                    {
                        success = false,
                        errors = "Dados invalidos, verificar os ids ( autor e tipo de musica deve ser maior que zero )"
                    });
                }


                var result = services.UpdateMusic(id, new domain.Models.Music()
                {
                    MusicName = music.Music,
                    TypeMusic = new domain.Models.TypeMusic()
                    {
                        IdTypeMusic = music.TypeMusic
                    }
                }, music.IdAuthor); ;

                return Response(result);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }

}
