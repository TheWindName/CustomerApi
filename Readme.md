# CRUD Net Core 5.0
Net Core CRUD project where I'd like showing some useful tools that we be able to take to develop a new CRUD Api with:
    - Swagger
    - Entity Framework Core
    - XUnit

## Summary
Sample POC by ivanrodriguezmillan@outlook.com.


### Docker DataBase
Our project need to connect to a Data Base with SqlServer. For this reason, we will have a docker container 
with SQL Server Image such as https://hub.docker.com/_/microsoft-mssql-server.

We will need to execute some sentences on DockerFile syntax, here we have an example:
```dockerfile

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=<YourStrong@Passw0rd>" -p 1433:1433 -d mcr.microsoft.com/mssql/server:latest


docker exec -it <container_id> /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P <YourStrong@Passw0rd>

```