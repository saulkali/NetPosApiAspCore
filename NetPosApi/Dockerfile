# See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PyPosApi/PyPosApi.csproj", "PyPosApi/"]
RUN dotnet restore "PyPosApi/PyPosApi.csproj"
COPY . .
WORKDIR "/src/PyPosApi"
RUN dotnet build "PyPosApi.csproj" -c Release -o /app/build

# Agregar comando para generar certificado HTTPS
RUN dotnet dev-certs https --trust


FROM build AS publish
RUN dotnet publish "PyPosApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PyPosApi.dll"]