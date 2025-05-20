# challenge-softtek
EFCore commands
dotnet ef migrations remove --project Softtek.Data --startup-project Softtek.WebApi

dotnet ef migrations add SeedAvaliacaoData --project Softtek.Data --startup-project Softtek.WebApi

dotnet ef database update --project Softtek.Data --startup-project Softtek.WebApi

sqlite3 SofttekData.db
.tables
SELECT * FROM Avaliacoes;
