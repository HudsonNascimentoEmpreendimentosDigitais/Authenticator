using Flunt.Notifications;
using Flunt.Validations;
using Hudson.Authenticator.Domain.Entities;

namespace Hudson.Authenticator.Domain.Commands.Input
{
    public class ValidateUserCommand : Notifiable<Notification>
    {
        public ValidateUserCommand()
        {

        }

        public ValidateUserCommand(OficialDocument document)
        {
            Document = document;
        }

        public OficialDocument Document { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<AuthenticationCommand>()
                    .IsNotNullOrEmpty(Document.Name, "Name", string.Format("{0} é obrigatório.", Document.Name))
              );
        }
    }
}
