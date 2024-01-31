# RoomEnglish


## Development 

You need set your sensive variables with use-secrets.


### Database Connection String

You need set this variable in the API project.

`dotnet user-secrets set "ConnectionStrings:DefaultConnection" "your sql server connection string"`

### Migrations

> [!IMPORTANT]  
> All Migrations need to be created in the Migrations folder in the Data folder

For Example:
`dotnet ef migrations add PlayerContext --startup-project .\src\RoomsEnglish.Api\ --project .\src\RoomsEnglish.Infraestructure\ -o "Data/Migrations"`
