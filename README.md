# RoomEnglish


## Development 

You need set your sensive variables with use-secrets.

### Create Docker SqlServer

Open terminal, edit MSSQL_SA_PASSWORD=<password> for you password.

`docker run -v ~/docker --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<password>" -p 1433:1433 -d mcr.microsoft.com/mssql/server`

> [!IMPORTANT] 
> If you are going to use https make sure to create the keys

`dotnet dev-certs https --clean
dotnet dev-certs https --trust`

ConnectionString  (Remember to change the password to the <password> you entered when creating docker)

`Server=localhost,1433;Database=balta;User ID=sa;Password=<password>;Trusted_Connection=False; TrustServerCertificate=True;`

### Database Connection String

You need set this variable in the API project.

`dotnet user-secrets set "ConnectionStrings:DefaultConnection" "your sql server connection string"`

### Migrations

> [!IMPORTANT]  
> All Migrations need to be created in the Migrations folder in the Data folder

For Example:
`dotnet ef migrations add PlayerContext --startup-project .\src\RoomsEnglish.Api\ --project .\src\RoomsEnglish.Infraestructure\ -o "Data/Migrations"`


