using project.noname.data.Interface;
using project.noname.domain.Models;
using project.noname.service.Interface;
using project.noname.service.Models.Helpers;
using System.Collections.Generic;

namespace project.noname.service
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository authorRepository { get; set; }
        private Response _response;

        public AuthorService(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }


        public Response GetAuthor(int id)
        {
            _response = new Response();

            try
            {
                _response.AddValue(authorRepository.GetAuthor(id));
                return _response;
            }
            catch (System.Exception e)
            {
                _response.AddNotification(new Notifications() { Message = e.Message });
                return _response;
            }
        }

        public Response GetAuthors()
        {
            _response = new Response();

            try
            {
                _response.AddValue(authorRepository.GetAuthors());
                //var list = new List<object>();

                //list.Add(new { id = "1", name = "teste" });
                //list.Add(new { id = "1", name = "teste" });
                //list.Add(new { id = "1", name = "teste" });
                //list.Add(new { id = "1", name = "teste" });
                //list.Add(new { id = "1", name = "teste" });

                //_response.AddValue(list);

                return _response;
            }
            catch (System.Exception e)
            {
                _response.AddNotification(new Notifications() { Message = e.Message });
                return _response;
            }
        }


        public Response InsertAuthor(Author author)
        {
            _response = new Response();

            try
            {
               authorRepository.InsertAuthor(author.AuthorName, author.Category.IdCategory);
                return _response;
            }
            catch (System.Exception e)
            {
                _response.AddNotification(new Notifications() { Message = e.Message });
                return _response;
            }
        }

        public Response UpdateAuthor(int id, Author author)
        {
            _response = new Response();

            try
            {
                authorRepository.UpdateAuthor(id, author.AuthorName, author.Category.IdCategory);
                return _response;
            }
            catch (System.Exception e)
            {
                _response.AddNotification(new Notifications() { Message = e.Message });
                return _response;
            }
        }


    }
}
