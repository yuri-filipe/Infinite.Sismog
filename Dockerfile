FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
ENV TZ=America/Sao_Paulo
ENV LANG pt_BR.UTF-8
ENV LANGUAGE ${LANG}
ENV LC_ALL ${LANG}
ENV ASPNETCORE_URLS=http://+:5000
# ENV ASPNETCORE_URLS=https://+:443
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Sismog.csproj", "./"]
RUN dotnet restore "Sismog.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Sismog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sismog.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .  
ENTRYPOINT ["dotnet", "Sismog.dll"]
