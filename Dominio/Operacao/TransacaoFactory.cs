using System;

namespace Dominio.Operacao
{
    public class TransacaoFactory
    {
        private readonly decimal _valor;
        private readonly DateTime _data;

        public TransacaoFactory(decimal valor, DateTime data)
        {
            _valor = valor;
            _data = data;
        }

        public Transacao Criar()
        {
            return new Transacao {
                Id = Guid.NewGuid(),
                Valor = _valor,
                Data = _data
            };
        }
    }
}
