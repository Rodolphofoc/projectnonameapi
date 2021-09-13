using project.noname.data.Interface;
using project.noname.service.Interface;
using project.noname.service.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.noname.service
{
    public class TypeMusicService : ITypeMusicService
    {
        private ITypeMusicRepository typeMusicRepository { get; set; }
        private Response _response;

        public TypeMusicService(ITypeMusicRepository typeMusicRepository)
        {
            this.typeMusicRepository = typeMusicRepository;
        }


        public Response GetTypeMusic(int id)
        {
            _response = new Response();

            try
            {
                _response.AddValue(typeMusicRepository.GetTypeMusic(id));
                return _response;
            }
            catch (System.Exception e)
            {
                _response.AddNotification(new Notifications() { Message = e.Message });
                return _response;
            }
        }

        public Response GetTypesMusic()
        {
            _response = new Response();

            try
            {
                _response.AddValue(typeMusicRepository.GetTypesMusic());
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
