# Etapa 1: Build y Publish
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Copiar el archivo del proyecto y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto del repositorio y publicar la aplicación
COPY . ./
RUN dotnet publish -c Release -o /app/out

# Etapa 2: Imagen final para producción
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Copiar los archivos publicados de la etapa de build
COPY --from=build /app/out .

# Configurar el puerto de entrada estándar y la DLL
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "EjercicioMVCAndrade.dll"]
