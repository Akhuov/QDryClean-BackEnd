# STAGE 1 — Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем solution и весь исходный код сразу
COPY . .

# Восстанавливаем зависимости по .sln
RUN dotnet restore

# Публикуем API проект (он подтянет все зависимости)
RUN dotnet publish QDryClean.Api/QDryClean.Api.csproj -c Release -o /app/publish

# STAGE 2 — Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Копируем только опубликованные файлы
COPY --from=build /app/publish .

# Точка входа
ENTRYPOINT ["dotnet", "QDryClean.Api.dll"]
