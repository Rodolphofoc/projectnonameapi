using project.noname.data.Interface;
using project.noname.service.Interface;
using project.noname.service.Models.Helpers;

namespace project.noname.service
{
    public class UserService : IUserService
    {
        public IUserRepository repository { get; set; }
        private Response _response;
        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public Response GetUser()
        {
             _response = new Response();

            try
            {
                _response.AddValue(repository.GetUser());

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
