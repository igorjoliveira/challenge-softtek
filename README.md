# challenge-softtek
EFCore commands
dotnet ef migrations remove --project Softtek.Data --startup-project Softtek.WebApi

dotnet ef migrations add CriarContextoAvaliacaoPsicossocial --project Softtek.Data --startup-project Softtek.WebApi
dotnet ef migrations add CriarContextoAssistenciaEmocional --project Softtek.Data --startup-project Softtek.WebApi
dotnet ef migrations add CriarContextoMonitoramentoEmocional --project Softtek.Data --startup-project Softtek.WebApi
dotnet ef migrations add SeedAvaliacaoData --project Softtek.Data --startup-project Softtek.WebApi

dotnet ef database update --project Softtek.Data --startup-project Softtek.WebApi

cd src\backend\Softtek.Webapi
sqlite3 SofttekData.db
.tables
SELECT * FROM Avaliacoes;
