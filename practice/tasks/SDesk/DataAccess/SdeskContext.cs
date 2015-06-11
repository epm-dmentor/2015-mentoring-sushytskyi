using System.Data.Entity;
using Epam.Sdesk.Model;

namespace Epam.Sdesk.DataAccess
{
    public class SdeskContext:DbContext
    {
        public SdeskContext(): base("name=SdeskContext"){}

        public DbSet<Mail> Mail { get; set; } 

    }
}
