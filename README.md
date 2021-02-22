# HelloDotnetService
A simple REST service for demos (written in C#). <br>
by William Mortl <br><br>
Dotnet equivalent of https://github.com/WilliamMortl/HelloGoService

## To Run

### Visual Studio Code

This solution contains a *devcontainer* that allows one to run and debug this REST service within Visual Studio Code. For a tutorial on 
devcontainers, visit [this link](https://code.visualstudio.com/docs/remote/containers-tutorial).

Simply go to the "Debug" icon (on the left) and click the "play" button (near the top).

**note:** the service may run on port 5000 in this mode

### Command Line

#### Building 

1. Clone the repository
2. In the project directory, create a Docker container: **docker build -t {image name}:{tag name} .**

#### Running the Container

From the CLI, run the container: **docker container run -p 8080:8080 -it {image name}:{tag}**

## Services Provided

### Swagger Documentation

**Swagger service**: http://localhost:8080/swagger/index.html <br><br>
**note:** again, the service may run on port 5000 in Visual Studio development-container mode