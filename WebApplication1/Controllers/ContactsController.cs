using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.NewFolder;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [EnableCors("AllowOrigin")]
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ContactsAPIDbContext dbContext;
        public ContactsController(ContactsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(dbContext.Contacts.ToList());
            //return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddContact(AddContactRequest addContactRequest)
        {
            var contact = new Contact()
            {
                Id=Guid.NewGuid(),
                Address=addContactRequest.Address,
                FullName=addContactRequest.FullName,
                Email=addContactRequest.Email,
                Phone=addContactRequest.Phone,
            };
           await dbContext.Contacts.AddAsync(contact);
           await  dbContext.SaveChangesAsync();
           return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteContact([FromHeader] Guid id)
        {
            var contact =await dbContext.Contacts.FindAsync(id);
            if (contact!=null) { 
                dbContext.Contacts.Remove(contact);
                await dbContext.SaveChangesAsync();
            }
            return Ok(contact);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(AddContactRequest addContactRequest,Guid id)
        {
            var existcontact = await dbContext.Contacts.FindAsync(id);
            if(existcontact!=null) { 
                existcontact.Address=addContactRequest.Address;
                existcontact.FullName=addContactRequest.FullName;
                existcontact.Email=addContactRequest.Email;
                existcontact.Phone=addContactRequest.Phone;
                dbContext.Contacts.Update(existcontact);
                await dbContext.SaveChangesAsync();
            }
            return Ok(existcontact);
        }
    }
}
