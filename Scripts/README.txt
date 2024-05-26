instale o postgres 10.3, no pgadmin 4 sua senha deve ser ?v4quej4d4? usuario postgres
sua porta de instalação deve ser 5433

crie um banco chamado AgendaDoBarbeiro, rode o script nele

caso modifique algo no script inicial do banco, ou nos subsequentes rode o scaffold novamente com o comando

dotnet ef dbcontext scaffold "Host=localhost;Port=5433;Database=AgendaDoBarbeiro;Username=postgres;Password=?v4quej4d4?" Npgsql.EntityFrameworkCore.PostgreSQL --project AgendaDoBarbeiro.Core -f
