# Order Processor

## Overview

The **Order Processor** application is designed to read order data from text files, parse them into order objects, and save the processed orders in JSON format.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- A text editor or IDE (e.g., [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/))

## Setup

### Clone the Repository

Clone this repository to your local machine:

```bash
git clone https://github.com/louis122333/OrderProcessor.git
cd OrderProcessor
```
## Example Data

To run this application, you'll need example data files. Download the following files and place them in a local folder (e.g OrderData) on your PC:

- [2019-01-03 Example Data](https://github.com/MaksimerAB/PosIntegrationAssessment/blob/main/POS%20files/20190103.txt)
- [2021-08-06 Example Data](https://github.com/MaksimerAB/PosIntegrationAssessment/blob/main/POS%20files/20210806.txt)
- [2021-11-19 Example Data](https://github.com/MaksimerAB/PosIntegrationAssessment/blob/main/POS%20files/20211119.txt)

Place these files in the `InputFolder` specified in your `appsettings.json` file.
```
{
  "FilePaths": {
    "InputFolder": "C:/PosData/Orders_Text/", // update to your desired path
    "OutputFolder": "C:/PosData/Orders_Json/" // update to your desired path, default json folder will be generated.
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning"
    }
  }
}
```
## Build the application
dotnet build

## Run the application
dotnet run

## Documentation

For detailed information on the `Order` model, including its properties and their descriptions, please refer to the following documentation:
[Order.md](https://github.com/Louis122333/OrderProcessor/blob/master/Order.md)
