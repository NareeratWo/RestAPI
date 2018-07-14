using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using credit_card_project.Models;
using System;

namespace credit_card_project.Controllers {
  [Route ("api/[controller]")]
  [ApiController]

  public class CreditCardController : ControllerBase {
    private readonly CreditCardContext _context;

    // Constructor
    public CreditCardController (CreditCardContext context) {
      _context = context;

      if (_context.CreditCardItems.Count () == 0) {
        _context.CreditCardItems.Add (new CreditCardItem { expiryDate = "Item 1" });
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
    public string Create (CreditCardItem item) {
		var result = Validate(item);
		if (result.validateresult){
			var result2 = ValidateRule(item);
			if (result2.isValid){
				return "Valid "+result2.cardType;
			}
			else{
				return "Invalid "+result2.cardType;
			}
			//_context.CreditCardItems.Add (item);
			//_context.SaveChanges ();
			//var list= _context.CreditCardItems
			//.FromSql("EXECUTE dbo.SP_CHECK_CREDIT_CARD {0} {1} {2}",item.cardNo,item.expiryDate,item.cardType  )
			//.ToList();
			//return CreatedAtRoute ("GetCreditCard", new CreditCardItem { Id = item.Id }, item);
			//return "Validate true";
		}
      return result.errmsg;
      
    }

	private (bool validateresult, string errmsg) Validate(CreditCardItem item){
		String errormsg="";
		int CardNoLength=0;

		CardNoLength=item.cardNo.ToString().Length;

		//validate length 15 or 16 digit
		if (CardNoLength != 15 && CardNoLength  != 16){
			errormsg="Invalid credit card no";
			return (false,errormsg);
		}
		//validate expiry date  format
		if (item.expiryDate.ToString().Length != 6 ){
			errormsg="Invalid expiry date";
			return (false,errormsg);			
		}
		DateTime now = DateTime.Now;
		return (true,"");
		
	}	

	private (bool isValid, string cardType) ValidateRule(CreditCardItem item){
		String cardType="";
		int CardNoLength=0;
		int firstDigitCardNo=0;
		bool result=false;

		CardNoLength=item.cardNo.ToString().Length;
		firstDigitCardNo=Int32.Parse(item.cardNo.ToString().Substring(0,1));

		//get card type
		if (CardNoLength == 15 && firstDigitCardNo == 3){
			cardType="Amex";
		}
		if (CardNoLength == 16){
			if( firstDigitCardNo == 3){
				cardType="JCB";
			}
			if( firstDigitCardNo == 4){
				cardType="Visa";
				result = ValidateVisa(item.cardNo);
			}
			if( firstDigitCardNo == 5){
				cardType="Master";
			}
			else{
				cardType="Unknown";
			}
		}
		return (result,cardType);
	}

	private bool ValidateVisa(long cardNo){
		if (cardNo % 400 == 0){
			return true;
		}
		return false;	
	}

	private bool ValidateMaster(long cardNo){
		if (cardNo % 400 == 0){
			return true;
		}
		return false;	
	}
  }
}