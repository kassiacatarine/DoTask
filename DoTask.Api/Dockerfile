FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["DoTask.Api/DoTask.Api.csproj", "DoTask.Api/"]

RUN dotnet restore "DoTask.Api/DoTask.Api.csproj"
COPY . .
WORKDIR "/src/DoTask.Api"
RUN dotnet build "DoTask.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DoTask.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DoTask.Api.dll"]