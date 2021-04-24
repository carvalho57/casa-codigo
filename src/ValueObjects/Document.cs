using Flunt.Br.Extensions;
using Flunt.Validations;

namespace CasaCodigo.ValueObjects
{
    public class Document : ValueObject
    {
        protected Document() { }
        public Document(string document)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsCnpjOrCPF(document, "Document", "Por favor, insira um CPF ou CNPJ válido"));

            Number = document;
        }

        public string Number { get; private set; }
    }
}