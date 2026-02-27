FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS base

FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build
WORKDIR /src

COPY Idea/*.csproj ./Idea/
COPY Idea.Server/*.csproj ./Idea.Server/
COPY Idea.Tests/*.csproj ./Idea.Tests/

RUN dotnet restore ./Idea.Tests/Idea.Tests.csproj
COPY . ./
WORKDIR /src/Idea.Tests

RUN dotnet build ./Idea.Tests.csproj -o /build

FROM base AS final
COPY --from=build /build .
ENTRYPOINT [ "dotnet",  "Idea.Tests.dll"]
