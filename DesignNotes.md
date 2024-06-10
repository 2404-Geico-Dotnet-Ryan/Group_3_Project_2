Bake Shop:
Intention of this doc: outline user functionality and backend functionality

Backend to the User Interface:
Data Layer = 
- lives in the BakeShopWebApp SQL Database
- Represented in our Models: Food, User, Role, Purchase

Data Access Layer = 
- Repo replaced by AppDbContext 
- connection string (appsettings.json)

Service Layer = business logic
- FoodService, UserService, RoleService, PurchaseService
- IFoodService, IUserService, IRoleService, IPurchaseService

Controller Layer = application logic
- FoodController, UserController, RoleController, PurchaseController

Presentation Layer = Converting Data into a presentable layer
- DTOs via JSON format

Application Layer = Developing an interface for the end user to use the presented information
- HTML 
- Script
- CSS



Original Data Layer Notes:
### Layers

- Application Layer - Program.cs
  - Developing an interface for the end user to use the presented information

- Presentation Layer
  - Converting Data into a presentable layer

- Controller Layer
  - is responsible for handling Application Logic, which includes ideas like processing requests and generating responses.

- Service Layer = FoodServices.cs, UserServices.cs
  - is responsible for performing Business Logic, which includes things like filtering, searching, sorting, validating, etc...
    - Would do so upon the data that was retrieved by the Repository Layer.

- Data Access Layer - Repository Layer = BGoodsRepo.cs, CartRepo.cs, UserRepo.cs
  - is responsible for data(base) interaction. Theses objects that we create will perform any amount of retrieval, manipulation, destruction to our data.
    - These Objects are referred as Data Access Objects: DAOs

- Data Layer = Food.cs, User.cs; BakedGoods.cs(?), CustomerCart.cs(?), UserUti.cs(?)
  - Where all data exists. Typically stored in something like a Database, or perhaps some form of a file system.
  - Represented in your Applications through: Models
    - Cars, Users, Courses, BankAccounts, Roles, etc...
