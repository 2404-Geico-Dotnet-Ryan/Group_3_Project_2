
const BASE_URL = "http://localhost:5152";

let current_user = {};

// User Container Div
const userContainerDiv = document.querySelector("#login-user-container");
const newUserContainerDiv = document.querySelector("#new-user-container");

// User homepage containers
const homePageContainerDiv = document.querySelector("#home-page-container");
const userProfileContainerDiv = document.querySelector("#user-profile-container");
const newFoodContainerDiv = document.querySelector("#new-food-container");
const allFoodsContainerDiv = document.querySelector("#all-foods-container");
const newPurchaseContainerDiv = document.querySelector("#new-purchase-container");
// const allPurchasesContainerDiv = document.querySelector("#all-purchases-container");

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
    let loginDiv = document.querySelector("#login-user-container");

    // If the login container exists, remove all its children
    if (loginDiv != null) {
        while (loginDiv.firstChild) {
            loginDiv.firstChild.remove();
        }
    }
}

GenerateLoginContainer();

//Register New User
function GenerateNewUserContainer() {
    let newUserHeader = document.createElement("h4");
    newUserHeader.textContent = "Register";

    // Create the new user container div
    let newUserContainerDiv = document.createElement("div");
    newUserContainerDiv.id = "new-user-container";

    let newUsernameInput = document.createElement('input');
    newUsernameInput.type = 'text';
    newUsernameInput.id = 'new-username-input';

    let newUsernameInputLabel = document.createElement('label');
    newUsernameInputLabel.textContent = "Username";

    let newPasswordInput = document.createElement('input');
    newPasswordInput.type = 'password';
    newPasswordInput.id = 'new-password-input';

    let newPasswordInputLabel = document.createElement('label');
    newPasswordInputLabel.textContent = "Password";

    let registerButton = document.createElement('button');
    registerButton.textContent = "Register";

    userContainerDiv.appendChild(newUserContainerDiv);

    newUserContainerDiv.appendChild(newUserHeader);
    newUserContainerDiv.appendChild(newUsernameInputLabel);
    newUserContainerDiv.appendChild(newUsernameInput);
    newUserContainerDiv.appendChild(newPasswordInputLabel);
    newUserContainerDiv.appendChild(newPasswordInput);
    newUserContainerDiv.appendChild(registerButton);

    registerButton.addEventListener("click", GetNewUserInformation);
}

function GetNewUserInformation() {
    let username = document.querySelector("#new-username-input").value;
    let password = document.querySelector("#new-password-input").value;

    NewUser(username, password);
}

async function NewUser(username, password) {
    try {
        let response = await fetch(`${BASE_URL}/Users`, {
            method: "POST",
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify({
                "userId": 0,
                "username": username,
                "password": password,
                "roleId": 1
            }),
        });
        let data = await response.json();
        current_user = data;

        console.log(current_user);
        TeardownNewUserContainer();
        TeardownLoginContainer();
        generateHomePageContainer(data);
        console.log(data);
    } catch (e) {
        console.error('Registration Error:', e); // Added error logging
    }
}

function getNewUserInput() {
    let username = document.querySelector("#users-username-input").value;
    let password = document.querySelector("#users-password-input").value;


    if (username && password) {
        CreateNewUser(username, password);
    } else {
        NewUserErrorField();
    }
}
function NewUserErrorField() { }

function TeardownNewUserContainer() {
    let newUserContainerDiv = document.querySelector("#new-user-container");

    if (newUserContainerDiv != null) {
        while (newUserContainerDiv.firstChild) {
            newUserContainerDiv.firstChild.remove();
        }
    }
}

GenerateNewUserContainer();


// Generate a homepage for the user
function generateHomePageContainer(userData) {

    generateUserProfileContainer(userData);
    generateNewFoodContainer();
    generateAllFoodsContainer();
    generateNewPurchaseContainer();
    // generateAllPurchasesContainer();
}

// teardown the homepage for the user
function tearDownHomePageContainer() {
    while (homePageContainerDiv.firstChild) {
        homePageContainerDiv.firstChild.remove();
    }
}

//GENERATE NEW FOOD CONTAINER
function generateNewFoodContainer() {
    while (newFoodContainerDiv.firstChild) {
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

function getNewFoodInput() {
    let itemName = document.querySelector("#food-itemName-input").value;
    let price = document.querySelector("#food-price-input").value;
    let foodQuantity = document.querySelector("#food-foodQuantity-input").value;
    let inStock = document.querySelector("#food-inStock-input").checked;

    if (itemName && price && foodQuantity && inStock) {
        CreateNewFood(itemName, price, foodQuantity, inStock);
    } else {
        NewFoodErrorField();
    }

}


function NewFoodErrorField() { }


function generateUserProfileContainer(userData) {

    while (userProfileContainerDiv.firstChild) {
        userProfileContainerDiv.firstChild.remove()
    }

    let userHeader = document.createElement("h2");

    userHeader.textContent = userData.username;

    userProfileContainerDiv.appendChild(userHeader);
}

async function generateAllFoodsContainer() {

    while (allFoodsContainerDiv.firstChild) {
        allFoodsContainerDiv.firstChild.remove();
    }

    let foods = await GetAllFoods();
    for (const food of foods) {
        let elementCreated = generateFoodElement(food);
        allFoodsContainerDiv.appendChild(elementCreated);
    }
}


//generate food element
function generateFoodElement(food) {
    let foodElementDiv = document.createElement("div");
    foodElementDiv.id = `food-${food.foodId}`;


    let foodIdLabel0 = document.createElement("h6");
    foodIdLabel0.textContent = "Food ID: " + food.foodId;

    let foodNameLabel = document.createElement("h6");
    foodNameLabel.textContent = "Item Name: " + food.itemName;

    let foodPriceLabel = document.createElement("h6");
    foodPriceLabel.textContent = "Price: $" + food.price;

    let foodFoodQuantityLabel = document.createElement("h6");
    foodFoodQuantityLabel.textContent = "Quantity: " + food.foodQuantity;

    let foodInStockLabel = document.createElement("h6");

    foodInStockLabel.textContent = food.inStock;

    //if boolean value is true, then it will display "Available" else "Unavailable"
    if (food.inStock == true) {
        foodInStockLabel.textContent = "Available";
    }
    else {
        //color is red
        foodInStockLabel.style.color = "red";
        foodInStockLabel.textContent = "Unavailable";

    }
    console.log(food);


    foodElementDiv.appendChild(foodIdLabel0);
    foodElementDiv.appendChild(foodNameLabel);
    foodElementDiv.appendChild(foodPriceLabel);
    foodElementDiv.appendChild(foodFoodQuantityLabel);
    foodElementDiv.appendChild(foodInStockLabel);


    foodElementDiv.style.border = "thick solid #f8f1fe";
    foodElementDiv.style.textAlign = "center";

    return foodElementDiv;
}
function generateNewPurchaseContainer(){
    while(newPurchaseContainerDiv.firstChild){
        newPurchaseContainerDiv.firstChild.remove();
    }
    //label : UserID
    let purchaseUserIdInputLabel = document.createElement('label');
    purchaseUserIdInputLabel.textContent = "UserId";

    let purchaseUserIdInput = document.createElement("input");
    purchaseUserIdInput.id = "purchase-userId-input";
    purchaseUserIdInput.type = "number";
    purchaseUserIdInput.placeholder = "User ID";
    purchaseUserIdInput.style.display = "block";
    
    //label : FoodId
    let purchaseFoodIdInputLabel = document.createElement('label');
    purchaseFoodIdInputLabel.textContent = "FoodId";

    let purchaseFoodIdInput = document.createElement("input");
    purchaseFoodIdInput.id = "purchase-foodId-input";
    purchaseFoodIdInput.type = "number";
    purchaseFoodIdInput.placeholder = "Food ID";
    purchaseFoodIdInput.style.display = "block";

    //label : Purchase Quantity
    let purchasePurchaseQuantityInputLabel = document.createElement('label');
    purchasePurchaseQuantityInputLabel.textContent = "Purchase Quantity";

    let purchasePurchaseQuantityInput = document.createElement("input");
    purchasePurchaseQuantityInput.id = "purchase-purchaseQuantity-input";
    purchasePurchaseQuantityInput.type = "number";
    purchasePurchaseQuantityInput.placeholder = "Purchase Quantity";
    purchasePurchaseQuantityInput.style.display = "block";

    //label : Cost
    let purchaseCostInputLabel = document.createElement('label');
    purchaseCostInputLabel.textContent = "Cost";
    
    let purchaseCostInput = document.createElement("input");
    purchaseCostInput.id = "purchase-cost-input";
    purchaseCostInput.type = "currency";
    purchaseCostInput.placeholder = "Cost";
    purchaseCostInput.style.display = "block";

     //label : Purchase Date
     let purchasePurchaseDateInputLabel = document.createElement('label');
     purchasePurchaseDateInputLabel.textContent = "Purchase Date";
     
     let purchasePurchaseDateInput = document.createElement("input");
     purchasePurchaseDateInput.id = "purchase-purchaseDate-input";
     purchasePurchaseDateInput.type = "datetime-local";
     purchasePurchaseDateInput.placeholder = "Purchase Date";
     purchasePurchaseDateInput.style.display = "block";

     let purchaseLabel = document.createElement("h5");
     purchaseLabel.textContent = "Create New Purchase";

     let purchaseSubmitButton = document.createElement("button");
     purchaseSubmitButton.textContent = "Purchase";

    purchaseSubmitButton.addEventListener("click", getNewPurchaseInput);

    homePageContainerDiv.appendChild(newPurchaseContainerDiv);
    //Apend the fields and labels to the new purchase container
    newPurchaseContainerDiv.appendChild(purchaseLabel);
    newPurchaseContainerDiv.appendChild(purchaseUserIdInputLabel);
    newPurchaseContainerDiv.appendChild(purchaseUserIdInput);
    newPurchaseContainerDiv.appendChild(purchaseFoodIdInputLabel);
    newPurchaseContainerDiv.appendChild(purchaseFoodIdInput);
    newPurchaseContainerDiv.appendChild(purchasePurchaseQuantityInputLabel);
    newPurchaseContainerDiv.appendChild(purchasePurchaseQuantityInput);
    newPurchaseContainerDiv.appendChild(purchaseCostInputLabel);
    newPurchaseContainerDiv.appendChild(purchaseCostInput);
    newPurchaseContainerDiv.appendChild(purchasePurchaseDateInputLabel);
    newPurchaseContainerDiv.appendChild(purchasePurchaseDateInput);
    newPurchaseContainerDiv.appendChild(purchaseSubmitButton);

}

function getNewPurchaseInput(){
    let userId = document.querySelector("#purchase-userId-input").value;
    let foodId = document.querySelector("#purchase-foodId-input").value;
    let purchaseQuantity = document.querySelector("#purchase-purchaseQuantity-input").value;
    let cost = document.querySelector("#purchase-cost-input").value; 
    let purchaseDate = document.querySelector("#purchase-purchaseDate-input").value;    
    if(userId && foodId && purchaseQuantity && cost && purchaseDate){
        CreateNewPurchase(userId, foodId, purchaseQuantity, cost, purchaseDate);
    }else{
        NewPurchaseErrorField();
    }

}
function NewPurchaseErrorField() { }

async function generateAllPurchasesContainer(){
        while(allPurchasesContainerDiv.firstChild){
        allPurchasesContainerDiv.firstChild.remove();
        }

    let purchases = await GetAllPurchases();
        for (const purchase of purchases) {
        let elementCreated = generatePurchaseElement(purchase);
        allPurchasesContainerDiv.appendChild(elementCreated);
        }
}
function generatePurchaseElement(purchase){
    let purchaseElementDiv = document.createElement("div");
    purchaseElementDiv.id = `purchase-${purchase.purchaseId}`;
    
    let purchasePurchaseIdLabel = document.createElement("h5");
    purchasePurchaseIdLabel.textContent = "Purchase Id: "+ purchase.PurchaseId;
    
    let purchaseUserIdLabel = document.createElement("h5");
    purchaseUserIdLabel.textContent = "User Id: " + purchase.UserId;
    
    let purchaseFoodIdLabel = document.createElement("h5");
    purchaseFoodIdLabel.textContent = "Food Id: " +purchase.FoodId;
    
    let purchasePurchaseQuantityLabel = document.createElement("h5");
    purchasePurchaseQuantityLabel.textContent = "purchase Quantity: " + purchase.PurchaseQuantity;
    
    let purchaseCostLabel = document.createElement("h5");
    purchaseCostLabel.textContent = "Purchase Cost: " + purchase.Cost;
    
    let purchasePurchaseDateLabel= document.createElement("h5");
    purchasePurchaseDateLabel.textContent = "Purchase Date: " + purchase.PurchaseDate;
    
    console.log(purchase);

    homePageContainerDiv.appendChild(purchaseElementDiv);

    purchaseElementDiv.appendChild(purchasePurchaseIdLabel);
    purchaseElementDiv.appendChild(purchaseUserIdLabel);
    purchaseElementDiv.appendChild(purchaseFoodIdLabel);
    purchaseElementDiv.appendChild(purchasePurchaseQuantityLabel);
    purchaseElementDiv.appendChild(purchaseCostLabel);
    purchaseElementDiv.appendChild(purchasePurchaseDateLabel);


    purchaseElementDiv.style.border = "thick solid #f8f1fe";
    purchaseElementDiv.style.textAlign = "center";

    return purchaseElementDiv;
}


// User Controller Functions

// Function to log in the user

async function LoginUser(username, password) {
    try {
        let response = await fetch(`${BASE_URL}/Users/login`, {
            method: "POST",
            headers: {
                'Content-Type': "application/json"
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
        TeardownNewUserContainer()

        generateHomePageContainer(data);

    } catch (e) {
        console.error('Error logging in:', e); // Added error logging
    }
}


async function GetAllUsers() {
    try {
        let response = await fetch(`${BASE_URL}/Users`);
        let data = await response.json();
        console.log(data);
        return data;
    } catch (Error) {
        console.error(Error);
    }
}

async function GetUserById(id) {
    try {
        let response = await fetch(`${BASE_URL}/Users/${id}`);
        let data = await response.json();
        console.log(data);
        return data;
    } catch (Error) {
        console.error(Error);
    }
}

// Foods
// CREATE
async function CreateNewFood(itemName, price, foodQuantity, inStock) {
    try {
        let response = await fetch(`${BASE_URL}/Foods`, {
            method: "POST",
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify({
                itemName,
                price,
                foodQuantity,
                inStock
            })

        });

        console.log(response);
        if (response.ok) {
            alert("Food is created!")
        } else {
            alert("Food was not created")
        }
    } catch (error) {
        console.error(error);
    }
}

async function CreateNewPurchase(userId, foodId, purchaseQuantity, cost, purchaseDate){
    try{
        let response = await fetch(`${BASE_URL}/Purchases`, {
            method: "POST",
            headers: {
                'Content-Type': "application/json" // Corrected the content type to 'application/json'
            },
            body: JSON.stringify({
                userId,
                foodId,
                purchaseQuantity,
                cost,
                purchaseDate
            })
        });
        // let data = await response.json();
        // console.log(data);
        console.log(response);
        if(response.ok){
            alert("Purchase has been created!")
        }else{
            alert("Purchase was not created")
        }
    }catch(error){
        console.error(error);
    }
}

// READ
// Get by id
async function GetFoodById(id) {
    try {
        let response = await fetch(`${BASE_URL}/Foods/${id}`);
        let data = await response.json();
        console.log(data);
    } catch (error) {
        console.error(error);
    }
}

async function GetPurchaseById(id){
    try{
        let response = await fetch(`${BASE_URL}/Purchase/${id}`);
        let data = await response.json();
        console.log(data);
    }catch(error){
        console.error(error);
    }
}

// Get all of them
async function GetAllFoods() {
    try {
        let response = await fetch(`${BASE_URL}/Foods`);
        let data = await response.json();
        return data;
    } catch (error) {
        console.error(error);
    }

async function GetAllPurchases(){
    try{
        let response = await fetch(`${BASE_URL}/Purchases`);
        let data = await response.json();
        return data;
    } catch(error){
        console.error(error);
    }
    }
}