//using ApplicationCore.BusinessLogic.Interfaces;
//using ApplicationCore.Queries;
//using Domain.Models;
//using Infrastructure.Base;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ApplicationCore.Handlers
//{
//    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQuery, List<Person>>
//    {
//        private readonly IPersonService _personService;

//        public GetAllPersonsQueryHandler(IPersonService personService)
//        {
//            _personService = personService;
//        }

//        public async Task<List<Person>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
//        {
//            return await _personService.GetAllAsync();
//        }
//    }
//}
