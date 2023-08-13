using Microsoft.Data.SqlClient;

// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


namespace sqltest
{
    class Program
    {
        static void Main(string[] args)
        {
            try 
            { 
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "sql-db-la-acr-wus.database.windows.net"; 
                builder.UserID = "Username";            
                builder.Password = "c6tWnB#0oReNd0A4aW5u";     
                builder.InitialCatalog = "db-name";
         
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    // Console.WriteLine("\nQuery data example:");
                    // Console.WriteLine("=========================================\n");
                    
                    connection.Open();       

                    // QUERY
                    // String sql = "SELECT name, collation_name FROM sys.databases";

                    // String sql = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Movie'";
                    // String sql = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'Movie';"; Not working
                    // String sql = "SELECT title, releasedate FROM [dbo].[Movie];";
                    // String sql = "SELECT name FROM sys.tables;";
                    String sql = "SELECT * FROM [dbo].[Movie];";
                    // String sql = "SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'Movie'";


                    // INSERT
                    // String sql = "INSERT INTO [dbo].[Movie] (ReleaseDate, Price, Genre, Rating, Title) VALUES ('20120618 12:00:00 AM', '8.99', 'Action', '6.7', 'HIMYM');";


                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // while (reader.Read())
                            // {
                            //     Console.WriteLine(reader.FieldCount);
                            //     Console.WriteLine(reader.GetDataTypeName(0), reader.GetString(0));

                            //     // Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));

                            //     // Console.WriteLine(reader.FieldCount);
                            //     // Console.WriteLine("{0}\t\t{1}\t\t{2}", reader.GetDataTypeName(0), reader.GetFieldType(0), reader.GetString(0));
                            //     // Console.WriteLine("{0}\t\t{1}\t\t{2}", reader.GetDataTypeName(1), reader.GetFieldType(1), reader.GetString(1));
                            //     // Console.WriteLine("{0}\t\t{1}\t\t{2}", reader.GetDataTypeName(2), reader.GetFieldType(2), reader.GetString(2));
                            //     // Console.WriteLine("{0}\t\t{1}\t\t{2}", reader.GetDataTypeName(3), reader.GetFieldType(3), reader.GetString(3));
                            //     // Console.WriteLine("{0}\t\t\t{1}\t\t{2}", reader.GetDataTypeName(4), reader.GetFieldType(4), reader.GetInt32(4));
                            //     // Console.WriteLine("{0}\t\t{1}", reader.GetDataTypeName(5), reader.GetFieldType(5));
                            //     // Console.WriteLine("{0}\t\t\t{1}\t\t{2}", reader.GetDataTypeName(6), reader.GetFieldType(6), reader.GetString(6));






                            //     // Console.WriteLine("{0}\t\t{1}\t\t{2}", reader.GetDataTypeName(0), reader.GetFieldType(0), reader.GetInt32(0));
                            //     // Console.WriteLine("{0}\t{1}\t\t{2}", reader.GetDataTypeName(1), reader.GetFieldType(1), reader.GetDateTime(1));
                            //     // Console.WriteLine("{0}\t\t{1}\t\t{2}", reader.GetDataTypeName(2), reader.GetFieldType(2), reader.GetDecimal(2));
                            //     // Console.WriteLine("{0}\t\t{1}\t\t{2}", reader.GetDataTypeName(3), reader.GetFieldType(3), reader.GetString(3));
                            //     // Console.WriteLine("{0}\t\t{1}\t\t{2}", reader.GetDataTypeName(4), reader.GetFieldType(4), reader.GetString(4));
                            //     // Console.WriteLine("{0}\t\t{1}\t\t{2}", reader.GetDataTypeName(5), reader.GetFieldType(5), reader.GetString(5));



                            //     // Console.WriteLine(reader.GetDataTypeName(1));
                            //     // Console.WriteLine(reader.GetDataTypeName(2));
                            //     // Console.WriteLine(reader.GetDataTypeName(3));
                            //     // Console.WriteLine(reader.GetDataTypeName(4));
                            //     // Console.WriteLine(reader.GetDataTypeName(5));
                            //     // Console.WriteLine(reader.GetString(0));
                            //     // Console.WriteLine(reader.GetInt32(0));
                            //     // Console.WriteLine(reader.AsQueryable());
                            //     // Console.WriteLine(reader);
                            // }


                            // Customised Table
                            Console.WriteLine("\nID\t\tRelease Date\t\tPrice\t\tGenre\t\tRating\t\tTitle");
                            Console.WriteLine("================================================================================================\n");

                            while (reader.Read())
                            {
                              Console.WriteLine(
                                "{0}\t\t{1}\t{2}\t\t{3}\t\t{4}\t\t{5}",
                                reader.GetInt32(0),
                                reader.GetDateTime(1),
                                reader.GetDecimal(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetString(5)
                              );
                            }
                        }
                    }                    
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine(); 
        }
    }
}