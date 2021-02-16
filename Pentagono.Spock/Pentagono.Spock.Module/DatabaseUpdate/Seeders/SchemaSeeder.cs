using System;

namespace Pentagono.Spock.Module.DatabaseUpdate.Seeders
{
    class SchemaSeeder : Seeder
    {
        private const string sqlTemplate = "IF NOT EXISTS ( SELECT  * FROM sys.schemas WHERE name = N'{SCHEMA_NAME}' ) " +
            "EXEC('CREATE SCHEMA [{SCHEMA_NAME}] AUTHORIZATION [dbo]');";

        public SchemaSeeder(Updater updater) : base(updater) { }

        public override void Run()
        {
            ExecuteNonQueryCommand(sqlTemplate.Replace("{SCHEMA_NAME}", Schema.SPOCK.Replace(".", string.Empty)));
        }
    }
}
