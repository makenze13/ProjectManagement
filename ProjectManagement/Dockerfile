# Этап 1. Сборка приложения
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

# Копируем файл проекта и восстанавливаем NuGet-зависимости
COPY ["ProjectManagement/ProjectManagement.csproj", "ProjectManagement/"]
RUN dotnet restore "ProjectManagement/ProjectManagement.csproj"

# Копируем исходный код и собираем приложение
COPY . .
WORKDIR /src/ProjectManagement
RUN dotnet publish "ProjectManagement.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Этап 2. Запуск приложения
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "ProjectManagement.dll"]
