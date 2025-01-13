using ApplicationCore.Base;
using ApplicationCore.BusinessLogic.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.BusinessLogic.Services
{
    public class PersonService : BaseService<Person>, IPersonService

    {   
        public PersonService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
