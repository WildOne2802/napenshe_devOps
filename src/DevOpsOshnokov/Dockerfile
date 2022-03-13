FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DevOpsOshnokov/DevOpsOshnokov.csproj", "DevOpsOshnokov/"]
RUN dotnet restore "DevOpsOshnokov/DevOpsOshnokov.csproj"
COPY . .
WORKDIR "/src/DevOpsOshnokov"
RUN dotnet build "DevOpsOshnokov.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DevOpsOshnokov.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevOpsOshnokov.dll"]
