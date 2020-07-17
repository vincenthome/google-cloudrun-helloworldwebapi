FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
WORKDIR /src
COPY ["helloworld.csproj", "./"]
RUN dotnet restore "./helloworld.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "helloworld.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "helloworld.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV PORT=8080
ENV TARGET=Test123
ENTRYPOINT ["dotnet", "helloworld.dll"]
