FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["WebBuenoPay/WebBuenoPay.csproj", "WebBuenoPay/"]
RUN dotnet restore "WebBuenoPay/WebBuenoPay.csproj"
COPY . .
WORKDIR "/src/WebBuenoPay"
RUN dotnet build "WebBuenoPay.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebBuenoPay.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebBuenoPay.dll"]