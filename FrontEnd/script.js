//const BASE_URL = "http://localhost:5236";

let current_user = {};


// This means I need functions that can be run to create entire components on the fly, and tear them down once I am done with them

// I want to do this, so that I can keep track of the users' information on the same script

// User Container Div
const userContainerDiv = document.querySelector("#user-authorization-container");

// Login Container Creation Function
function GenerateLoginContainer() {
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
    loginDiv.appendChild(usernameInputLabel);
    loginDiv.appendChild(usernameInput);
    loginDiv.appendChild(passwordInputLabel);
    loginDiv.appendChild(passwordInput);
    loginDiv.appendChild(loginButton);

    // Add an event listener to the login button to handle login
    loginButton.addEventListener("click", GetLoginInformation);
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

// Function to get login information from input fields
function GetLoginInformation() {
    let username = document.querySelector("#username-input").value;
    let password = document.querySelector("#password-input").value;

    // Call the function to log in the user
    LoginUser(username, password);
}

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
        generateHomePageContainer(data);
        // console.log(data);
    } catch (e) {
        console.error('Error logging in:', e); // Added error logging
    }
}

// Generate and tear down a login component
GenerateLoginContainer();
// TeardownLoginContainer(); // Uncomment this line to tear down the login component



// Generate a homepage for the user

function generateHomePageContainer(userData){
    let homePageContainer = document.querySelector("#home-page-container");

    while(homePageContainer.firstChild){
        homePageContainer.firstChild.remove();
    }

    let userHeader = document.createElement("h2");
    let emailHeader = document.createElement("h3");

    userHeader.textContent = userData.username;
    emailHeader.textContent = userData.email;

    homePageContainer.appendChild(userHeader);
    homePageContainer.appendChild(emailHeader);

}

function tearDownHomePageContainer(){
    while(homePageContainer.firstChild){
        homePageContainer.firstChild.remove();
    }
}


// teardown the homepage for the user




// User Controller Functions

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

// Test these API calls as you are making them so that you can verify that it works inside your script before you actually use them in your website
// GetAllUsers();
// GetUserById(1);