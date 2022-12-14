#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
RUN ls
# Restore as distinct layers
RUN dotnet restore "Presentation/Presentation.WebApi/Presentation.WebApi.csproj"
WORKDIR "/src/Presentation/Presentation.WebApi"
# Build and publish a release
RUN dotnet publish -c Release -o out
# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "Presentation.WebApi.dll"]

#FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443

#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /src
#COPY ["Presentation/Presentation.WebApi/Presentation.WebApi.csproj", "Presentation/Presentation.WebApi/"]
#RUN dotnet restore "Presentation/Presentation.WebApi/Presentation.WebApi.csproj"
#COPY . .
#WORKDIR "/src/Presentation/Presentation.WebApi"
#RUN dotnet build "Presentation.WebApi.csproj" -c Release -o /app/build

#FROM build AS publish
#RUN dotnet publish "Presentation.WebApi.csproj" -c Release -o /app/publish

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Presentation.WebApi.dll"]
