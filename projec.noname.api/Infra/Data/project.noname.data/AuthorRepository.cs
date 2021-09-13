using Dapper;
using project.noname.core;
using project.noname.data.Interface;
using project.noname.domain.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace project.noname.data
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(ConfigurationManager configuration) : base(configuration)
        {
        }

        public Author GetAuthor(int id)
        {
            Author result = null;
            using (var conexao = new SqlConnection(ConnectionString))
            {

                var query = @"SELECT [ID_AUTHOR] as IdAuthor
                              ,A.NAME as AuthorName
                              ,A.CREATED
							  ,C.NAME as CategoryName
                              ,C.ID_CATEGORY as IdCategory
                          FROM 
                             AUTHOR A
						  INNER JOIN CATEGORY C
						   ON C.ID_CATEGORY = A.ID_CATEGORY
                          WHERE
                               ID_AUTHOR = @Id";

                 result = conexao.Query< Author, Category, Author> (query, (author, category ) =>
                {
                    if (category != null)
                    {
                        author.Category.CategoryName = category.CategoryName;
                        author.Category.IdCategory = category.IdCategory;
                    }
                    return author;

                }, new { @Id = id }, splitOn: "AuthorName, CategoryName").FirstOrDefault();
            }

            return result;
        }

        public List<Author> GetAuthors()
        {
            List<Author> result = null;
            using (var conexao = new SqlConnection(ConnectionString))
            {

                var query = @"SELECT [ID_AUTHOR] as IdAuthor
                              ,A.NAME as AuthorName
                              ,A.CREATED
							  ,C.NAME as CategoryName
                              ,C.ID_CATEGORY as IdCategory
                          FROM 
                             AUTHOR A
						  INNER JOIN CATEGORY C
						   ON C.ID_CATEGORY = A.ID_CATEGORY";

                result = conexao.Query<Author, Category, Author>(query, (author, category) =>
                {
                    if (category != null)
                    {
                        author.Category.CategoryName = category.CategoryName;
                        author.Category.IdCategory = category.IdCategory;

                    }
                    return author;

                }, splitOn: "AuthorName, CategoryName").ToList() ;
            }

            return result;
        }

        public void InsertAuthor(string name, int idCategory)
        {

            var query = @"INSERT INTO [nonameproject].[dbo].[AUTHOR] VALUES (@Name, GETDATE(), @IdCategory)";

            Execute(query, new { Name = name, IdCategory = idCategory });
        }

        public void UpdateAuthor(int id, string name, int idCategory)
        {
            var query  = @"UPDATE [nonameproject].[dbo].[AUTHOR] SET NAME = @Name, ID_CATEGORY  = @IdCategory WHERE ID_AUTHOR = @Id";

            Execute(query, new { Id = id, Name = name, IdCategory = idCategory });
        }

        public List<Category> GetAllCategory()
        {
            var query = @"SELECT 
                            ID_CATEGORY as IdCategory,
                            NAME as CategoryName
                         FROM CATEGORY";


            var result = GetAll<Category>(query);

            return result.ToList();
        }
    }
}
