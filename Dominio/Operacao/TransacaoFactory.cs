using System;
    
namespace Dominio.Operacao
{
    public class TransacaoFactory
    {
        private readonly decimal _valor;

        public TransacaoFactory(decimal valor)
        {
            _valor = valor;
        }

        public Transacao Criar()
        {
            return new Transacao {
                Id = Guid.NewGuid(),
                Valor = _valor
            };
        }
    }
}
