using project.noname.domain.Models;
using System.Collections.Generic;

namespace project.noname.data.Interface
{
    public interface IAuthorRepository
    {
        Author GetAuthor(int id);

        List<Author> GetAuthors();

        void InsertAuthor(string name, int idCategory);

        void UpdateAuthor(int id, string name, int idCategory);

        List<Category> GetAllCategory();
    }
}
