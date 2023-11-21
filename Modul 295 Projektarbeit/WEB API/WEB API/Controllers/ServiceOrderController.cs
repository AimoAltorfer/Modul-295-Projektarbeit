using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WEB_API;

[ApiController]
[Route("[controller]")]
public class ServiceOrderController : ControllerBase
{
    private readonly SkiServiceManagementContext _context;

    public ServiceOrderController(SkiServiceManagementContext context)
    {
        _context = context;
    }

    // Innerhalb Ihrer ServiceOrderController-Klasse:

    private bool ServiceOrderExists(int id)
    {
        return _context.ServiceOrders.Any(e => e.ServiceOrderID == id);
    }


    // GET: api/ServiceOrder
    [HttpGet]
    public ActionResult<IEnumerable<ServiceOrder>> GetServiceOrders()
    {
        return _context.ServiceOrders;
    }

    // GET: api/ServiceOrder/5
    [HttpGet("{id}")]
    public ActionResult<ServiceOrder> GetServiceOrder(int id)
    {
        var serviceOrder = _context.ServiceOrders.FirstOrDefault(o => o.ServiceOrderID == id);

        if (serviceOrder == null)
        {
            return NotFound();
        }
        return serviceOrder;
    }

    // POST: api/ServiceOrder
    [HttpPost]
    public ActionResult<ServiceOrder> PostServiceOrder(ServiceOrder serviceOrder)
    {
        _context.ServiceOrders.Add(serviceOrder);
        _context.SaveChanges();

        return CreatedAtAction("GetServiceOrder", new { id = serviceOrder.ServiceOrderID }, serviceOrder);
    }

    // PUT: api/ServiceOrder/5
    [HttpPut("{id}")]
    public IActionResult PutServiceOrder(int id, ServiceOrder serviceOrder)
    {
        if (id != serviceOrder.ServiceOrderID)
        {
            return BadRequest();
        }
        _context.Entry(serviceOrder).State = EntityState.Modified;
        try
        {
            _context.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ServiceOrderExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteServiceOrder(int id)
    {
        var serviceOrder = _context.ServiceOrders.Find(id);
        if (serviceOrder == null)
        {
            return NotFound();
        }

        var deletedOrder = new DeletedOrder
        {
            OriginalServiceOrderID = serviceOrder.ServiceOrderID,
            CustomerName = serviceOrder.CustomerName,
            CustomerEmail = serviceOrder.CustomerEmail,
            CustomerPhone = serviceOrder.CustomerPhone,
            Priority = serviceOrder.Priority,
            ServiceType = serviceOrder.ServiceType,
            Status = "Gelöscht" 
        };

        _context.DeletedOrders.Add(deletedOrder);
        _context.ServiceOrders.Remove(serviceOrder);
        _context.SaveChanges();

        return NoContent();
    }




}
