using project.noname.data.Interface;
using project.noname.domain.Models;
using project.noname.service.Interface;
using project.noname.service.Models.Helpers;

namespace project.noname.service
{
    public class MusicService : IMusicService
    {
        private IMusicRepository musicRepository { get; set; }
        private IAuthorRepository authorRepository { get; set; }
        private ITypeMusicRepository typeMusicRepository { get; set; }

        private Response _response;

        public MusicService(IAuthorRepository authorRepository, IMusicRepository musicRepository,  ITypeMusicRepository typeMusicRepository)
        {
            this.authorRepository = authorRepository;
            this.typeMusicRepository = typeMusicRepository;
            this.musicRepository = musicRepository;
        }


        public Response GetMusic(int id)
        {
            _response = new Response();

            try
            {
                _response.AddValue(musicRepository.GetMusic(id));
                return _response;
            }
            catch (System.Exception e)
            {
                _response.AddNotification(new Notifications() { Message = e.Message });
                return _response;
            }
        }

        public Response GetMusicByAuthor(int idAuthor)
        {
            _response = new Response();

            try
            {
                _response.AddValue(musicRepository.GetMusicbyAuthor(idAuthor));
                return _response;
            }
            catch (System.Exception e)
            {
                _response.AddNotification(new Notifications() { Message = e.Message });
                return _response;
            }
        }

        public Response GetMusicAll()
        {
            _response = new Response();

            try
            {
                _response.AddValue(musicRepository.GetMusics());
                return _response;
            }
            catch (System.Exception e)
            {
                _response.AddNotification(new Notifications() { Message = e.Message });
                return _response;
            }
        }


        public Response InsertMusic(Music music, int idAuthor)
        {
            _response = new Response();

            try
            {
                if (authorRepository.GetAuthor(idAuthor) == null)
                    _response.AddNotification(new Notifications()
                    {
                        Message = "Autor não encontrado"
                    });

                if (typeMusicRepository.GetTypeMusic(music.TypeMusic.IdTypeMusic) == null)
                    _response.AddNotification(new Notifications()
                    {
                        Message = "Estilo de musica não encontrado"
                    });

                if (_response.AnyMessage)
                    return _response;


                musicRepository.InsertMusic(music.MusicName, music.TypeMusic.IdTypeMusic, idAuthor );
                return _response;
            }
            catch (System.Exception e)
            {
                _response.AddNotification(new Notifications() { Message = e.Message });
                return _response;
            }
        }

        public Response UpdateMusic(int id, Music music, int idAuthor)
        {
            _response = new Response();

            try
            {
                musicRepository.UpdateMusic(id, music.MusicName, idAuthor);
                return _response;
            }
            catch (System.Exception e)
            {
                _response.AddNotification(new Notifications() { Message = e.Message });
                return _response;
            }
        }

    }
}
