FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["ApiBuenoPay/ApiBuenoPay.csproj", "ApiBuenoPay/"]
RUN dotnet restore "ApiBuenoPay/ApiBuenoPay.csproj"
COPY . .
WORKDIR "/src/ApiBuenoPay"
RUN dotnet build "ApiBuenoPay.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ApiBuenoPay.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ApiBuenoPay.dll"]