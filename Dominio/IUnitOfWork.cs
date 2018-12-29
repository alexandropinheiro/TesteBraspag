namespace Dominio
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}
