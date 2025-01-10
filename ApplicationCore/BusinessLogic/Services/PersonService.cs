using ApplicationCore.Base;
using ApplicationCore.BusinessLogic.Interfaces;
using Domain.Models;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.BusinessLogic.Services
{
    public class PersonService : IPersonService
    {
        private readonly IBaseRepository<Person> _personRepository;

        public PersonService(IBaseRepository<Person> personRepository)
        {
            _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository), "Repository is null");
        }

        public async Task<int> CreateAsync(Person entity)
        {
            return await _personRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var person = await _personRepository.GetById(id);
            if (person != null)
            {
                await _personRepository.DeleteAsync(person);
            }
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _personRepository.GetAllAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _personRepository.GetById(id);
        }

        public async Task UpdateAsync(Person entity)
        {
             await _personRepository.UpdateAsync(entity);
        }     
    }
}
