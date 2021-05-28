using Flunt.Notifications;
using Flunt.Validations;
using Hudson.Authenticator.Domain.Entities;

namespace Hudson.Authenticator.Domain.Commands.Input
{
    public class AuthenticationCommand : Notifiable<Notification>
    {
        public AuthenticationCommand()
        {

        }

        public AuthenticationCommand(OficialDocument document, string password, string sessionId)
        {
            UserDocument = document;
            Password = password;
            SessionId = sessionId;
        }

        public OficialDocument UserDocument { get; set; }
        public string Password { get; set; }
        public string SessionId { get; set; }


        public void Validade()
        {
            AddNotifications(
                          new Contract<AuthenticationCommand>()
                              .IsNotNullOrEmpty(UserDocument.Name, "UserDocument", string.Format("{0} é obrigatório.", UserDocument.Name))
                              .IsNotNullOrEmpty(Password, "Senha", "Senha é obrigatória.")
                          );

        }
    }
}
