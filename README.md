<h1>Software Architect technical assignment <muted>Credit-Card</muted></h1>
<h2>Description</h2>

<p>Implement a service to provide a credit card number validation and return a result which contains validation result and card
  type</p>
<p>Use best practices and design patterns to build testable and maintainable software.</p>

<h2>Domain</h2>
<h3>Card</h3>
<ol>
  <li>Card Number (Numeric 15 or 16 digits)</li>
  <li>Expiry date (MMYYYY)</li>
</ol>

<h3>Validate Result</h3>
<ol>
  <li>Result (Valid, Invalid, Does not exist)</li>
  <li>Card Type (Visa, Master, Amex, JCB or Unknown)</li>
</ol>

<h3>Validation Rule</h3>
<ol>
  <li>Visa is a card number starts with 4</li>
  <li>MasterCard is a card number starts with 5</li>
  <li>Amex is a card number starts with 3</li>
  <li>JCB is a card number starts with 3</li>
  <li>The card starts with any other numbers is Unknown</li>
  <li>Only Amex card number is 15 digits, the rest of card types have 16 digits long.</li>
  <li>A valid Visa card is the card number which expiry year is a leap year.</li>
  <li>A valid MasterCard card is the card number which expiry year is a prime number</li>
  <li>All JCB card is valid</li>
  <li>Card number must exist on the database, unless returned result is “Does not exist”</li>
  <li>The rest case is “Invalid” card.</li>
</ol>

<h3>Server side</h3>
<ul>
  <li>RESTful Web API</li>
</ul>

<h3>Database</h3>
<ul>
  <li>MS SQL Server, please create 1 table to store card number and 1 Store Procedure to check card existing</li>
  <li>Entity Framework to retrieve data by executing a Store Procedure above</li>
</ul>

<h3>Test Project</h3>
<ul>
  <li>Swagger</li>
  <li>Unit tests to cover these cases:
    <ul>
      <li>Valid Visa</li>
      <li>Valid MasterCard</li>
      <li>Valid Amex</li>
      <li>Valid JCB</li>
      <li>Invalid Visa</li>
      <li>Invalid MasterCard</li>
      <li>Invalid Amex</li>
      <li>Invalid JCB</li>
    </ul>
  </li>
</ul>

<h2>Time Frame</h2>
<p>24 hours.</p>

<h2>Source Code</h2>
<p>Push your code to Github/Bitbucket including SQL Script. </p>
<p>We prefer to see that the candidate can use source control systems, so please make sure you’re not pushing everything in
  a single commit, but having small atomic steps. Commit clean project ignoring binaries and unnecessary resources</p>

<h2>Tools and libraries</h2>
<p>Candidate is free to use any additional third-party libraries and frameworks.</p>

<h2>Bonus points for</h2>
<ul>
  <li>Logging</li>
  <li>Anything else you think worth adding</li>
</ul>