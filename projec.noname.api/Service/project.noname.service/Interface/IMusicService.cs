using project.noname.domain.Models;
using project.noname.service.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.noname.service.Interface
{
    public interface IMusicService
    {
        Response GetMusic(int id);

        Response GetMusicByAuthor(int idAuthor);

        Response InsertMusic(Music music, int idAuthor);

        Response UpdateMusic(int id, Music music, int idAuthor);

        Response GetMusicAll();
    }
}
