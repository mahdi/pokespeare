# Pokespeare API v1.0
[![Docker Cloud Automated build](https://img.shields.io/docker/cloud/automated/mahdit/pokespeare)](https://hub.docker.com/r/mahdit/pokespeare/builds)
[![Docker Cloud Build Status](https://img.shields.io/docker/cloud/build/mahdit/pokespeare)](https://hub.docker.com/r/mahdit/pokespeare/builds)

This is a simple REST API written in .NET 5 / ASP.NET WebAPI. It translates a Pokemon description (by getting its name) into its Shakespearean description! 

## Build
You need to have Docker installed on your machine to build and run the container.

Build the image first:
```docker
docker build -t pokespeare .
```

## Run
And, run it:
```docker
docker run --rm -p 5000:80 --name pokespeare pokespeare
```

Now the application is running at `http://localhost:5000`; to call the API method send a `GET` request to `http://localhost:5000/pokemon/charizard`

## API Documentation
Swagger API docs are available at `https://localhost:5001/swagger` if you run the app without docker over HTTPS (`docker run`); I skipped explanations for HTTPs over docker as it's different on Windows and Linux and depends on various factors that are out of scope of purpose of this challenge.

## Tests
Unit tests are available under `tests\Pokespeare.Api.Tests`; to run the tests using .NET CLI:
```
dotnet restore
dotnet build
dotnet test
```

## Known Issues
<!-- issueTable -->

<!-- issueTable -->

- [X] Automatic image builds in Docker Hub is not working
- [ ] Automatic "Open Issues" listing here is not working in GitHub Actions.
- [X] CodeQL code analysis is not working in GitHub Actions.
- [ ] HTTPS over Docker.
