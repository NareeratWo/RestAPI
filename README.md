# RESTful Web API Credit card validator
A service to provide a credit card number validation and return a result which contains validation result and card type

## Prerequisition
- Install MSSQL Server
- PostMan or any program to call RESTful web service
- dotnet.core 2.0 or above

## Setup Migration Script
1. run script for create table\
Path: SQL_Script/1_CREATE_TABLE_CREDIT_CARD.sql

2. run script for mockup data test\
Path: SQL_Script/2_Mockup_Data_CREDIT_CARD.sql

3. run script for create store procedure\
Path: SQL_Script/3_SP_CHECK_CREDIT_CARD

4. Modify connection string\
4.1 Path: RestAPI/credit_card_project/appsettings.json\
4.2 Path: RestAPI/credit_card_project/Models/CreditCardContext.cs

## Run API
run services by command line
 `dotnet run`


## How to test?
Using the Postman to call RESTFul api, follows the screenshot as below.

![enter image description here](https://github.com/NareeratWo/RestAPI/blob/master/credit_card_project/README/Postman.png)

## Swagger (API Contract)
AS an API Contract you can copy **Swagger/swagger.yml** to https://editor.swagger.io/ to see credit card model and response.

![enter image description here](https://github.com/NareeratWo/RestAPI/blob/master/credit_card_project/README/Swagger.png)



