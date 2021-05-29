using System;
using System.Data.SqlClient;
using System.Threading;

namespace SCA.Sensors
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "localhost";
                builder.UserID = "sa";
                builder.Password = "Senha_s@";
                builder.InitialCatalog = "DatabaseSCA";

                Random random = new Random();

                while(true)
                {
                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        connection.Open();

                        var date = DateTime.Now;

                        var min = 0;
                        var max = min + 10;

                        var deslocamentoItaipu = random.Next(min, max);
                        var piezometriaItaipu = random.Next(-5, 10);
                        var inclinometroItaipu = random.Next(-10, 10);
                        var aguaItaipu = random.Next(-20, 20);

                        var deslocamentoMascarenhas = random.Next(-10, 10);
                        var piezometriaMascarenhas = random.Next(-5, 10);
                        var inclinometroMascarenhas = random.Next(-10, 10);
                        var aguaMascarenhas = random.Next(-20, 20);

                        var deslocamentoSobradinho = random.Next(-10, 10);
                        var piezometriaSobradinho = random.Next(-5, 10);
                        var inclinometroSobradinho = random.Next(-10, 10);
                        var aguaSobradinho = random.Next(-20, 20);

                        var sql = $"INSERT [DatabaseSCA].[dbo].[Sensors]" +
                                        $" ([DamId] " +
                                        $",[MetricId] " +
                                        $",[Date] " +
                                        $",[Value]) " +
                                        $" VALUES  " +
                                        $" (1 " +
                                        $" , 1 " +
                                        $" , '{date}' " +
                                        $" , {deslocamentoItaipu}); " +
                                   $"INSERT [DatabaseSCA].[dbo].[Sensors]" +
                                        $" ([DamId] " +
                                        $",[MetricId] " +
                                        $",[Date] " +
                                        $",[Value]) " +
                                        $" VALUES  " +
                                        $" (1 " +
                                        $" , 2 " +
                                        $" , '{date}' " +
                                        $" , {piezometriaItaipu}); " +
                                   $"INSERT [DatabaseSCA].[dbo].[Sensors]" +
                                        $" ([DamId] " +
                                        $",[MetricId] " +
                                        $",[Date] " +
                                        $",[Value]) " +
                                        $" VALUES  " +
                                        $" (1 " +
                                        $" , 3 " +
                                        $" , '{date}' " +
                                        $" , {inclinometroItaipu}); " +
                                    $"INSERT [DatabaseSCA].[dbo].[Sensors]" +
                                        $" ([DamId] " +
                                        $",[MetricId] " +
                                        $",[Date] " +
                                        $",[Value]) " +
                                        $" VALUES  " +
                                        $" (1 " +
                                        $" , 4 " +
                                        $" , '{date}' " +
                                        $" , {aguaItaipu}); " +
                                    $"INSERT [DatabaseSCA].[dbo].[Sensors]" +
                                        $" ([DamId] " +
                                        $",[MetricId] " +
                                        $",[Date] " +
                                        $",[Value]) " +
                                        $" VALUES  " +
                                        $" (2 " +
                                        $" , 1 " +
                                        $" , '{date}' " +
                                        $" , {deslocamentoMascarenhas}); " +
                                   $"INSERT [DatabaseSCA].[dbo].[Sensors]" +
                                        $" ([DamId] " +
                                        $",[MetricId] " +
                                        $",[Date] " +
                                        $",[Value]) " +
                                        $" VALUES  " +
                                        $" (2 " +
                                        $" , 2 " +
                                        $" , '{date}' " +
                                        $" , {piezometriaMascarenhas}); " +
                                   $"INSERT [DatabaseSCA].[dbo].[Sensors]" +
                                        $" ([DamId] " +
                                        $",[MetricId] " +
                                        $",[Date] " +
                                        $",[Value]) " +
                                        $" VALUES  " +
                                        $" (2 " +
                                        $" , 3 " +
                                        $" , '{date}' " +
                                        $" , {inclinometroMascarenhas}); " +
                                    $"INSERT [DatabaseSCA].[dbo].[Sensors]" +
                                        $" ([DamId] " +
                                        $",[MetricId] " +
                                        $",[Date] " +
                                        $",[Value]) " +
                                        $" VALUES  " +
                                        $" (2 " +
                                        $" , 4 " +
                                        $" , '{date}' " +
                                        $" , {aguaMascarenhas}); " +
                                    $"INSERT [DatabaseSCA].[dbo].[Sensors]" +
                                        $" ([DamId] " +
                                        $",[MetricId] " +
                                        $",[Date] " +
                                        $",[Value]) " +
                                        $" VALUES  " +
                                        $" (3 " +
                                        $" , 1 " +
                                        $" , '{date}' " +
                                        $" , {deslocamentoSobradinho}); " +
                                   $"INSERT [DatabaseSCA].[dbo].[Sensors]" +
                                        $" ([DamId] " +
                                        $",[MetricId] " +
                                        $",[Date] " +
                                        $",[Value]) " +
                                        $" VALUES  " +
                                        $" (3 " +
                                        $" , 2 " +
                                        $" , '{date}' " +
                                        $" , {piezometriaSobradinho}); " +
                                   $"INSERT [DatabaseSCA].[dbo].[Sensors]" +
                                        $" ([DamId] " +
                                        $",[MetricId] " +
                                        $",[Date] " +
                                        $",[Value]) " +
                                        $" VALUES  " +
                                        $" (3 " +
                                        $" , 3 " +
                                        $" , '{date}' " +
                                        $" , {inclinometroSobradinho}); " +
                                    $"INSERT [DatabaseSCA].[dbo].[Sensors]" +
                                        $" ([DamId] " +
                                        $",[MetricId] " +
                                        $",[Date] " +
                                        $",[Value]) " +
                                        $" VALUES  " +
                                        $" (3 " +
                                        $" , 4 " +
                                        $" , '{date}' " +
                                        $" , {aguaSobradinho}); ";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.ExecuteReader();
                        }

                        Thread.Sleep(1000);
                    }
                }    
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
