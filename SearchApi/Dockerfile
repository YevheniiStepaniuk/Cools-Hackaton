FROM microsoft/aspnetcore-build:2.0.0 AS build

WORKDIR /app

COPY Valeriy.sln .
COPY Valeriy.DAL/Valeriy.DAL.csproj Valeriy.DAL/
COPY Valeriy.BLL/Valeriy.BLL.csproj Valeriy.BLL/
COPY Valeriy.Domain/Valeriy.Domain.csproj Valeriy.Domain/
COPY Valeriy.Web/Valeriy.Web.csproj Valeriy.Web/
RUN dotnet restore

COPY . .

RUN dotnet publish -c Release -o out

FROM microsoft/aspnetcore:2.0.0

WORKDIR /app

COPY --from=build /app/Valeriy.Web/out .

ENTRYPOINT [ "dotnet","Valeriy.Web.dll" ]  