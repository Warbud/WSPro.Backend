namespace WSPro.Backend.Infrastructure.Helpers
{
    public class DbContextInjection
    {
        public readonly WSProContext Context;

        public DbContextInjection(WSProContext context)
        {
            Context = context;
        }
    }
}