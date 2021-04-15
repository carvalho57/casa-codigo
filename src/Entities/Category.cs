using Flunt.Validations;

namespace CasaCodigo.Entities
{
    public class Category : Entity
    {
        private Category() { } 
        public Category(string name)
        {
            ChangeName(name);
        }
        
        public string Name { get; private set; }

        public void ChangeName(string name)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(name, nameof(Name), "O nome da categoria é obrigátorio")
                .IsNotNullOrWhiteSpace(name, nameof(Name), "O nome da categoria é obrigátorio"));

            Name = name;
        }
    }
}