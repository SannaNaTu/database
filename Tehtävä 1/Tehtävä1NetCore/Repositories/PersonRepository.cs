using System;
using System.Collections.Generic;
using System.Text;
using Tehtävä1NetCore.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Tehtävä1NetCore.Repositories
{
    class PersonRepository : IPersonRepository
    {
        private static Tehtävä1Context _context = new Tehtävä1Context();

        public void Create(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
        }

        public List<Person> Get()
        {
            List<Person> persons = _context.Person.ToListAsync().Result;
            return persons;
        }

        public Person GetPersonById(int id)
        {
            var person = _context.Person.FirstOrDefault(p => p.Id == id);
            return person;
        }
        public void Update (int id, Person person)
        {
            var updatePerson = GetPersonById(id);
            if (updatePerson != null)
            {
                _context.Person.Update(person);
            }
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var delPerson = _context.Person.FirstOrDefault(p => p.Id == id);
            if (delPerson != null)
            {
                _context.Person.Remove(delPerson);
                }
               _context.SaveChanges();

        }
        public List<Person> GetPersonPhone()
        {
            List<Person> persons = _context.Person
                .Include(p => p.Phone)
                .ToListAsync().Result;
            return persons;
        }
        public Person GetPersonByIdAndPhones(int id)
        {
            var person = _context.Person
                .Include(p => p.Phone)
                .Single(p => p.Id == id);

            return person;
        }
    }
}
