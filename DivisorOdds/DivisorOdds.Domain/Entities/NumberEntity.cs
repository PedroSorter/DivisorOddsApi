using DivisorOdds.Domain.Constants;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DivisorOdds.Domain.Entities
{
    public class NumberEntity : BaseEntity
    {
        public NumberEntity(int value)
        {
            AddNotifications(new Contract()
                                .Requires()
                                .IsGreaterThan(value, 0, Messages.ValorInvalido("Value").IdErro.ToString(), Messages.ValorInvalido("Value").MensagemErro)
                            );
            if (Valid)
            {
                Value = value;
                CreatedAt = DateTime.Now;
                CalculateDivisors();
            }
        }

        public int Value { get; set; }

        private ICollection<Tuple<bool, int>> _oddDivisorsList = new List<Tuple<bool, int>>();

        public IReadOnlyCollection<Tuple<bool, int>> OddDivisorsList { get { return _oddDivisorsList.ToArray(); } }

        //Calcula os divisores do número informado indo até a metade desse número e pegando o recíproco até a raiz do mesmo.//
        public void CalculateDivisors()
        {
            _oddDivisorsList.Add(new Tuple<bool, int>(true, 1));
            _oddDivisorsList.Add(new Tuple<bool, int>(isPrime(Value), Value));
            for (int number = 2; number < (int)Math.Floor(Math.Sqrt(Value)) + 1; number++)
            {
                if (Value % number == 0)
                {
                    _oddDivisorsList.Add(new Tuple<bool, int>(isPrime(number), number));
                    var reciproco = Value / number;
                    if (reciproco != number)
                    {
                        _oddDivisorsList.Add(new Tuple<bool, int>(isPrime(reciproco), reciproco));
                    }
                }
            }
        }

        //Calcula se o número é primo
        public static bool isPrime(int number)
        {
            bool isOdd = true;
            int factor = number / 2;
            for (int i = 2; i <= factor; i++)
            {
                if ((number % i) == 0)
                {
                    isOdd = false;
                    break;
                }
            }

            return isOdd;
        }
    }
}
