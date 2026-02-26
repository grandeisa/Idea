FROM dhi.io/dotnet:10-sdk@sha256:7048c94e4fd2705dfca1c3bfe2b5e11af340fc06c41d43726f780f4a3d6a7f58 AS base

FROM dhi.io/dotnet:10-sdk@sha256:7048c94e4fd2705dfca1c3bfe2b5e11af340fc06c41d43726f780f4a3d6a7f58 AS build
WORKDIR /src

COPY Idea/*.csproj ./Idea/
COPY Idea.Server/*.csproj ./Idea.Server/
COPY Idea.Tests/*.csproj ./Idea.Tests/

RUN dotnet restore Idea.Tests/Idea.Tests.csproj

RUN dotnet publish -o /build

FROM base AS final
COPY --from=build /build .
ENTRYPOINT [ "dotnet", "test", "Idea.Tests,dll" ]