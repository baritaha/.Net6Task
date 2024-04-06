using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTask.Models;

namespace MyTask.Controllers
{
    public class ContactController : Controller
    {
     static List<Person>ContactList=new List<Person>();
        [HttpGet]
        public ActionResult AllContact(string sortBy)
        {
            var sortedContacts = ContactList;

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.ToLower())
                {
                    case "firstname":
                        sortedContacts = sortedContacts.OrderBy(c => c.FirstName).ToList();
                        break;
                    case "lastname":
                        sortedContacts = sortedContacts.OrderBy(c => c.LastName).ToList();
                        break;
                    case "email":
                        sortedContacts = sortedContacts.OrderBy(c => c.Email).ToList();
                        break;
                    case "phonenumber":
                        sortedContacts = sortedContacts.OrderBy(c => c.PhoneNumber).ToList();
                        break;
                    default:
                        break;
                }
            }

            return View(sortedContacts);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var person = ContactList.FirstOrDefault(c => c.Id == id);
            if (person == null)
            {
                return NotFound(); // Person not found
            }
            return View(person);
        }
        [HttpPost]
        public ActionResult Update(int id, Person updatedPerson)
        {
            if (ModelState.IsValid)
            {
                var existingPerson = ContactList.FirstOrDefault(c => c.Id == id);
                if (existingPerson != null)
                {
                    existingPerson.FirstName = updatedPerson.FirstName;
                    existingPerson.LastName = updatedPerson.LastName;
                    existingPerson.Email = updatedPerson.Email;
                    existingPerson.PhoneNumber = updatedPerson.PhoneNumber;
                    return RedirectToAction("AllContact");
                }
                return NotFound(); // Person not found
            }
            return View(updatedPerson);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                ContactList.Add(person);

                return RedirectToAction("AllContact");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("AllContact");

            }
            var data=(from pr in ContactList
                      where pr.Id==id
                      select pr).FirstOrDefault();
            return View(data);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("AllContact");

            }
            var data = (from pr in ContactList
                        where pr.Id == id
                        select pr).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Person person)
        {
            var data = (from pr in ContactList
                        where pr.Id == person.Id
                        select pr).FirstOrDefault();
            ContactList.Remove(data);
            return RedirectToAction("AllContact");

        }
        public ActionResult HomePage()
        {
            return View();
        }
    }
}
