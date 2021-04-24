using Flunt.Br.Extensions;
using Flunt.Validations;

namespace CasaCodigo.ValueObjects
{
    public class Phone : ValueObject
    {
        protected Phone(){ }
        public Phone(string phone)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsPhone(phone, nameof(Phone), "Insira um número de telefone válido"));


            Number = phone;
        }

        public string Number { get; private set; }
    }
}