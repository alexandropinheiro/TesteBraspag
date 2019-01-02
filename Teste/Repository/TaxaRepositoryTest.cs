using Dominio;
using Dominio.Aliquota;
using Infra.Repository;
using Repository;
using System;
using System.Linq;
using Xunit;

namespace Teste.Repository
{
    public class TaxaRepositoryTest : TesteBase, IDisposable
    {
        private ITaxaRepository _repository;
        private readonly IUnitOfWork _uow;

        public TaxaRepositoryTest()
        {
            Setup();
            _repository = new TaxaRepository(Contexto);
            _uow = new UnitOfWork(Contexto);
        }

        [Fact]
        public void AlterarTaxa()
        {
            // 1 - Recuperar 1 taxa
            var taxa = _repository.ObterTodos().FirstOrDefault();
            taxa.Percentual = 0.0089;
            var id = taxa.Id;

            _repository.Atualizar(taxa);
            _uow.Commit();

            Assert.Equal(0.0089, _repository.ObterPorId(id).Percentual);
        }

        public void Dispose()
        {            
            TearDown();
        }
    }
}
