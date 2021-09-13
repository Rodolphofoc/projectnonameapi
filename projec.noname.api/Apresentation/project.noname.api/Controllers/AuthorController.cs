using Microsoft.AspNetCore.Mvc;
using project.noname.api.Model;
using project.noname.service.Interface;
using System;

namespace project.noname.api.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController : BaseController
    {
        private IAuthorService services;


        public AuthorController(IAuthorService authorService)
        {
            services = authorService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetAuthor(int id)
        {
            try
            {

                var result = services.GetAuthor(id);

                return Response(result);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }


        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            try
            {
                var result = services.GetAuthors();

                return Response(result);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult InsertAuthor([FromBody] AuthorViewModel author)
        {
            try
            {
                if (author == null)
                {
                    NotificaErroModelState();
                    return BadRequest(new
                    {
                        success = false,
                        errors = "Nome invalido"
                    });
                }

                if (string.IsNullOrEmpty(author.Name))
                {
                    NotificaErroModelState();
                    return BadRequest(new
                    {
                        success = false,
                        errors = "Nome invalido"
                    });
                }


                var result = services.InsertAuthor(new domain.Models.Author()
                {
                    AuthorName = author.Name,
                    Category = new domain.Models.Category()
                    {
                        IdCategory = author.IdCategory
                    }

                });

                return Response(result);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult AlterAuthor(int id, [FromBody]AuthorViewModel author)
        {
            try
            {
                if (string.IsNullOrEmpty(author.Name) || id <= 0)
                {
                    NotificaErroModelState();
                    return BadRequest(new
                    {
                        success = false,
                        errors = "Nome ou id invalido"
                    });
                }


                var result = services.UpdateAuthor(id, new domain.Models.Author()
                {
                    AuthorName = author.Name,
                    Category = new domain.Models.Category()
                    {
                        IdCategory = author.IdCategory
                    }
                });

                return Response(result);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }
}
