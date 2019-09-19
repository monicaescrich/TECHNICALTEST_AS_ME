# TECHNICALTEST_AS_ME
 REST API to manage a small snacks store using .net Core.

#Features 
 - Adding/Removing products and modify their stock quantity.
 - Modify the price of the products 
 - Save a log of the price updates for a product.
 - Buy a product
 - Liking a product
 - Obtain a list of all the available products.
 - Pagination functionality
 - Search through the products by name.
 
 # Frameworks and Libraries
 The API uses the following libraries and frameworks to deliver the  	   functionalaties described above:

Entity Framewok Core (for data access)
AutoMapper (for mapping between domain entities and resource classes)

# How to Test 
To test the API endpoints you'll need to follow the nex steps: 
First of all, clone this repository and open it in terminal. Then restore all dependencies and run the project. 
Restore database on SQL Server called SNACK Store.bak

There is already two predefined users configured to test the application, one with common users permission and another with admin permissions.

To validate de features you can import the POSTMAN collection attached on the repositorie to test functionality. 

Some requests need validation token to execute the request succesfully 

# Requesting access tokens
To request access tokens, make a post request to http://localhost:5000/api/login sending a JSON object with user credentials. The response will be a JSON object with:

An access token which can be used to access protected API endpoints;
A request token, necessary to get a new access token when an access token expires;
A long value that represents the expiration date of the token.
Access tokens expire can be changed in appseting.json.

  # Accesing protected data 
 
Accessing protected data

With a valid access token in hands, add the following header to your request:

Authorization: Bearer your_valid_access_token_here

# Considerations 
This project was created with the intent of show some of the knowlege acquired trough time, never the less, due to lack of time some details may be ignored or forgotten. 

Any doubts about implementation details or if you find a bug you can contact me. 
