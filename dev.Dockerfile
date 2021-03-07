# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY KaerligHilsen.Api/*.csproj ./KaerligHilsen.Api/
RUN dotnet restore -r linux-musl-x64

CMD dotnet watch run --project KaerligHilsen.Api/ --launch-profile KaerligHilsen.Api.Docker

