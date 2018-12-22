using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SQLLite.Models
{
    public class PersonRepository
    {
        private SQLiteAsyncConnection conn;

        public  PersonRepository(string dbpath)
        {
            conn = new SQLiteAsyncConnection(dbpath);
            conn.CreateTableAsync<Person>();
        }

        public async  Task<int> AddNewPerson(string name)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                result = await conn.InsertAsync(new Person { Name = name });

            }
            catch
            {

            }
            return result;
    
        }

        public async Task<List<Person>> GetAllPeople()
        {
            try
            {
                return await conn.Table<Person>().ToListAsync();
            }
            catch (Exception ex)
            {
            }

            return new List<Person>();
        }

        public async  Task<int> UpdatePeople(Person addperson, Person updateperson)
        {
            int count = 0;


            await conn.RunInTransactionAsync(conn =>
            {
                count += conn.Insert(addperson);
                count += conn.Update(updateperson);
            });

            return count;
        }


        public Person GetByName(string name)
        {
            var person = from p in conn.Table<Person>()
                         where p.Name == name
                         select p;

            return person;
        }
      

    }
}
