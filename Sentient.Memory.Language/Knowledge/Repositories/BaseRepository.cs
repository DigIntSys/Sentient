using Sentient.Memory.Language.Helpers;
using System.Data.Entity.Validation;

namespace Sentient.Memory.Language.Knowledge.Repositories
{
    internal class BaseRepository
    {
        protected SentientEntities Context { get; set; }

        public BaseRepository()
        {
            this.Context = new SentientEntities();
        }

        protected int SaveChanges()
        {
            var result = 0;
            try
            {
                result = Context.SaveChanges();
                
            }
            catch (DbEntityValidationException e)
            {
                throw new EntityExceptions(e);
            }
            finally
            {
                Dispose();
            }
            return result;
        }

        protected void Dispose()
        {
            Context.Dispose();
        }

    }
}