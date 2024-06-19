// I am going for an SPA (Single Page Application)

/*
    It is helpful to organize your function into two types

        - Communication with your API
            - This things like your specific endpoints
            - all the CRUD operations for your api should be established and tested first in your script before you go ahead and start using them
        - Manipulating your DOM
            - Generating and tearing down components


*/

const BASE_URL = "http://localhost:5152";

let current_user = {};

// This means I need functions that can be run to create entire components on the fly, and tear them down once I am done with them
// I want to do this, so that I can keep track of the users' information on the same script.

/* Teardown: when a component is removed from the DOM or unmounted, it is said to be torn down.  
During the teardown process, all the event listeners and references to the component are removed from the memory. 
This is done to free up memory and prevent memory leaks.*/

// User Container Div
const userContainerDiv = document.querySelector("#user-authorization-container");
const newUserContainerDiv = document.querySelector("#new-user-container");
// User homepage containers
const homePageContainerDiv = document.querySelector("#home-page-container");
const userProfileContainerDiv = document.querySelector("#user-profile-container");
const newFoodContainerDiv = document.querySelector("#new-food-container");
const allFoodsContainerDiv = document.querySelector("#all-foods-container");
//const menuContainerDiv = document.querySelector("#menu-container");

// Login Container Creation Function
function GenerateLoginContainer() {
    let loginHeader = document.createElement("h4");
    loginHeader.textContent = "Login";
    // Create the main login container div
    let loginDiv = document.createElement("div");
    loginDiv.id = "login-container";

    // Create the username input field and label
    let usernameInput = document.createElement('input');
    usernameInput.type = 'text';
    usernameInput.id = 'username-input';

    let usernameInputLabel = document.createElement('label');
    usernameInputLabel.textContent = "Username";

    // Create the password input field and label
    let passwordInput = document.createElement('input');
    passwordInput.type = 'password';
    passwordInput.id = 'password-input';

    let passwordInputLabel = document.createElement('label');
    passwordInputLabel.textContent = "Password";

    // Create the login button
    let loginButton = document.createElement('button');
    loginButton.textContent = "Login";

    // Append the login container to the main user container
    userContainerDiv.appendChild(loginDiv);

    // Append the username and password fields and labels to the login container
    loginDiv.appendChild(loginHeader);
    loginDiv.appendChild(usernameInputLabel);
    loginDiv.appendChild(usernameInput);
    loginDiv.appendChild(passwordInputLabel);
    loginDiv.appendChild(passwordInput);
    loginDiv.appendChild(loginButton);

    // Add an event listener to the login button to handle login
    loginButton.addEventListener("click", GetLoginInformation);
}

// Function to get login information from input fields
function GetLoginInformation() {
    let username = document.querySelector("#username-input").value;
    let password = document.querySelector("#password-input").value;

    // Call the function to log in the user
    LoginUser(username, password);
}


// Function to tear down the login container
function TeardownLoginContainer() {
    // Find the login container
    let loginDiv = document.querySelector("#login-container");

    // If the login container exists, remove all its children
    if (loginDiv != null) {
        while (loginDiv.firstChild) {
            loginDiv.firstChild.remove();
        }
    }
}

// Generate and tear down a login component
GenerateLoginContainer();


function GenerateAddUserContainer() {
    let addUserHeader = document.createElement("h4");
    addUserHeader.textContent = "Register";
  
    let addnewUserContainerDiv = document.createElement("div");
    newUserContainerDiv.id = "new-user-container";
  
    // Create the username input field and label
    let usernameInput = document.createElement('input');
    usernameInput.type = 'text';
    usernameInput.id = 'username-input';

    let usernameInputLabel = document.createElement('label');
    usernameInputLabel.textContent = "Username";

    // Create the password input field and label
    let passwordInput = document.createElement('input');
    passwordInput.type = 'password';
    passwordInput.id = 'password-input';

    let passwordInputLabel = document.createElement('label');
    passwordInputLabel.textContent = "Password";
    
    let registerButton = document.createElement('button');
    registerButton.textContent = "Register";

    newUserContainerDiv.appendChild(addnewUserContainerDiv);

    addnewUserContainerDiv.appendChild(addUserHeader);
    addnewUserContainerDiv.appendChild(usernameInputLabel);
    addnewUserContainerDiv.appendChild(usernameInput);
    addnewUserContainerDiv.appendChild(passwordInputLabel);
    addnewUserContainerDiv.appendChild(passwordInput);
    addnewUserContainerDiv.appendChild(registerButton);

    registerButton.addEventListener("click", GetAddUserInformation);
}

function GetAddUserInformation() {
    let userName = document.querySelector("#userName-input").value;
    let password = document.querySelector("#password-input").value;

    AddUser(userName, password);
  }
  
  async function AddUser(userName, password) {
    try {
      let response = await fetch(`${BASE_URL}/User`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          UserId: 0,
          Username: username,
          Password: password
        }),
      });
      let data = await response.json();
      current_user = data;
      console.log(current_user);
      GenerateUserProfileContainer(current_user);
      return current_user;
    } catch (Error) {
      console.error(Error);
    }
}
function TeardownCreateUserContainer() {
    let newUserDiv = document.querySelector("#new-user-container");

    if (newUserDiv != null) {
        while (newUserDiv.firstChild) {
            newUserDiv.firstChild.remove();
        }
    }
}  

GenerateAddUserContainer();


// Generate a homepage for the user
function generateHomePageContainer(userData){

    generateUserProfileContainer(userData);
    generateNewFoodContainer();
    generateAllFoodsContainer();
}

// teardown the homepage for the user
function tearDownHomePageContainer(){
    while(homePageContainerDiv.firstChild){
        homePageContainerDiv.firstChild.remove();
    }
}

//GENERATE NEW FOOD CONTAINER
function generateNewFoodContainer(){
    while(newFoodContainerDiv.firstChild){
        newFoodContainerDiv.firstChild.remove();
    }

    //label: Food
    let foodNameInputLabel = document.createElement('label');
    foodNameInputLabel.textContent = "Food";

    let foodNameInput = document.createElement("input");
    foodNameInput.id = "food-itemName-input";
    foodNameInput.type = "text";
    foodNameInput.placeholder = "Food Name";
    foodNameInput.style.display = "block";
    
    // Label: Price
    let foodPriceInputLabel = document.createElement('label');
    foodPriceInputLabel.textContent = "Price";

    let foodPriceInput = document.createElement("input");
    foodPriceInput.id = "food-price-input";
    foodPriceInput.type = "currency";
    foodPriceInput.placeholder = "Price";
    foodPriceInput.style.display = "block";

    //Label: Quantity
    let foodQuantityInputLabel = document.createElement('label');
    foodQuantityInputLabel.textContent = "Quantity";

    let foodQuantityInput = document.createElement("input");
    foodQuantityInput.id = "food-foodQuantity-input";
    foodQuantityInput.type = "number";
    foodQuantityInput.placeholder = "Quantity";
    foodQuantityInput.style.display = "block";

    //Label: In Stock
    let foodInStockInputLabel = document.createElement('label');
    foodInStockInputLabel.textContent = "In Stock?";

    let foodInStockInput = document.createElement("input");
    foodInStockInput.id = "food-inStock-input";
    foodInStockInput.type = "checkbox";
    foodInStockInput.placeholder = "In Stock : true or false";
    foodInStockInput.style.display = "block";

    let foodLabel = document.createElement("h5");
    foodLabel.textContent = "Add New Food Item";

    let foodSubmitButton = document.createElement("button");
    foodSubmitButton.textContent = "Submit";

    foodSubmitButton.addEventListener("click", getNewFoodInput);

    // Append the fields and labels to the new food container
    newFoodContainerDiv.appendChild(foodLabel);
    newFoodContainerDiv.appendChild(foodNameInputLabel);
    newFoodContainerDiv.appendChild(foodNameInput);

    newFoodContainerDiv.appendChild(foodPriceInputLabel);
    newFoodContainerDiv.appendChild(foodPriceInput);

    newFoodContainerDiv.appendChild(foodQuantityInputLabel);
    newFoodContainerDiv.appendChild(foodQuantityInput);
   
    newFoodContainerDiv.appendChild(foodInStockInputLabel);
    newFoodContainerDiv.appendChild(foodInStockInput);

    //Submit Button
    newFoodContainerDiv.appendChild(foodSubmitButton);
    

}

function getNewFoodInput(){
    let itemName = document.querySelector("#food-itemName-input").value;
    let price = document.querySelector("#food-price-input").value;
    let foodQuantity = document.querySelector("#food-foodQuantity-input").value;
    let inStock = document.querySelector("#food-inStock-input").checked;

    if(itemName && price && foodQuantity && inStock){
        CreateNewFood(itemName, price, foodQuantity, inStock);
    }else{
        NewFoodErrorField();
    }

}

/* Future work:
This is not really functionality, it is UI/UX things for the website which make the process of interacting with your website 
better for the user.*/

function NewFoodErrorField()
{   //Future work:
    // generate components on the page that tell the user that they have done something wrong that is not a pop box
    // alert("You need to provide fields");
}


function generateUserProfileContainer(userData){

    while(userProfileContainerDiv.firstChild){
        userProfileContainerDiv.firstChild.remove()
    }

    let userHeader = document.createElement("h2");

    userHeader.textContent = userData.username;

    userProfileContainerDiv.appendChild(userHeader);
}

async function generateAllFoodsContainer(){

    while(allFoodsContainerDiv.firstChild){
        allFoodsContainerDiv.firstChild.remove();
    }

    let foods = await GetAllFoods();
    for (const food of foods) {
        let elementCreated = generateFoodElement(food);
        allFoodsContainerDiv.appendChild(elementCreated);
    }
}


//generate food element
function generateFoodElement(food){
    let foodElementDiv = document.createElement("div");
    foodElementDiv.id = `food-${food.foodId}`;


    let foodIdLabel0 = document.createElement("h6");
    foodIdLabel0.textContent = "Food ID: " + food.foodId;

    // let foodIdLabel = document.createElement("h6");
    // foodIdLabel.textContent = food.foodId;

    let foodNameLabel = document.createElement("h6");
    foodNameLabel.textContent = "Item Name: " + food.itemName;

    let foodPriceLabel = document.createElement("h6");
    foodPriceLabel.textContent = "Price: $" + food.price;

    let foodFoodQuantityLabel = document.createElement("h6");
    foodFoodQuantityLabel.textContent = "Quantity: " +  food.foodQuantity;

    let foodInStockLabel = document.createElement("h6");

    foodInStockLabel.textContent = food.inStock;
    
    //if boolean value is true, then it will display "Available" else "Unavailable"
    if(food.inStock == true){
        foodInStockLabel.textContent = "Available";
    }
    else{
        //color is red
        foodInStockLabel.style.color = "red";
        foodInStockLabel.textContent = "Unavailable";
        
    }
    console.log(food);


    foodElementDiv.appendChild(foodIdLabel0);
    //foodElementDiv.appendChild(foodIdLabel);
    foodElementDiv.appendChild(foodNameLabel);
    foodElementDiv.appendChild(foodPriceLabel);
    foodElementDiv.appendChild(foodFoodQuantityLabel);
    foodElementDiv.appendChild(foodInStockLabel);


    foodElementDiv.style.border = "thick solid #0000FF";
    foodElementDiv.style.textAlign = "center";

    return foodElementDiv;
}


// User Controller Functions

// Function to log in the user

/*
    This is a combination of Async Await and the Fetch API

    The Fetch API is dedicated to doing asynchronous network requests
    By default the Fetch API will be doing GET requests to a specific endpoint

    The syntax of a fetch request looks like this:


    fetch("URL", {REQUEST DATA BODY})

    for example a GET Request would look like this:

    fetch("URL"); // this is because by default the Fetch API will do a get request so you do not have to provide a request body


    For a post request, and any request other than a GET request, you have to provide the request body object


    First thing you need, is the URL that you want to communicate with. For this example, we are attempting to login to our database, and so we are communicating the the User controller, with the login action that is routed to /login

    so the URL for that specific action is POST : http://localhost:5236/Users/login

    To make a fetch request a POST request, the second parameter to the fetch() call is an object that defines the request

    {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({JS Object})
    }

*/
async function LoginUser(username, password) {
    try {
        let response = await fetch(`${BASE_URL}/Users/login`, {
            method: "POST",
            headers: {
                'Content-Type': "application/json" // Corrected the content type to 'application/json'
            },
            body: JSON.stringify({
                "Username": username, 
                "Password": password
            })
        });

        let data = await response.json();
        current_user = data;

        console.log(current_user);
        TeardownLoginContainer()

        generateHomePageContainer(data);
        
    } catch (e) {
        console.error('Error logging in:', e); // Added error logging
    }
}



async function GetAllUsers(){
    try{
        let response = await fetch(`${BASE_URL}/Users`);
        let data = await response.json();
        console.log(data);
        return data;
    }catch(Error){
        console.error(Error);
    }
}

async function GetUserById(id){
    try{
        let response = await fetch(`${BASE_URL}/Users/${id}`);
        let data = await response.json();
        console.log(data);
        return data;
    }catch(Error){
        console.error(Error);
    }
}

// This function is used to create a new user
// This is a critical function for registering someone in this application
// After having made this function, and tested it out, you can now build out the inputs and buttons needed to allow someone to create a user from the website

// async function CreateNewUser(username, password){
//     try{
//         let response = await fetch(`${BASE_URL}/Users`, {
//             method: "POST",
//             headers: {
//                 'Content-Type': "application/json"
//             },
//             body: JSON.stringify({
//                 "Username": username, 
//                 "Password": password,
//             })
//         });
//         // let data = await response.json();
//         // console.log(data);
//         console.log(response);
//         if(response.ok){
//             // alert will create a pop up box that the user will see no matter waht
//             // This is not a good way of telling the user that what they did was successful or unsuccessful, it is just here as a placeholder for development purposes
//             // A preferable solution is a modal
//             alert("User is created!")
//         }else{
//             alert("User was not created")
//         }

//     }catch(error){
//         console.error(error);
//     }
// }

// CRUD functions for these data models

// Foods
// CREATE
async function CreateNewFood(itemName, price, foodQuantity, inStock){
    try{
        let response = await fetch(`${BASE_URL}/Foods`, {
            method: "POST",
            headers: {
                'Content-Type': "application/json" // Corrected the content type to 'application/json'
            },
            body: JSON.stringify({
                itemName,
                price,
                foodQuantity,
                inStock
            })

        });                 



        console.log(response);
        if(response.ok){
            // alert will create a pop up box that the user will see no matter waht
            // This is not a good way of telling the user that what they did was successful or unsuccessful, it is just here as a placeholder for development purposes
            // A preferable solution is a modal
            alert("Food is created!")
        }else{
            alert("Food was not created")
        }
    }catch(error){
        console.error(error);
    }
}
// READ
// Get by id
async function GetFoodById(id){
    try{
        let response = await fetch(`${BASE_URL}/Foods/${id}`);
        let data = await response.json();
        console.log(data);
    }catch(error){
        console.error(error);
    }
}

// Get all of them
async function GetAllFoods(){
    try{
        let response = await fetch(`${BASE_URL}/Foods`);
        let data = await response.json();
        return data;
    }catch(error){
        console.error(error);
    }
}