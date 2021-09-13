using Microsoft.AspNetCore.Mvc;
using project.noname.service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.noname.api.Controllers
{
    [Route("api/[controller]")]
    public class TypeMusicController : BaseController
    {
        private ITypeMusicService services;


        public TypeMusicController(ITypeMusicService typeMusicService)
        {
            services = typeMusicService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetMusic(int id)
        {
            try
            {
                var result = services.GetTypeMusic(id);

                return Response(result);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }


        }

        [HttpGet]
        public IActionResult GetTypesMusic()
        {
            try
            {
                var result = services.GetTypesMusic();

                return Response(result);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }
}
