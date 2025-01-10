using ApplicationCore.BusinessLogic.Interfaces;
using ApplicationCore.Queries;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Handlers
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, Person>
    {
        private readonly IPersonService _personService;
        public GetPersonByIdQueryHandler(IPersonService personService)
        {
            _personService = personService;
        }
        public async Task<Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {

            var person = await _personService.GetByIdAsync(request.Id);
           

            if (person == null)
            {
                return null; 
            }

            return person;
        }
    }
}
