using System.Collections.Generic;
using System.Linq;

namespace project.noname.service.Models.Helpers
{
    public class Response
    {
        #region ::   Propriedades   ::

        public object Value { get; private set; }
        private IList<Notifications> _message { get; } = new List<Notifications>();
        public IReadOnlyCollection<Notifications> Message => _message.ToList();

        #endregion

        public bool AnyMessage => _message.Any();

        /// <summary>
        /// Cria um novo objeto de retorno para a api
        /// </summary>
        public Response()
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="object">Objeto que deverá ser serializado pela Api</param>
        public Response(object @object) : this()
        {
            AddValue(@object);
        }

        /// <summary>
        /// Adiciona um objeto que deverá ser serializado e retornado pela Api
        /// </summary>
        /// <param name="object">Objeto que deverá ser serializado pela Api</param>
        public void AddValue(object @object)
        {
            Value = @object;
        }


        /// <summary>
        /// Adiciona mensagem de retorno
        /// </summary>
        /// <param name="notificacao">Mensagem que deverá ser retornada pela Api</param>
        public void AddNotification(Notifications notification)
        {
            _message.Add(notification);
        }

        /// <summary>
        /// Adiciona mensagens de retorno
        /// </summary>
        /// <param name="notificacoes">Notificações</param>
        /// <param name="type">Tipo de notificação</param>
        public void AddNotifications(IEnumerable<Notifications> notifications)
        {
            foreach (var notificacao in notifications)
            {
                AddNotification(notificacao);
            }
        }

        public override string ToString()
        {
            return string.Join(" - ", Message.Select(x => x.Message));
        }

        public object GetValue()
        {
            return Value;
        }
    }
}
