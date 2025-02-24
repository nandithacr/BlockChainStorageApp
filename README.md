# BlockChainStorageApp

A .NET 6 Web API app that integrates with **BlockCypher APIs** to store and retrieve cryptocurrency blockchain data. Includes **unit, integration, and functional tests**.

## Features
- Fetch and store blockchain data from BlockCypher (ETH, BTC, LTC, DASH).
- Retrieve historical data with timestamps.
- Full test coverage (unit, integration, and functional).
- Uses **SQLite** for lightweight storage.
- Follows **Clean Architecture** and **SOLID** principles.

## Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQLite](https://www.sqlite.org/download.html)
- [Git](https://git-scm.com/)

## API Endpoints

| **Method** | **Endpoint** | **Description** |
|-----------|-------------|----------------|
| `POST` | `/api/crypto/sync` | Fetches and stores the latest blockchain data from BlockCypher API. |
| `GET` | `/api/crypto/all` | Retrieves all stored cryptocurrency blockchain data. |
| `GET` | `/api/crypto/history/{symbol}` | Fetches the historical blockchain data for a given cryptocurrency (BTC, ETH, LTC, DASH). |
| `GET` | `/health` | Returns API health status. |
