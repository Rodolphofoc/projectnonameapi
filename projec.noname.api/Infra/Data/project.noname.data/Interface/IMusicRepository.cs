using project.noname.domain.Models;
using System.Collections.Generic;

namespace project.noname.data.Interface
{
    public interface IMusicRepository
    {
        Music GetMusic(int id);

        List<Music> GetMusicbyAuthor(int idAuthor);

        void InsertMusic(string name, int typeMusic, int idAuthor);

        void UpdateMusic(int id, string name, int idAuthor);

        List<Music> GetMusics();
    }
}
