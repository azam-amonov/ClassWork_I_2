FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ClassWork_41/ClassWork_41.csproj", "ClassWork_41/"]
RUN dotnet restore "ClassWork_41/ClassWork_41.csproj"
COPY . .
WORKDIR "/src/ClassWork_41"
RUN dotnet build "ClassWork_41.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClassWork_41.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClassWork_41.dll"]
