FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY CicekSepetiCaseStudy.Api/*.csproj ./CicekSepetiCaseStudy.Api/
COPY CicekSepetiCaseStudy.Core/*.csproj ./CicekSepetiCaseStudy.Core/
COPY CicekSepetiCaseStudy.Data/*.csproj ./CicekSepetiCaseStudy.Data/
RUN dotnet restore

# copy everything else and build app
COPY CicekSepetiCaseStudy.Api/. ./CicekSepetiCaseStudy.Api/
COPY CicekSepetiCaseStudy.Core/. ./CicekSepetiCaseStudy.Core/
COPY CicekSepetiCaseStudy.Data/. ./CicekSepetiCaseStudy.Data/

WORKDIR /app/CicekSepetiCaseStudy
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/CicekSepetiCaseStudy/out ./

CMD ASPNETCORE_URLS=http://*:$PORT dotnet CicekSepetiCaseStudy.dll