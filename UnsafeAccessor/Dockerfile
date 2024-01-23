FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["UnsafeAccessor/UnsafeAccessor.csproj", "UnsafeAccessor/"]
RUN dotnet restore "UnsafeAccessor/UnsafeAccessor.csproj"
COPY . .
WORKDIR "/src/UnsafeAccessor"
RUN dotnet build "UnsafeAccessor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UnsafeAccessor.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UnsafeAccessor.dll"]
