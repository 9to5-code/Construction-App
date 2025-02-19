
# ProductService/Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5079 5078

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SignUpApp/SignUpApp.csproj", "SignUpApp/"]
RUN dotnet restore "SignUpApp/SignUpApp.csproj"
COPY . .
WORKDIR "/src/SignUpApp"
RUN dotnet build "SignUpApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SignUpApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SignUpApp.dll"]
 