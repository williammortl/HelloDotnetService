# [Choice] .NET version: 5.0, 3.1, 2.1
ARG VARIANT="5.0"
FROM mcr.microsoft.com/vscode/devcontainers/dotnetcore:0-${VARIANT}

EXPOSE 8080

ADD HelloDotnetService /HelloDotnetService
ADD startup.sh /startup.sh

RUN chmod +x /startup.sh

WORKDIR /HelloDotnetService
RUN dotnet build

ENTRYPOINT ["/usr/bin/bash", "/startup.sh"]