FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY MedicalApi/*.csproj ./MedicalApi/
RUN dotnet restore

# copy everything else and build app
COPY MedicalApi/. ./MedicalApi/
WORKDIR /app/MedicalApi
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/MedicalApi/out ./

CMD ASPNETCORE_URLS=http://*:$PORT dotnet MedicalApi.dll