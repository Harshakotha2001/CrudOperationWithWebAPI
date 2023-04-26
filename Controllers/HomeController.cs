using CrudOpp.Data;
using CrudOpp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudOpp.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class HomeController : Controller
    {

        private readonly CrudAPIDbContext dbContext;

        public HomeController(CrudAPIDbContext dbContext) => this.DbContext = dbContext;

        public CrudAPIDbContext DbContext { get; }

        [HttpGet]
        [Route("Home/Get")]
        public async Task<IActionResult> GetAllCruds()
        {
            return Ok( await dbContext.Cruds.ToListAsync());
            
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCruds([FromRoute] Guid id)
        {
            var crud = await dbContext.Cruds.FindAsync(id);
            if(crud == null)
            {
                return NotFound();
            }
            return Ok(crud);    
        }

        [HttpPost]
        public async Task<IActionResult>AddContacts(AddContactRequest addContactRequest) 
        {
            var crud = new Crud()
            {
                Id = Guid.NewGuid(),
                Address = addContactRequest.Address,
                Email = addContactRequest.Email,
                FullName = addContactRequest.FullName,
                Phone = addContactRequest.Phone,

            };
             await dbContext.Cruds.AddAsync(crud);
            await dbContext.SaveChangesAsync();
            return Ok(crud);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCrud([FromRoute] Guid id,Updateclass updateclass)
        {
          var crud=await dbContext.Cruds.FindAsync(id);
            if(crud != null)
            {
                crud.FullName = updateclass.FullName;
                crud.Phone = updateclass.Phone; 
                crud.Email = updateclass.Email; 
                crud.Address = updateclass.Address;

                await dbContext.SaveChangesAsync();
                return Ok(crud);

            }
            return NotFound();


           
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            var crud =  await dbContext.Cruds.FindAsync(id);
            if(crud != null)
            {
                dbContext.Remove(crud);
                await dbContext.SaveChangesAsync();
                return Ok(crud);
            }
            return NotFound();
        }
    }
}
