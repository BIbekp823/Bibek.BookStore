using System.Threading.Tasks;

namespace Bibek.BookStore.Data;

public interface IBookStoreDbSchemaMigrator
{
    Task MigrateAsync();
}
