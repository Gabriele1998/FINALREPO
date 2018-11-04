# CodeSchool
this repository is for learning to use dotnet core 
Aggiunta 1
```
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
```
Aggiunta 2
```
<ItemGroup>
  <ProjectReference Include="app.csproj" />
  <ProjectReference Include="..\lib2\lib2.csproj" />
  <ProjectReference Include="..\lib1\lib1.csproj" />
</ItemGroup>
```
Aggiunta 3 Occhio Assembly
```
services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    var connection = "Data Source=anagrafica.db";
    services.AddDbContext<AnagraficaContext>
        (options => options.UseSqlite(connection, b => b.MigrationsAssembly("AspNetMvc")));
```
Aggiunta 4
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```
Aggiunta 5
```
dotnet tool install -g dotnet-aspnet-codegenerator
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet restore
dotnet aspnet-codegenerator controller -name <TuoController>Controller -m Blog -dc <TuoContext>Context --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
```