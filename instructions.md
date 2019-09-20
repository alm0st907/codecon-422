# CODECON Installation Guide

There are three parts to the CODECON application to install

1. SQLExpress 2017 Database
2. NodeJS/NPM for the React frontend
3. .NET Core 2.1 for the API interface

## SQLExpress Install

For setting up the SQLExpress database, follow [Microsoft's installation guide](https://www.microsoft.com/en-us/sql-server/sql-server-editions-express).

Once you have created a blank database, run the BuildCodeconWithSampleData.sql to initialize the database. If this data is not desired, simply clear it from the tables. The only important remainder is the schema itself.

The database can also be run on Linux, and is guided int he README at the root of the CODECON Folder.

## API Installation

The project in the API folder can be compiled in Visual Studio 2017 or higher using the .NET Core 2.1 runtime. Run the dll in powershell using ```dotnet api.dll```

## NodeJS installation

[Download NodeJS for your respective system.](https://nodejs.org/en/). Within the CODECON folder run ```npm install``` and then ```npm start``` will start the frontend of the application on localhost. Should the necessary dependencies not get installed, try running install.sh  


## Potential Issues
The ports on localhost that the frontend and backend may vary from system to system, as well as the connection string for the database. Ensure these values are set properly within the code or the software will not function as intended. Many systems are running as "MVP" and may not reflect full fledged features intended for further releases

