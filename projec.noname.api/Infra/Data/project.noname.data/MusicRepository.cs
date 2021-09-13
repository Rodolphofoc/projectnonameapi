using Dapper;
using project.noname.core;
using project.noname.data.Interface;
using project.noname.domain.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;


namespace project.noname.data
{
    public class MusicRepository : Repository<Music>, IMusicRepository
    {
        public MusicRepository(ConfigurationManager configuration) : base(configuration)
        {
        }

        public Music GetMusic(int id)
        {

            IEnumerable<Music> result = null;

            var query = @"SELECT
                           M.ID_MUSIC as IdMusic,
                           M.NAME AS MusicName,
                           A.ID_AUTHOR as IdAuthor ,
                           A.NAME AS AuthorName,
                           T.NAME As TypeName,
                           T.ID_TYPE as IdTypeMusic,
                           C.NAME as CategoryName
                         FROM MUSIC M
                         INNER JOIN MUSIC_AUTHOR MA
                           ON MA.ID_MUSIC = M.ID_MUSIC
                         INNER JOIN AUTHOR A
                           ON A.ID_AUTHOR = MA.ID_AUTHOR
                         INNER JOIN TYPE_MUSIC T
                           ON T.ID_TYPE = M.ID_TYPE_MUSIC
	                     INNER JOIN CATEGORY C
						   ON C.ID_CATEGORY = A.ID_CATEGORY
                         WHERE 
                          M.ID_MUSIC = @Id";

            using (var conexao = new SqlConnection(ConnectionString))
            {
                result = conexao.Query<Music, Author, TypeMusic, Category, Music>(query, (music, author, typemusic, category) =>
                {
                    if (author != null)
                    {
                        author.Category.CategoryName = category.CategoryName;
                        music.Authors.Add(author);
                    }
                    
                    if(typemusic != null)
                    {
                        music.TypeMusic.IdTypeMusic = typemusic.IdTypeMusic;
                        music.TypeMusic.TypeName = typemusic.TypeName;
                    }


                    return music;
                }, new { Id = id },
              splitOn: "IdMusic, IdAuthor, TypeName, CategoryName");
            }

              

            return result.FirstOrDefault();
        }

        public List<Music> GetMusicbyAuthor(int idAuthor)
        {
            IEnumerable<Music> result = null;

            var query = @"SELECT
                           M.ID_MUSIC as IdMusic,
                           M.NAME AS MusicName,
                           A.ID_AUTHOR as IdAuthor ,
                           A.NAME AS AuthorName,
                           T.NAME As TypeName,
                           T.ID_TYPE as IdTypeMusic,
                           C.NAME as CategoryName
                         FROM MUSIC M
                         INNER JOIN MUSIC_AUTHOR MA
                           ON MA.ID_MUSIC = M.ID_MUSIC
                         INNER JOIN AUTHOR A
                           ON A.ID_AUTHOR = MA.ID_AUTHOR
                         INNER JOIN TYPE_MUSIC T
                           ON T.ID_TYPE = M.ID_TYPE_MUSIC
	                     INNER JOIN CATEGORY C
						   ON C.ID_CATEGORY = A.ID_CATEGORY
                         WHERE 
                          M.ID_AUTHOR = @Id";

            using (var conexao = new SqlConnection(ConnectionString))
            {
                result = conexao.Query<Music, Author, TypeMusic, Category, Music>(query, (music, author, typemusic, category) =>
                {
                    if (author != null)
                    {
                        author.Category.CategoryName = category.CategoryName;
                        music.Authors.Add(author);
                    }

                    if (typemusic != null)
                    {
                        music.TypeMusic.IdTypeMusic = typemusic.IdTypeMusic;
                        music.TypeMusic.TypeName = typemusic.TypeName;
                    }


                    return music;
                }, new { Id = idAuthor },
              splitOn: "IdMusic, IdAuthor, TypeName, CategoryName");
            }



            return result.ToList();
        }


        public List<Music> GetMusics()
        {
            IEnumerable<Music> result = null;

            var query = @"SELECT
                           M.ID_MUSIC as IdMusic,
                           M.NAME AS MusicName,
                           A.ID_AUTHOR as IdAuthor ,
                           A.NAME AS AuthorName,
                           T.NAME As TypeName,
                           T.ID_TYPE as IdTypeMusic,
                           C.NAME as CategoryName
                         FROM MUSIC M
                         INNER JOIN MUSIC_AUTHOR MA
                           ON MA.ID_MUSIC = M.ID_MUSIC
                         INNER JOIN AUTHOR A
                           ON A.ID_AUTHOR = MA.ID_AUTHOR
                         INNER JOIN TYPE_MUSIC T
                           ON T.ID_TYPE = M.ID_TYPE_MUSIC
	                     INNER JOIN CATEGORY C
						   ON C.ID_CATEGORY = A.ID_CATEGORY";

            using (var conexao = new SqlConnection(ConnectionString))
            {
                result = conexao.Query<Music, Author, TypeMusic, Category, Music>(query, (music, author, typemusic, category) =>
                {
                    if (author != null)
                    {
                        author.Category.CategoryName = category.CategoryName;
                        music.Authors.Add(author);
                    }

                    if (typemusic != null)
                    {
                        music.TypeMusic.IdTypeMusic = typemusic.IdTypeMusic;
                        music.TypeMusic.TypeName = typemusic.TypeName;
                    }


                    return music;
                },
              splitOn: "IdMusic, IdAuthor, TypeName, CategoryName");
            }



            return result.ToList();
        }

        public void InsertMusic(string name, int typeMusic, int idAuthor)
        {
            using (var conexao = new SqlConnection(ConnectionString))
            {
                conexao.Open();

                using (var transactionScope = new TransactionScope())
                {
                    try
                    {
                        var query = @"INSERT INTO [nonameproject].[dbo].[MUSIC] OUTPUT INSERTED.[ID_MUSIC] VALUES (@Name, GETDATE(), @TypeMusic)";
                        var idMusic = conexao.Query<int>(query, new { Name = name, TypeMusic = typeMusic }).FirstOrDefault();

                        var query2 = @"INSERT INTO MUSIC_AUTHOR VALUES (@IdAuthor, @IdMusic, GETDATE())";
                        conexao.Execute(query2, new { IdAuthor = idAuthor, IdMusic = idMusic });
                        transactionScope.Complete();
                    }
                    catch (System.Exception e)
                    {
                        transactionScope.Dispose();
                        throw;
                    }
                }

            }
        }

        public void UpdateMusic(int id, string name, int idAuthor)
        {
            var query = @"UPDATE [nonameproject].[dbo].[MUSIC] SET NAME = @Name, TYPE_MUSIC = @TypeMusic WHERE ID_MUSIC = @Id";

            Execute(query, new { Id = id, Name = name });
        }
    }
}
