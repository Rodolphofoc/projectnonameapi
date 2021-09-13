using project.noname.service.Models.Helpers;

namespace project.noname.service.Interface
{
    public interface ITypeMusicService
    {
        Response GetTypeMusic(int id);

        Response GetTypesMusic();
    }
}
