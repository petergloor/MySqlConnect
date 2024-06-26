# MySqlConnect - a simple MySql connect example for OpenSimulator

The purpose of this program is to provide a simple console application program to test MySql connections for OpenSimulator on various platforms. It should provide an easier way to isolate and locate MySql Connection issues.

The application connects to the OpenSim database on MySql or MariaDB Server. It reads the data from the UserAccounts table and returns the PrincipalId, FirstName and LastName for output to the console.

Note: MySql.Data has been replaced by [MySqlConnector](https://github.com/mysql-net/MySqlConnector)

### Connection String
The connection string must be specified in MySqlConnect.ini in exactly the same way as in OpenSimulator.

### Dependencies:

Unlike OpenSimulator, we use Nuget packages. The following packages have been added using `dotnet add package`.

    dotnet add package MySqlConnector 
    dotnet add package nini-core --version 0.9.2.16

    
