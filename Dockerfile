#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

ARG BUILDCONFIG=RELEASE
ARG VERSION=1.0.0

COPY UWM/UWM.csproj /build/UWM/
COPY UWM.BLL/UWM.BLL.csproj /build/UWM.BLL/
COPY UWM.DAL/UWM.DAL.csproj /build/UWM.DAL/
COPY UWM.Domain/UWM.Domain.csproj /build/UWM.Domain/

RUN dotnet restore ./build/UWM/UWM.csproj

COPY . ./build/
WORKDIR /build/
RUN dotnet publish ./UWM/UWM.csproj -c $BUILDCONFIG -o out /p:Version=$VERSION

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
EXPOSE 80

COPY --from=build /build/out .

ENTRYPOINT ["dotnet", "UWM.dll"]