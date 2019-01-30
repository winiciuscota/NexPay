FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app


COPY *.sln ./
COPY src/NexPay.Api/*.csproj ./src/NexPay.Api/
COPY src/NexPay.Data/*.csproj ./src/NexPay.Data/
COPY src/NexPay.Domain/*.csproj ./src/NexPay.Domain/

COPY tests/NexPay.Tests/*.csproj ./tests/NexPay.Tests/

COPY . ./

ENTRYPOINT [ "dotnet ef database update" ]
