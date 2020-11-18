using System;
using System.Collections.Generic;
using System.Text;

namespace DivisorOdds.Domain.Constants
{
    public struct Messages
    {
        //Erro de entidade//
        public static (int IdErro, string MensagemErro) ValorInvalido(string campo) => (101, $"O valor da propriedade {campo} é inválido"); 
    }
}
