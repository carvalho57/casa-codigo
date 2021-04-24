using System;
using Flunt.Validations;

namespace CasaCodigo.Entities
{
    public class Coupon : Entity
    {
        public string Code { get; private set; }
        public double Percentage { get; private set; }
        public DateTime ExpiryDate { get; private set; }

        private Coupon() { }
        public Coupon(string code, double percentage, DateTime expirydate)
        {
            ChangeInfo(code, percentage,expirydate);
        }

        public bool ChangeInfo(string code, double percentage, DateTime expirydate)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(code, nameof(Code), "O código é obrigatório")
                .IsGreaterThan(percentage, 0, nameof(Percentage), "A porcentagem do cupom é obrigatória e deve ser um valor positivo")
                .IsLowerOrEqualsThan(percentage, 100, nameof(Percentage), "A porcentagem informada é maior que 100%")
                .IsGreaterThan(expirydate, DateTime.UtcNow, nameof(ExpiryDate), "A data de validade deve ser no futuro")
            );

            Code = code;
            Percentage = percentage;
            ExpiryDate = expirydate;

            return Valid;
        }

        private bool IsValid()
        {
            return ExpiryDate > DateTime.UtcNow;
        }
    }
}