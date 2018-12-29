using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dominio.Base
{
    public interface IRepositoryBase<T> : IRepository where T : EntidadeBase
    {
        void Gravar(T objeto);
        void Atualizar(T objeto);
        List<T> Obter(Expression<Func<T, bool>> condicao);
        List<T> ObterTodos();
        T ObterPorId(Guid Id);
    }
}
