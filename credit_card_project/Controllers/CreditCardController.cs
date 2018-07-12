using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using credit_card_project.Models;

namespace credit_card_project.Controllers {
  [Route ("api/[controller]")]
  [ApiController]

  public class CreditCardController : ControllerBase {
    private readonly CreditCardContext _context;

    // Constructor
    public CreditCardController (CreditCardContext context) {
      _context = context;

      if (_context.CreditCardItems.Count () == 0) {
        _context.CreditCardItems.Add (new CreditCardItem { expireDate = "Item 1" });
        _context.SaveChanges ();
      }
    }

    // GET All CreditCard from in-memory database
    [HttpGet]
    public ActionResult<List<CreditCardItem>> GetAll () {
      return _context.CreditCardItems.ToList ();
    }

    // GET CreditCard by id
    [HttpGet ("{id}", Name = "GetCreditCard")]
    public ActionResult<CreditCardItem> GetById (long id) {

      var item = _context.CreditCardItems.Find (id);
      if (item == null) {
        return NotFound ();
      }
      return item;
    }

    // POST
    [HttpPost]
    public IActionResult Create (CreditCardItem item) {
      _context.CreditCardItems.Add (item);
      _context.SaveChanges ();

      return CreatedAtRoute ("GetCreditCard", new CreditCardItem { Id = item.Id }, item);
    }
  }
}