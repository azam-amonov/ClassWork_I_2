FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ClassWork_43/ClassWork_43.csproj", "ClassWork_43/"]
RUN dotnet restore "ClassWork_43/ClassWork_43.csproj"
COPY . .
WORKDIR "/src/ClassWork_43"
RUN dotnet build "ClassWork_43.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClassWork_43.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClassWork_43.dll"]
