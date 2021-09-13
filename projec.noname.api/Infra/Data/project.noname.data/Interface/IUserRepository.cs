using project.noname.domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.noname.data.Interface
{
    public interface IUserRepository
    {
        User GetUser();
    }
}
