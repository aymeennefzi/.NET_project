//using ApplicationCore.BusinessLogic.Interfaces;
//using ApplicationCore.Commands;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ApplicationCore.Handlers
//{
//    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, Unit>
//    {
//        private readonly IPersonService _personService;

//        public DeletePersonCommandHandler(IPersonService personService)
//        {
//            _personService = personService;
//        }

//        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
//        {
//            // Appeler le service pour supprimer la personne par son Id
//            await _personService.de(request.Id);

//            // Retourner Unit.Value, car il n'y a pas de donnée à retourner après la suppression
//            return Unit.Value;
//        }
//    }
//}
