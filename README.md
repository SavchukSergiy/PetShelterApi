# PetSHelterApi

[![Статус збірки] Api is not published
[![Версія] 1

## Project description
This is a test RESTful API developed on ASP.NET Core that provides access to pet shelter data.

## Main functions
* Manage animal data (view all, view by name, add, update, delete)
* User authentication and authorization

### Prerequisites
* [.NET SDK](https://dotnet.microsoft.com/download) (version 8 or higher)
* [Visual Studio](https://visualstudio.microsoft.com/) (or another IDE that supports .NET development)
* [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) (or other database used by the project)
* [Postman](https://www.postman.com/) або [Swagger UI](URL_ВАШОГО_SWAGGER_UI) for API testing

### Steps to Start
Detailed steps to run your API locally.
1) **Clone the repository:**
   https://github.com/SavchukSergiy/PetShelterApi.git

2) **Configure the configuration:**
* Copy the `appsettings.Development.json` file (or another configuration file) and rename it, for example, to `appsettings.Local.json`.
* Edit the configuration file, specifying your settings for the database (connection string), external services, API keys, etc.

3) **Apply database migrations:**
```bash
dotnet ef database update -c [YOUR DATA CONTEXT NAME] -p [PATH TO PROJECT WITH CONTEXT] -s [PATH TO WEB PROJECT]
```
> Replace `[YOUR DATA CONTEXT NAME]`, `[PATH TO PROJECT WITH CONTEXT]` and `[PATH TO WEB PROJECT]` with the appropriate values ​​for your project.

4) **Run the API:**
```bash
dotnet run --project [PATH TO YOUR .csproj FILE]
```
> Replace `[PATH TO YOUR .csproj FILE]` with the path to your main API project file.

5) **Test the API:**
* Open [Swagger UI](URL_YOUR_SWAGGER_UI) in your browser (usually `https://localhost:XXXX/swagger`, where `XXXX` is the port your API is running on).
* Use [Postman](https://www.postman.com/) or another HTTP client to send requests to the API endpoints.


**JWT Bearer Authentication**
JWT (JSON Web Tokens) are used for authentication.

Get a token: Send a POST request to the /api/auth/login endpoint with your credentials.

Use the token: In the headers of your subsequent requests, add an Authorization header with the Bearer scheme and the received token:

Authorization: Bearer YOUR_JWT_TOKEN

Author Contacts
EMAIL (savchuksergiy94@gmail.com)
