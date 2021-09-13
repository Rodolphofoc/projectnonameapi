using project.noname.domain.Models;
using System.Collections.Generic;

namespace project.noname.data.Interface
{
    public interface ITypeMusicRepository
    {
        TypeMusic GetTypeMusic(int id);

        List<TypeMusic> GetTypesMusic();
    }
}
