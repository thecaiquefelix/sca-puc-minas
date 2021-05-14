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

                        var time = DateTime.Now.TimeOfDay;

                        var deslocamentoItaipu = random.Next(-10, 10);
                        var piezometriaItaipu = random.Next(-10, 10);
                        var inclinometroItaipu = random.Next(-10, 10);
                        var aguaItaipu = random.Next(-10, 10);

                        var deslocamentoMascarenhas = random.Next(-10, 10);
                        var piezometriaMascarenhas = random.Next(-10, 10);
                        var inclinometroMascarenhas = random.Next(-10, 10);
                        var aguaMascarenhas = random.Next(-10, 10);

                        var deslocamentoSobradinho = random.Next(-10, 10);
                        var piezometriaSobradinho = random.Next(-10, 10);
                        var inclinometroSobradinho = random.Next(-10, 10);
                        var aguaSobradinho = random.Next(-10, 10);

                        var sql = $"INSERT [DatabaseSCA].[dbo].[Sensors]" +
                                        $" ([DamId] " +
                                        $",[MetricId] " +
                                        $",[Time] " +
                                        $",[Value]) " +
                                        $" VALUES  " +
                                        $" (1 " +
                                        $" , 1 " +
                                        $" , '{time}' " +
                                        $" , {deslocamentoItaipu}); " +
                                   $"INSERT [DatabaseSCA].[dbo].[Sensors]" +
                                        $" ([DamId] " +
                                        $",[MetricId] " +
                                        $",[Time] " +
                                        $",[Value]) " +
                                        $" VALUES  " +
                                        $" (1 " +
                                        $" , 2 " +
                                        $" , '{time}' " +
                                        $" , {piezometriaItaipu}); " +
                                   $"INSERT [DatabaseSCA].[dbo].[Sensors]" +
                                        $" ([DamId] " +
                                        $",[MetricId] " +
                                        $",[Time] " +
                                        $",[Value]) " +
                                        $" VALUES  " +
                                        $" (1 " +
                                        $" , 3 " +
                                        $" , '{time}' " +
                                        $" , {inclinometroItaipu}); " +
                                    $"INSERT [DatabaseSCA].[dbo].[Sensors]" +
                                        $" ([DamId] " +
                                        $",[MetricId] " +
                                        $",[Time] " +
                                        $",[Value]) " +
                                        $" VALUES  " +
                                        $" (1 " +
                                        $" , 4 " +
                                        $" , '{time}' " +
                                        $" , {aguaItaipu}); " +
                                    $"INSERT [DatabaseSCA].[dbo].[Sensors]" +
                                        $" ([DamId] " +
                                        $",[MetricId] " +
                                        $",[Time] " +
                                        $",[Value]) " +
                                        $" VALUES  " +
                                        $" (2 " +
                                        $" , 1 " +
                                        $" , '{time}' " +
                                        $" , {deslocamentoMascarenhas}); " +
                                   $"INSERT [DatabaseSCA].[dbo].[Sensors]" +
                                        $" ([DamId] " +
                                        $",[MetricId] " +
                                        $",[Time] " +
                                        $",[Value]) " +
                                        $" VALUES  " +
                                        $" (2 " +
                                        $" , 2 " +
                                        $" , '{time}' " +
                                        $" , {piezometriaMascarenhas}); " +
                                   $"INSERT [DatabaseSCA].[dbo].[Sensors]" +
                                        $" ([DamId] " +
                                        $",[MetricId] " +
                                        $",[Time] " +
                                        $",[Value]) " +
                                        $" VALUES  " +
                                        $" (2 " +
                                        $" , 3 " +
                                        $" , '{time}' " +
                                        $" , {inclinometroMascarenhas}); " +
                                    $"INSERT [DatabaseSCA].[dbo].[Sensors]" +
                                        $" ([DamId] " +
                                        $",[MetricId] " +
                                        $",[Time] " +
                                        $",[Value]) " +
                                        $" VALUES  " +
                                        $" (2 " +
                                        $" , 4 " +
                                        $" , '{time}' " +
                                        $" , {aguaMascarenhas}); " +
                                    $"INSERT [DatabaseSCA].[dbo].[Sensors]" +
                                        $" ([DamId] " +
                                        $",[MetricId] " +
                                        $",[Time] " +
                                        $",[Value]) " +
                                        $" VALUES  " +
                                        $" (3 " +
                                        $" , 1 " +
                                        $" , '{time}' " +
                                        $" , {deslocamentoSobradinho}); " +
                                   $"INSERT [DatabaseSCA].[dbo].[Sensors]" +
                                        $" ([DamId] " +
                                        $",[MetricId] " +
                                        $",[Time] " +
                                        $",[Value]) " +
                                        $" VALUES  " +
                                        $" (3 " +
                                        $" , 2 " +
                                        $" , '{time}' " +
                                        $" , {piezometriaSobradinho}); " +
                                   $"INSERT [DatabaseSCA].[dbo].[Sensors]" +
                                        $" ([DamId] " +
                                        $",[MetricId] " +
                                        $",[Time] " +
                                        $",[Value]) " +
                                        $" VALUES  " +
                                        $" (3 " +
                                        $" , 3 " +
                                        $" , '{time}' " +
                                        $" , {inclinometroSobradinho}); " +
                                    $"INSERT [DatabaseSCA].[dbo].[Sensors]" +
                                        $" ([DamId] " +
                                        $",[MetricId] " +
                                        $",[Time] " +
                                        $",[Value]) " +
                                        $" VALUES  " +
                                        $" (3 " +
                                        $" , 4 " +
                                        $" , '{time}' " +
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
