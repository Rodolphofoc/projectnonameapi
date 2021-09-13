using Newtonsoft.Json;
using System;

namespace project.noname.domain.Models
{
    public class Author
    {
        public Author()
        {
            Category = new Category();
        }

        public int IdAuthor { get; set; }

        public string AuthorName { get; set; }

        public Category Category { get; set; }
    }
}
