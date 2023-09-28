FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ClassWork_42/ClassWork_42.csproj", "ClassWork_42/"]
RUN dotnet restore "ClassWork_42/ClassWork_42.csproj"
COPY . .
WORKDIR "/src/ClassWork_42"
RUN dotnet build "ClassWork_42.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClassWork_42.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClassWork_42.dll"]
