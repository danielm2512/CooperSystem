FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_ENVIRONMENT=Staging
ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CooperSystem.WebApi/CooperSystem.WebApi.csproj", "CooperSystem.WebApi/"]
RUN dotnet restore "CooperSystem.WebApi\CooperSystem.WebApi.csproj"
COPY . .
WORKDIR "/src/CooperSystem.WebApi"
RUN dotnet build "CooperSystem.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CooperSystem.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CooperSystem.WebApi.dll"]
