using System;
    
namespace Dominio.Operacao
{
    public class TransacaoFactory
    {
        private readonly double _valor;

        public TransacaoFactory(double valor)
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
