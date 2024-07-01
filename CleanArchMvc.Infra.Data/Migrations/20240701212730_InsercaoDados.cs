using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InsercaoDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    INSERT INTO Club (Id, FullName, ShortName, YearFounded, Stadium) VALUES
                    (1, 'Inter Miami', 'IMCF', 2018, 'DRV PNK Stadium'),
                    (2, 'Al Nassr', 'ALN', 1955, 'Mrsool Park'),
                    (3, 'Al-Hilal Saudi Football Club', 'Al Hilal SFC', 1957, 'Kingdom Arena'),
                    (4, 'Manchester City', 'MCFC', 1880, 'Etihad Stadium'),
                    (5, 'Liverpool', 'LFC', 1892, 'Anfield'),
                    (6, 'Barcelona', 'FCB', 1899, 'Camp Nou'),
                    (7, 'Sevilla', 'SFC', 1890, 'Ramon Sanchez-Pizjuan Stadium'),
                    (8, 'Real Madrid', 'RMCF', 1902, 'Santiago Bernabeu'),
                    (9, 'Bayern Munich', 'FCB', 1900, 'Allianz Arena');");

            migrationBuilder.Sql(@"
                    INSERT INTO Player (Id, FullName, Height, Position, DateBirth, ClubId) VALUES
                    (1, 'Lionel Messi', 1.70, 'Atacante', '1987-06-24', 1),
                    (2, 'Cristiano Ronaldo', 1.87, 'Atacante', '1985-02-05', 2),
                    (3, 'Neymar Jr.', 1.75, 'Atacante', '1992-02-05', 3),
                    (4, 'Kylian Mbappé', 1.78, 'Atacante', '1998-12-20', 8),
                    (5, 'Kevin De Bruyne', 1.81, 'Meio-campista', '1991-06-28', 4),
                    (6, 'Virgil van Dijk', 1.93, 'Defensor', '1991-07-08', 5),
                    (7, 'Robert Lewandowski', 1.85, 'Atacante', '1988-08-21', 6),
                    (8, 'Sergio Ramos', 1.84, 'Defensor', '1986-03-30', 7),
                    (9, 'Luka Modrić', 1.72, 'Meio-campista', '1985-09-09', 8),
                    (10, 'Manuel Neuer', 1.93, 'Goleiro', '1986-03-27', 9);");

            migrationBuilder.Sql(@"
                    INSERT INTO Trophy (Id, Competition, Year, ClubId) VALUES
                    (1, 'MLS Cup', 2023, 1), -- Inter Miami
                    (2, 'Saudi Pro League', 2023, 2), -- Al Nassr
                    (3, 'Ligue 1', 2023, 3), -- Paris Saint-Germain
                    (4, 'Premier League', 2023, 4), -- Manchester City
                    (5, 'Champions League', 2019, 5), -- Liverpool
                    (6, 'La Liga', 2023, 6), -- Barcelona
                    (7, 'Europa League', 2020, 7), -- Sevilla
                    (8, 'La Liga', 2022, 8), -- Real Madrid
                    (9, 'Bundesliga', 2023, 9), -- Bayern Munich
                    (10, 'DFB-Pokal', 2022, 9); -- Bayern Munich);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                    @"DELETE FROM Player;
                    DELETE FROM Trophy;
                    DELETE FROM Club;");
        }
    }
}
