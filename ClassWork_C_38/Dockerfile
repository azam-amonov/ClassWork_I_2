FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ClassWork_C_38/ClassWork_C_38.csproj", "ClassWork_C_38/"]
RUN dotnet restore "ClassWork_C_38/ClassWork_C_38.csproj"
COPY . .
WORKDIR "/src/ClassWork_C_38"
RUN dotnet build "ClassWork_C_38.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClassWork_C_38.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClassWork_C_38.dll"]
