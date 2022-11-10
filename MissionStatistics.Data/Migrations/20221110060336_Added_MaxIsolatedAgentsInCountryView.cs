using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MissionStatistics.Data.Migrations
{
	public partial class Added_MaxIsolatedAgentsInCountryView : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"CREATE VIEW vMaxIsolatedAgentsInCountry
									AS
									SELECT country, MAX(isolated_agents) AS isolated_agents
									FROM
									(
										SELECT country, COUNT(*) AS isolated_agents FROM missions
										WHERE agent IN(
										SELECT agent FROM missions
										GROUP BY agent
										HAVING COUNT(*) = 1
										)
										GROUP BY country
	
									) countries_isolated_agents");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DROP VIEW vMaxIsolatedAgentsInCountry");
		}
	}
}
