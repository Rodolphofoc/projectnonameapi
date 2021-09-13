using project.noname.core;
using project.noname.data.Interface;
using project.noname.domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace project.noname.data
{
    public class TypeMusicRepository : Repository<TypeMusic>, ITypeMusicRepository
    {
    
        public TypeMusicRepository(ConfigurationManager configuration) : base(configuration)
        {
        }


        public TypeMusic GetTypeMusic(int id)
        {
            var query = @"SELECT [ID_TYPE] as IdTypeMusic
                              ,[NAME] as TypeName
                              ,[CREATED]
                          FROM 
                              [nonameproject].[dbo].[TYPE_MUSIC]
                          WHERE
                               ID_TYPE = @Id";

            var result = FirstOfDefault<TypeMusic>(query, new { @Id = id });

            return result;
        }

        public List<TypeMusic> GetTypesMusic()
        {
            var query = @"SELECT [ID_TYPE] as IdTypeMusic
                              ,[NAME] as TypeName
                              ,[CREATED]
                          FROM 
                              [nonameproject].[dbo].[TYPE_MUSIC]";

            var result = GetAll<TypeMusic>(query).ToList();

            return result;
        }
    }
}
