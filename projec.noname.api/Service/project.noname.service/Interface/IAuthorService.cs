using project.noname.domain.Models;
using project.noname.service.Models.Helpers;

namespace project.noname.service.Interface
{
    public interface IAuthorService
    {
        Response GetAuthor(int id);

        Response GetAuthors();

        Response UpdateAuthor(int id, Author author);

        Response InsertAuthor(Author author);

        Response GetAllCategory();
    }
}
