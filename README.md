<h1 align="center"> Financial App API </h1>
<p align="center">
<img src="https://img.shields.io/badge/STATUS-IN%20DEVELOPMENT-yellow"/>
<img src="https://img.shields.io/badge/WEEK-2%20OF%204-9cf"/>
</p>

<h2>Project Description</h2>
<div>API for personal finance management. It'll be developed as part of a Back-End learning activity from <a href="https://www.alura.com.br/challengesr">Alura Challenges</a>
to be fulling completed in the course of a month. Additional functionalities will be implemented for each week of the project as follows:</div>
<p>
<ul>
  <li><b>Week 1</b>: Create a financial app in WEB API with CRUD operations for incomes and expenses, also with validations and business rules.</li>
  <li><b>Week 2</b>: Create new functionalities such as categories for expenses and searching inserted datas by their descriptions.</li>
  <li><b>Week 3 and 4</b>: Implement an authorization system and deploy it into a cloud service provider.</li>
</ul>
</p>
The programming language chose for this challenge was <b>C#</b> in <b>.NET 6 Framework</b> and <b>SQL Server</b> as the database management system.

<h2>Status</h2>

<h3><b>For Week 1 - COMPLETED</b></h3>

Tasks performed:

  - WEB API project created;
  - Models for incomes and expenses created;
  - Controllers with CRUD operations created for both;
  - Database created with tables for both classes and connected with SQL Server's local database;
  - Validations and business requerimentes implemented;
  - All functions tested.
  
  <h3><b>For Week 2 - COMPLETED</b></h3>

Tasks performed:

  - Created a Categoy property for expenses;
  - DTO classes created for models and AutoMapper implemented;
  - Inserted the following queries:
    - List incomes and expenses by their name;
    - List incomes and expenses of given month of a year;
  - Created a financial summary class wich returns a JSON with the following informations of given month of a year:
    - Total amount for incomes;
    - Total amount for expenses;
    - Balance;
    - Total expenses by category;
  - Repositories implemented;
  - Interfaces for services and repositories created;
  - Code refactored;
  - Unit tests implemented for Controllers and Services.
  
  <h2>Validations</h2>
  
  <div> All fields are required for both requests (incomes and expenses) with the following rules:<div>
  <p>
  <ul>
    <li>Descriptions(names) must not exceed 30 characters;</li>
    <li>The amounts must be greater than zero;</li>
    <li>It's not allowed to create incomes and expenses with same names in the same month;</li>
    <li>It's not allowed to update the name of an existing income or expense if there's already another with same name in the same month;</li>
    <li>The default category for an expense is "Others" (value 0).
  </ul>  
  </p>
  </div>
   <details>
  <summary>Expense Categories</summary>
   <div> The categories with the constante values associated to it are:
   <pre>  
        Others = 0,
        Food = 1,
        Health = 2,
        Housing = 3,
        Transportation = 4,
        Education = 5,
        Entertainment = 6,
        Unforeseen = 7  
  </pre>
   </details>
  
  <h2>Functionalities</h2>
  <br>
  <b><i>The logic for income's methods also applies for expenses.</b></i>
  
  <h3>Income Requests</h3>
  <details>
  <summary>Create New Income [POST]</summary>
  <br>
  <div>An example of inputs for income.</div>
  <pre>
  {
    "incomeName": "Income's Description",
    "incomeAmount": "200.00",
    "incomeDate": "2022-07-23"  
  }
  </pre>    
  <div>If it's sucedded, it'll return Code 201 with the id for the data. For expense a category is specified:</div>
  <br>
  <pre>
  {
    "expenseName": "Expense's Description",
    "expenseAmount": "500.00",
    "expenseDate": "2022-08-03"  
    "category" : 2
  }
  </pre>   
  <div>If a validation requeriment is not met, it'll exhibit an error message:</div>
  <br>
  <pre>
  {
   "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "traceId": "00-480b43326ddb8c203c36e615163711d6-46b12767cacfa5cb-00",
  "errors": {
    "incomeName": [
      "Income must have a description"
    ] 
  }
  </pre>
   <div>If there's an income with same name in the same month it'll show the following error message:</div>
  <pre>
  {
      Income with same name already exists in "MONTH"
  }
  </pre>
  </details>
  <details>
  <summary>List Incomes [GET]</summary>
  <br>
  <div>It'll simple return all the incomes avalaible. For example:</div>
  <pre> 
  {
    "incomeId": 1,
    "incomeName": "Gas",
    "incomeAmount": 200,
    "incomeDate": "2022-08-01T00:00:00"
  },
  
    {
      "incomeId": 2,
      "incomeName": "Food",
      "incomeAmount": 200,
      "incomeDate": "2022-08-01T00:00:00"
    }
  </pre>   
  </details>
  <details>
  <summary>List Income By Id [GET]</summary>
  <br>
  <div>Returns a income by its Id. If it exists in the databse, it'll return successfully as "Ok", otherwise it'll show a NotFound result: </div>
  <pre> 
  {
    Error: response status is 404
  }
  </pre>   
  </details>
   <details>
  <summary>List Income By Description [GET]</summary>
  <br>
  <div>Checks if a given string is contained in the income's description. If there're incomes meeting the requiriment the database, it'll return successfully as     "Ok" with a list of incomes: </div>
  <pre> 
  Description searched: "Salary";
  [
    {
      "incomeId": 1,
      "incomeName": "Salary",
      "incomeAmount": 2000,
      "incomeDate": "2022-08-13T01:09:53.255"
    },
    {
      "incomeId": 3,
      "incomeName": "Salary",
      "incomeAmount": 2000,
      "incomeDate": "2022-07-05T01:09:53.255"
    },
    {
      "incomeId": 5,
      "incomeName": "Salary",
      "incomeAmount": 2000,
      "incomeDate": "2022-06-05T01:09:53.255"
    }
  ]
  </pre>   
  <div>  Otherwise it'll show a NotFound result:</div>
    <pre> 
  {
    Error: response status is 404
  }
  </pre>
  </details>
   <details>
  <summary>List Income By Month Of A Year [GET]</summary>
  <br>
  <div>Returns incomes of a given month of a year. If there're incomes meeting the requiriment the database, it'll return successfully as "Ok": </div>  
  <pre> 
  Year searched: 2022;
  Month searched: 8;
  [
    {
      "incomeId": 1,
      "incomeName": "Salary",
      "incomeAmount": 2000,
      "incomeDate": "2022-08-13T01:09:53.255"
    },
    {
      "incomeId": 4,
      "incomeName": "Bank Deposit",
      "incomeAmount": 1000,
      "incomeDate": "2022-08-13T04:31:56.278"
    },
    {
      "incomeId": 6,
      "incomeName": "Market Share",
      "incomeAmount": 1000,
      "incomeDate": "2022-08-14T23:27:39.784"
    },
   ]
  </pre>
  <div>Otherwise it'll show a NotFound result: </div>
  <pre> 
  {
    Error: response status is 404
  }
  </pre>
  </details>
  <details>
  <summary>Update Income [PUT]</summary>
  <br>
  <div>First it will check if the target income exists. Then it'll check if the updated name respects the same rule as when you add the 
  income. If all criteria are met, targeted income will be updated with a NoContent response:</div>
  <pre>   
    Code 204  
  </pre> 
  <div>Otherwise it'll return a BadRequest if searched income is not found:</div>
   <pre>  
   Error: response status is 400
    "reasons": [
        {
          "message": "Income not found",
          "metadata": {}
        }  
     ]
   </pre> 
  <div>It'll also return a BadRequest if a name with same description already exists:</div>
    <pre> 
    Error: response status is 400
     "reasons": [
        {
          "message": "Income with same name already exists in August",
          "metadata": {}
        }
     ]
   </pre> 
  </details>
   <details>
  <summary>Delete Income [DELETE]</summary>
  <br>
  <div>First it will check if the target income exists (returns NotFound if not). If so, it'll delete target income with a NoContent response. </div> 
  </details>
   <details>
  <summary>Month Summary [GET]</summary>
  <br>
  <div>It'll return the financial summary of a given month of a given year. For example:</div>
  <pre> 
  {
    "TotalIncome": 11000.0,
    "TotalExpense": 1300.0,
    "Balance": 9700.0,
    "ExpensesByCategory": [
        {
          "CategoryId": 1,
          "TotalCategoryIdExpense": 200.0
        },
        {
          "CategoryId": 4,
          "TotalCategoryIdExpense": 400.0
        },
        {
          "CategoryId": 6,  
          "TotalCategoryIdExpense": 700.0
        }
    ]
  }
  </pre>   
  <div>Notice a category will only be listed if it contains an expense.</div>
  </details>
  <details>
