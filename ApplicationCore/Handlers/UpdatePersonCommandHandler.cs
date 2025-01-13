//using ApplicationCore.BusinessLogic.Interfaces;
//using ApplicationCore.Commands;
//using Domain.Models;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics.Metrics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ApplicationCore.Handlers
//{
//    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
//    {
//        private readonly IPersonService _personService;

//        public UpdatePersonCommandHandler(IPersonService personService)
//        {
//            _personService = personService;
//        }


//        async Task IRequestHandler<UpdatePersonCommand>.Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
//        {
//            var existingPerson = await _personService.GetByIdAsync(request.Id);
//            if (existingPerson == null)
//            {
//                throw new KeyNotFoundException($"Person with ID {request.Id} not found.");
//            }
//            existingPerson.FirstName = request.FirstName;
//            existingPerson.LastName = request.LastName;
//            existingPerson.Email = request.Email;

//             //Appeler le service pour mettre à jour la personne
//            await _personService.UpdateAsync(existingPerson);
//        }
//    }
//}
