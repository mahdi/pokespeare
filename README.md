# Pokespeare API v1.0

This is a simple REST API written in .NET 5 / ASP.NET WebAPI. It translates a Pokemon description (by getting its name) into its Shakespearean description! 

# Build
You need to have Docker installed on your machine to build and run the container.

Build the image first:
```docker
docker build -t pokespeare .
```

# Run
And, run it:
```docker
docker run --rm -p 5000:80 --name pokespeare pokespeare
```

Now the application is running at `http://localhost:5000`; to call the API method send a `GET` request to `http://localhost:5000/pokemon/charizard`

# Tests
Unit tests are available under `tests\Pokespeare.Api.Tests`; to run the tests using .NET CLI:
```
dotnet restore
dotnet build
dotnet test
```