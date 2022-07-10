# CustomerInquiry

## Backend Project
- Inside backend/CustomerSupport folder
- set CustomerSupport.sln to be your startup project then click ctrl+f5 to build it
- The Project has UnitTesting using XUnit we can run test from Test tab in visual studio 

**Note**
- please make sure the IDE you use is visual studio 2022
- please make sure it's running on "http://localhost:5115/" as that's the baseURL for frontend

**Includes**
- IoC / DI
- In-Memory Caching
- Testing
- Logging using Serilog
- Error handler Middleware
- Used MediatR and FluentValidation

## Frontend Project
- Inside frontend folder
- npm install
- ng serve

**Note**
- please make sure the target in proxy.config.json is matching backend endpoint 

**Includes**
- Error handler interceptor
- Responsive used bootstrap 

## To Enhance
- I think the project is small and 2 layers (API, Application) will be enough but we could add Infrastructure Layer (In-Memory Caching instead of Application Layer) and common layer (to register services in it instead of Application Layer).
- we could add more components in FE like Error component and success component and enhance the UI to be look nicer.

