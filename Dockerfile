FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app


COPY *.sln ./
COPY src/NexPay.Api/*.csproj ./src/NexPay.Api/
COPY src/NexPay.Data/*.csproj ./src/NexPay.Data/
COPY src/NexPay.Domain/*.csproj ./src/NexPay.Domain/

COPY tests/NexPay.Tests/*.csproj ./tests/NexPay.Tests/

COPY . ./

FROM build AS publish
WORKDIR /app
RUN dotnet publish src/NexPay.Api -c Release -o out

FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY --from=publish /app/src/NexPay.Api/out/ .

ENTRYPOINT [ "dotnet", "NexPay.Api.dll" ]
