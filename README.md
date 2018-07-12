# credit-card
<h1>Software Architect technical assignment</h1>
<h2>Description</h2>
<p>Implement a service to provide a credit card number validation and return a result which contains
validation result and card type</p>
<p>Use best practices and design patterns to build testable and maintainable software.
Domain</p>
<h2>Card</h2>
1. Card Number (Numeric 15 or 16 digits)
1. Expiry date (MMYYYY)
<h2>Validate Result</h2>
1. Result (Valid, Invalid, Does not exist)
2. Card Type (Visa, Master, Amex, JCB or Unknown)
Validation Rule
1. Visa is a card number starts with 4
2. MasterCard is a card number starts with 5
3. Amex is a card number starts with 3
4. JCB is a card number starts with 3
5. The card starts with any other numbers is Unknown
6. Only Amex card number is 15 digits, the rest of card types have 16 digits long.
7. A valid Visa card is the card number which expiry year is a leap year.
8. A valid MasterCard card is the card number which expiry year is a prime number
9. All JCB card is valid
10. Card number must exist on the database, unless returned result is “Does not exist”
11. The rest case is “Invalid” card.
Server side
- RESTful Web API
Database
- MS SQL Server, please create 1 table to store card number and 1 Store Procedure to check card
existing
- Entity Framework to retrieve data by executing a Store Procedure above
Test project
- Swagger
- Unit tests to cover these cases:
  o Valid Visa
  o Valid MasterCard
  o Valid Amex
  o Valid JCB
  o Invalid Visa
  o Invalid MasterCard
  o Invalid Amex
  o Invalid JCB
Time frame
24 hours.
Source Code
Push your code to Github/Bitbucket including SQL Script.
We prefer to see that the candidate can use source control systems, so please make sure you’re not
pushing everything in a single commit, but having small atomic steps. Commit clean project ignoring
binaries and unnecessary resources
Tools and libraries
Candidate is free to use any additional third-party libraries and frameworks.
Bonus points for
 Logging
 Anything else you think worth adding