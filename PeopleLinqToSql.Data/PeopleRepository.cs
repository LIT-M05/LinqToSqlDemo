using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PeopleLinqToSql.Data
{
    public class PeopleRepository
    {
        private string _connectionString;

        public PeopleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Person> GetPeople()
        {
            using (var context = new PeopleDataContext(_connectionString))
            {
                return context.Persons.ToList();
            }
        }

        public void Add(Person person)
        {
            using (var context = new PeopleDataContext(_connectionString))
            {
                context.Persons.InsertOnSubmit(person);
                context.SubmitChanges();
            }
        }

        public Person GetById(int id)
        {
            using (var context = new PeopleDataContext(_connectionString))
            {
                return context.Persons.FirstOrDefault(p => p.Id == id);
            }
        }

        public void Update(Person person)
        {
            using (var context = new PeopleDataContext(_connectionString))
            {
                context.Persons.Attach(person);
                context.Refresh(RefreshMode.KeepCurrentValues, person);
                context.SubmitChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new PeopleDataContext(_connectionString))
            {
                context.ExecuteCommand("DELETE FROM People WHERE Id = {0}", id);
            }
        }
        
    }
}

//Create an application where people can upload images for others
//to see and "Like". 

//there should be a page on the site where a user can upload new images. When they do,
//they should also add a title for that image.

//On the home page, display a list of all images, sorted by most recent. With each
//image, display the title of that image. The image and title should be links, that
//when clicked, should take the user to a page where they see that individual
//image in large.

//Beneath that image, there should be a button that says "Like". When a user clicks 
//on this button, via ajax, update the likes count in the database. Once a user
//has liked an image, they should not be able to like it again (use cookies/session 
//for this). 

//Next to the Like button, there should be a number that displays the current amount
//of likes for this image. This number should be updated in real time, e.g. if someone
//else on a different machine likes this image, the number should update on my screen
//as well without me having to hit refresh. The way to do this last part is by using
//setInterval. In setInterval, make an ajax call to the server to get the current count
//of likes, and update the page with that number.