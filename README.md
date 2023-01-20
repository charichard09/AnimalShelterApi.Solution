# _Animal Shelter API_

#### By _**Richard Cha**_

#### _This web API will list available cats and dogs at a shelter_

### <u>Table of Contents</u>
* <a href="#Description">Description</a>
* <a href="#Technologies-Used">Technologies Used</a>
* <a href="#Setup/Installation-Requirements">Setup/Installation Requirements</a>
* <a href="#Example-Query">Example Query and JSON Response</a>
* <a href="#API-Endpoints">API Endpoints</a>
* <a href="#Path-Parameters">Path Parameters</a>
* <a href="#Versions">Versions</a>
* <a href="#Known-Bugs">Known Bugs</a>
* <a href="#License">License</a>

## Description

_Animal Shelter API is an API that when requested to GET all animals or an individual animal, will return a reponse containing all animals or an individual animal. Animal Shelter API is seeded with 8 animals in the shelter database, but also has full Create, Update, and Delete functionality for any new or existing animals._
_For this projects Further Exploration, Versioning was implemented. Versioning is the creation and management of multiple web API versions. How it is used here is to have a version 1 as a base minimum viable product, and have a version 2 as a working but work in progress version with additional code and comments_

## Technologies Used

* _C#_
* _.Net 6_
* _ASP.NET Core Web API_
* _Visual Studio Code 2019_
* _MySql_
* _MySql Workbench_
* _Entity Framework Core 6_
* _Pomelo Entity Framework Core 6 MySql_
* _ASP.NET Core Identity_

## Setup/Installation Requirements

* _Install .Net 6 SDK:_
* [OS X and Windows Instructions](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-c-and-net)
* _Setup MySql Workbench:_
* [OS X and Windows Instructions](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql)
* _Clone this repo to a local directory_
* _Navigate to the local directory (YourPath/AnimalShelterApi.Solution/AnimalShelterApi) and create a new file "appsettings.json" 
* _Open this file with Visual Studio Code 2019 and add:
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[YOUR-DB-NAME];uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
  }
}

```
replace [YOUR-USERNAME-HERE] and [YOUR-PASSWORD-HERE] with the your own user and password values, and [YOUR-DB-NAME] with any name you'd like to call the database, i.e. "animal_shelter_api"_

* _Using Terminal on OS X or PowerShell on Windows navigate to the directory that this repo was cloned to, then the AnimalShelterApi folder (YourPath/AnimalShelterApi.Solution/AnimalShelterApi) and run the terminal commands (without the '$'):_ 
* _$ dotnet ef database update_
* _Making sure you've followed the MySqlWorkbench installation instructions, open MySql Workbench and select the Local 3306 server_
* _Confirm the database [YOUR-DB-NAME] that you named was successfully created by clicking on the "Schemas" tab and seeing the schema listed._ 
* _Then run the program with command :_
* _$ dotnet watch run_
* _This will autolaunch Swagger in your browser_
* _Test any API endpoints in Swagger, POSTMAN, or your own app_

## API Endpoints
```
GET http://localhost:5000/api/v1/animals/
GET http://localhost:5000/api/v1/animals/{id}
POST http://localhost:5000/api/v1/animals/
PUT http://localhost:5000/api/v1/animals/{id}
DELETE http://localhost:5000/api/v1/animals/{id}
```
* _Replace {id} with the AnimalId you would like to GET, PUT, or DELETE_
* _Tip: You can find all AnimalId's from requesting GET http://localhost:5000/api/v1/animals/ end point_

## Path Parameters
| Parameter | Type | Required | Description |
| :---: | :---: | :---: | --- |
| Species | String | Not Required | Returns animals that match cat or dog |
| Name | String | Not Required | Returns animals that match name |
| Sex | String | Not Required | Returns animals that match sex |

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

## Versions
* _Version 1: Stable version working version with no bugs._ 
* _Version 2: A non stable work in progress version that will add additional search query parameters and the logic to handle them_

## Known Bugs

* _Version 2: Linq query for search parameter handling with Regular Expressions is not working and throws the following error:
System.InvalidOperationException...
Translation of method 'System.Text.RegularExpressions.Regex.Match' failed_

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

Copyright (c) _1-20-23_ _Richard Cha_