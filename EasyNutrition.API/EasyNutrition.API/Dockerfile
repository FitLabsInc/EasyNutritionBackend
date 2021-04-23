#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
#WORKDIR /src
#COPY ["EasyNutrition.API/EasyNutrition.API.csproj", "EasyNutrition.API/"]
#RUN dotnet restore "EasyNutrition.API/EasyNutrition.API.csproj"
#COPY . .
#WORKDIR "/src/EasyNutrition.API"
#RUN dotnet build "EasyNutrition.API.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "EasyNutrition.API.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "EasyNutrition.API.dll"]


FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /app
COPY ./ ./

RUN dotnet publish "EasyNutrition.API.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim
WORKDIR /app
COPY --from=build /app/out .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet EasyNutrition.API.dll