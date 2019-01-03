namespace Infra.Setup
{
    public interface IDatabaseInitializer
    {
        bool ApplyDatabase();
        //void Seed();
    }
}
