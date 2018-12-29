using Dominio.Base;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infra.Repository
{
    public class Repository<TEntity> : IRepositoryBase<TEntity> where TEntity : EntidadeBase
    {
        protected Contexto _contexto { get; set; }
        protected DbSet<TEntity> DbSet;

        public Repository(Contexto contexto)
        {
            _contexto = contexto;
            DbSet = _contexto.Set<TEntity>();
        }

        public virtual void Gravar(TEntity objeto)
        {
            DbSet.Add(objeto);
        }

        public virtual List<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public void Atualizar(TEntity objeto)
        {
            DbSet.Update(objeto);
        }

        public List<TEntity> Obter(Expression<Func<TEntity, bool>> condicao)
        {
            return _contexto.Set<TEntity>()
                .Where(condicao)
                .ToList();
        }

        public TEntity ObterPorId(Guid Id)
        {
            return _contexto.Set<TEntity>().Find(Id);
        }
    }
}
