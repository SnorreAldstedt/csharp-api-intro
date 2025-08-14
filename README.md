# C# API Intro

## Commands

```
dotnet new sln --name workshop
dotnet new webapi --name workshop.wwwapi
dotnet sln add **/*.csproj
```
Visual studio:
```start devenv workshop.sln```
VS Code: ```code .```

## Installing Scalar/Swashbuckle

### From package manager console:

```
install-package Swashbuckle.AspNetCore
install-package Scalar.AspNetCore
```

### Update the Program.cs if statement to look like this:
```cs

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Demo API");
    });
    app.MapScalarApiReference();
}

```

### Update the Properties/launchSettings.json to look like this:

Update both the launchBrowser and launchUrl keys
```
{
  "$schema": "https://json.schemastore.org/launchsettings.json",
  "profiles": {
    "http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "http://localhost:5149",
      "launchUrl": "swagger",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "https://localhost:7239;http://localhost:5149",
      "launchUrl": "swagger",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```
