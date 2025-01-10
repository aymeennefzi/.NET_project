using ApplicationCore.BusinessLogic.Interfaces;
using ApplicationCore.Commands;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Handlers
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IPersonService _personService;

        public CreatePersonCommandHandler(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            return await _personService.CreateAsync(person);
        }
    }
}
