using Microsoft.AspNetCore.Mvc;
using Traversal_Web_Api.DAL.Context;
using Traversal_Web_Api.DAL.Entities;

namespace Traversal_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisiterController : ControllerBase
    {
        [HttpGet]
        public IActionResult VisitorList() 
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.ToList();
                return Ok(values);
            }
        }

        [HttpPost]
        public IActionResult VisitorAdd(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                context.Add(visitor);
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpGet("{id}")]
        public IActionResult VisitorGet([FromRoute] int id)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.Find(id);
                if (values is null)
                    return NotFound();
                return Ok(values);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVisitor([FromRoute] int id)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.Find(id);
                if (values is null)
                    return NotFound();
                context.Remove(values);
                context.SaveChanges();
                return Ok(values);
            }
        }

        [HttpPut]
        public IActionResult UpdateVisitor([FromBody] Visitor visitor) 
        {
            using (var context = new VisitorContext())
            {
                var values = context.Find<Visitor>(visitor.VisitorID);
                if (values is null)
                    return NotFound();

                values.Name = visitor.Name;
                values.Surname = visitor.Surname;
                values.City = visitor.City;
                values.Country = visitor.Country;
                values.Mail = visitor.Mail;

                context.Update(values);
                context.SaveChanges();

                return Ok(values);
            }
        }

    }
}
