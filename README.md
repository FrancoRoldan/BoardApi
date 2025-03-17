## Building the project

change the connection string to match your postgres credentials in the appsettings.json
``` code
"ConnectionStrings": {
  "DbConnString": "Server=localhost;Database=Board;User Id=user;Password=password;"
}
```

Build an .NET Core api with .NET Core CLI, which is installed with [the .NET Core SDK](https://www.microsoft.com/net/download). Then run
these commands from the CLI in the directory:

```console
dotnet build
dotnet run
```
