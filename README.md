# _Pierre's Sweet and Savory Treats_

#### By _**Richard Cha**_

#### _This web app allows adding of new Treats and Flavors, and assigning Treats Flavors and Flavors Treats._

### <u>Table of Contents</u>
* <a href="#Description">Description</a>
    * <a href="#-description">Description</a>
    * <a href="#-known-bugs">Known Bugs</a>
    * <a href="#-built-with">Built With</a>
* <a href="#-getting-started">Getting Started</a>
    * <a href="#-prerequisites">Prerequisites</a>
    * <a href="#-setup-and-use">Setup and Use</a>
* <a href="#-api-documentation">API Documentation</a>
* <a href="#-contributors">Auxiliary</a>
    * <a href="#-contributors">Contributors</a>
    * <a href="#-contact-and-support">Contact</a>
    * <a href="#-license">License</a>
    * <a href="#-acknowledgements">Acknowledgements</a>

## Description

_This web application gives Create, Update, Delete, Adding a Flavor to a Treat, and Adding a Treat to a Flavor functionality to users who register and login to an account for both a Treats and a Flavors, updating everything to a database. It will then display all Treats and Flavors on the homepage and a specific Treat or Flavor details to everyone whether logged in or not._

## Technologies Used

* _C#_
* _.Net 6_
* _ASP.NET Core 6 MVC_
* _Visual Studio Code 2019_
* _MySql_
* _MySql Workbench_
* _Entity Framework Core 6_
* _Pomelo Entity Framework Core 6 MySql_
* _Razor 6_
* _BootStrap_
* _ASP.NET Core Identity_

## Setup/Installation Requirements

* _Install .Net 6 SDK:_
* [OS X and Windows Instructions](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-c-and-net)
* _Setup MySql Workbench:_
* [OS X and Windows Instructions](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql)
* _Clone this repo to a local directory_
* _Navigate to the local directory (YourPath/PierresTreats.Solution/PierresTreats) and create a new file "appsettings.json" 
* _Open this file with Visual Studio Code 2019 and add:
```
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=[YOUR-DB-NAME];uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
    }
} 
```
replace [YOUR-USERNAME-HERE] and [YOUR-PASSWORD-HERE] with the your own user and password values, and [YOUR-DB-NAME] with any name you'd like to call the database, i.e. "pierres_treats"_

* _Using Terminal on OS X or PowerShell on Windows navigate to the directory that this repo was cloned to, then the PierresTreats folder (YourPath/PierresTreats.Solution/PierresTreats) and run the terminal commands (without the '$'):_ 
* _$ dotnet ef database update_
* _Making sure you've followed the MySqlWorkbench installation instructions, open MySql Workbench and select the Local 3306 server_
* _Confirm the database [YOUR-DB-NAME] that you named was successfully created by clicking on the "Schemas" tab and seeing the schema listed._ 
* _Then run the program with command :_
* _$ dotnet watch run_

## Endpoints
```
GET http://localhost:5000/api/v1/animals/
GET http://localhost:5000/api/v1/animals/{id}
POST http://localhost:5000/api/v1/animals/
PUT http://localhost:5000/api/v1/animals/{id}
DELETE http://localhost:5000/api/v1/animals/{id}
```
* _Replace {id} with the AnimalId you would like to GET, PUT, or DELETE_
* _Tip: You can find all AnimalId's from requesting GET http://localhost:5000/api/v1/animals/ end point_
* GET http://localhost:5000/api/v1/animals/ endpoint optional query parameters:
* 

## Example Query
```
https://localhost:5000/api/v1/animals/?name=Clint&species=Cat&gender=Male
```

## Example Returned JSON Response
```
{
    "animalId": 4,
    "species": "Cat",
    "name": "Clint",
    "age": "10y 8m",
    "weight": "15.8lbs",
    "sex": "Male"
}
```

## Known Bugs

* _None_

## License

_If you have any issues or have questions, ideas or concerns please contact me at [charichard09@gmail.com](mailto:charichard09@gmail.com)_

MIT License

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

Copyright (c) _1-13-23_ _Richard Cha_