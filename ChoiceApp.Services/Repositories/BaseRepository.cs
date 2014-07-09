using ChoiceApp.Services.Interfaces;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChoiceApp.Services.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, new()
    {
        protected IMobileServiceClient MobileServiceClient { get; set; }
        private readonly IMobileServiceTable<T> dataTable;
        protected BaseRepository(IMobileServiceClient mobileServiceClient)
        {
            if (mobileServiceClient == null) throw new ArgumentNullException("mobileServiceClient");
            this.MobileServiceClient = mobileServiceClient;
        }
        protected virtual IMobileServiceTable<T> GetTable()
        {
            return this.MobileServiceClient.GetTable<T>();
        }
        public Task<IEnumerable<T>> All()
        {
            return GetTable().ToEnumerableAsync();
        }

        public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return GetTable().Where(predicate).ToEnumerableAsync();
        }

        public Task Update(T item)
        {
            return GetTable().UpdateAsync(item);
        }

        public Task Delete(T item)
        {
            return GetTable().DeleteAsync(item);
        }

        public Task Add(T item)
        {
            return GetTable().InsertAsync(item);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}
