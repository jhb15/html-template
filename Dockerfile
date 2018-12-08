FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /app

COPY . ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.1.6-aspnetcore-runtime
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS=https://+:443;http://+:80;
WORKDIR /app
COPY --from=build-env /app/AberFitnessLayout/out ./AberFitnessLayout
COPY --from=build-env /app/LayoutService/out ./LayoutService
ENTRYPOINT ["dotnet", "LayoutService/LayoutService.dll"]