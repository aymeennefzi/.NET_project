using Domain.Models;
using Infrastructure.Base;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PersonRepository : BaseRepository<Person>
    {
        public PersonRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
