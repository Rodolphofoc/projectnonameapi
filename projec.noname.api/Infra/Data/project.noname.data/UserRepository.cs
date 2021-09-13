using Microsoft.Extensions.Options;
using project.noname.core;
using project.noname.data.Interface;
using project.noname.domain.Models;

namespace project.noname.data
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ConfigurationManager configuration) : base(configuration)
        {
        }

        public User GetUser()
        {
            var sql = @"SELECT [ID_USER] as IdUser
                             ,[NAME]
                             ,[EMAIL]
                             ,[CREATED]
                             ,[ID_USER_STATUS] as Status
                             ,[PASSWORD]
                        FROM 
                             [nonameproject].[dbo].[USERS] 
                        WHERE
                            ID_USER = 1";

            var result = FirstOfDefault<User>(sql);

            return result;
                        
        }
    }
}
