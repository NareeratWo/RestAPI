using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using credit_card_project.Models;
using System;
using System.Data.SqlClient;

namespace credit_card_project.Controllers {
  [Route ("api/[controller]")]
  [ApiController]

  public class CreditCardController : ControllerBase {
    private CreditCardContext _context;

    // Constructor
    public CreditCardController (CreditCardContext context) {
      _context = context;

    }

    // GET All CreditCard
    [HttpGet]
    public ActionResult<List<CreditCardItem>> GetAll () {
      return _context.CreditCardItem.ToList ();
    }

    // POST
    [HttpPost]
    public string CheckCreditCard (CreditCardItem item) {
		var result = Validate(item);
        bool checkDBresult=true;
       
		if (result.validateresult){
			var ValidateRuleResult = ValidateRule(item);
			if (!ValidateRuleResult.isValid){
				return "Invalid "+ValidateRuleResult.cardType;
			}
              
            //validate is true
            //set card_type to item
            if (ValidateRuleResult.cardType != "Unknown") {
                item.CARD_TYPE = ValidateRuleResult.cardType;
                //check data at DB
                checkDBresult = _context.checkCreditCardOnDB(item);
                if (!checkDBresult){
                    return "Does not exist "+ValidateRuleResult.cardType;
                }else{
                    return "Valid "+ValidateRuleResult.cardType;
                } 
            }
		}
      return result.errmsg;      
    }

    private (bool validateresult, string errmsg) Validate(CreditCardItem item){
		String errormsg="";
		int CardNoLength=0;
        int expiryYear;
        int expiryMonth;

		CardNoLength=item.CARD_NO.ToString().Length;
        expiryMonth=Int32.Parse(item.EXPIRE_DATE.ToString().Substring(0,2));
        expiryYear=Int32.Parse(item.EXPIRE_DATE.ToString().Substring(2,4));
		//validate length 15 or 16 digit
		if (CardNoLength != 15 && CardNoLength  != 16){
			errormsg="Invalid credit card no";
			return (false,errormsg);
		}
		//validate expiry date  format
		if (item.EXPIRE_DATE.ToString().Length != 6 ){
			errormsg="Invalid expiry date";
			return (false,errormsg);			
		}
        DateTime now = DateTime.Now;
        //check expiry month is valid
        if( expiryYear < now.Year ){
            errormsg="Invalid expiry date";
			return (false,errormsg);
        }

        //check expiry month is valid
        if(expiryMonth < 0 || expiryMonth> 12 ){
            errormsg="Invalid expiry date";
			return (false,errormsg);
        }
        
		
		return (true,"");	
	}	
    
    private bool ValidateVisa(int expiryYear){
		if (expiryYear % 4 == 0){
			return true;
		}
		return false;	
	}

    private bool ValidateMasterCard(int expiryYear){
        int i;
            for (i = 2; i <= expiryYear - 1; i++){
                if (expiryYear % i == 0){
                    return false;
                }
            }
            if (i == expiryYear){
                return true;
            }
            return false;
	}

	private (bool isValid, string cardType) ValidateRule(CreditCardItem item){
		String cardType="";
		int CardNoLength=0;
		int firstDigitCardNo=0;
		bool result=false;
        int expiryYear;

		CardNoLength=item.CARD_NO.ToString().Length;
		firstDigitCardNo=Int32.Parse(item.CARD_NO.ToString().Substring(0,1));
        expiryYear = Int32.Parse(item.EXPIRE_DATE.ToString().Substring(2,4));

		//get card type
		if (CardNoLength == 15 && firstDigitCardNo == 3){
			cardType="Amex";
            result = true;
		}
		if (CardNoLength == 16){
			if( firstDigitCardNo == 3){
				cardType="JCB";
                result = true;
			}
			if( firstDigitCardNo == 4){
				cardType="Visa";
				result = ValidateVisa(expiryYear);
			}
			if( firstDigitCardNo == 5){
				cardType="MasterCard";
                result = ValidateMasterCard(expiryYear);
			}
			if( firstDigitCardNo != 3 && firstDigitCardNo != 4 && firstDigitCardNo != 5){
				cardType="UnKnown";
			}
		}
		return (result,cardType);
	}
  }
}