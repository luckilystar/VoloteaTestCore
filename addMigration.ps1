$name = read-host -Prompt "Enter Migration Name"
dotnet ef migrations add $name --project VoloteaTestCore.EF --startup-project VoloteaTestCore.WebApi