using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SuplerLibrary.ConsoleApp
{
    class Program
    {
        //Server =ServerName;Database= DatabaseName;Username= username;Password = password;
        static string connectionString = "Server=localhost;Database=superlibrary;Uid=root;Pwd=mypassword;";
        static MySqlConnection connection = new MySqlConnection(connectionString);
        static void Main(string[] args)
        {

            try
            {

                Console.WriteLine("Welcome to our superlibrary program ");

                string showTablesQuery = "SHOW TABLES;";

                MySqlCommand mySqlCommand = new MySqlCommand(showTablesQuery, connection);

                connection.Open();
                Console.WriteLine("Tables in the database : ");
                using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write(reader[i] + "\t");
                            }
                            Console.WriteLine();
                        }
                    }

                }
                Console.Write("Enter table Name to select its data : ");
                string tableToSelectFrom = Console.ReadLine();


                Console.WriteLine($"Reading data from Table {tableToSelectFrom}");
                string selectQuery = $"SELECT * FROM {tableToSelectFrom}";
                mySqlCommand.CommandText = selectQuery;

                using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader.GetName(i) + "\t");
                        }
                        Console.WriteLine();
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write(reader[i] + "\t");
                            }
                            Console.WriteLine();
                        }
                    }
                }

                Console.Write("Enter table Name to insert in : ");
                string tableToInsert = Console.ReadLine();
                string showColumnsQuery = $"SHOW COLUMNS FROM {tableToInsert}";
                mySqlCommand.CommandText = showColumnsQuery;
                string insertQuery = $"INSERT INTO {tableToInsert} (";
                string insertValues = "";
                using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (reader[0].ToString() == "Id")
                                continue;

                            insertQuery = string.Concat(insertQuery, reader[0], ',');

                            Console.Write($"{reader[0]} : ");

                            string input = Console.ReadLine();
                            if (int.TryParse(input, out int result))
                            {
                                insertValues = string.Concat(insertValues, input, ',');
                            }
                            else
                            {
                                insertValues = string.Concat(insertValues, '\"', input.Trim(), '\"', ',');

                            }


                            Console.WriteLine();
                        }




                    }
                }

                insertQuery = insertQuery.Remove(insertQuery.Count() - 1);
                insertValues = insertValues.Remove(insertValues.Count() - 1);
                insertQuery = string.Concat(insertQuery, ')', " VALUES ", '(', insertValues, ");");


                mySqlCommand.CommandText = insertQuery;
                Console.WriteLine(insertQuery);

                int rowsAffected = mySqlCommand.ExecuteNonQuery();

                Console.Write("Enter table Name to select its data : ");
                tableToSelectFrom = Console.ReadLine();

                PrintDataInTable(tableToSelectFrom);

                Console.Write("Enter table name to delete from : ");
                string tableToDeletFrom = Console.ReadLine();

                Console.WriteLine($"Delete data from tabel {tableToDeletFrom}:");
                PrintDataInTable(tableToDeletFrom);


                Console.Write("Enter row id to delete : ");
                int rowId = Convert.ToInt32(Console.ReadLine());

                string deleteQuery = $"DELETE FROM {tableToDeletFrom} WHERE Id = {rowId};";
                mySqlCommand.CommandText = deleteQuery;

                rowsAffected = mySqlCommand.ExecuteNonQuery();

                Console.WriteLine("Table after delete : ");
                PrintDataInTable(tableToDeletFrom);


                Console.Write("Enter table name to update in");
                string tableToUpdateIn = Console.ReadLine();

                PrintDataInTable(tableToUpdateIn);

                Console.Write("Enter record id to update : ");
                int rowUpdateId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter column name to update : ");
                string updateColumnName = Console.ReadLine();

                Console.Write("Enter new value : ");
                string newColumnValue = Console.ReadLine();

                string updateQuery = $"UPDATE {tableToUpdateIn} SET {updateColumnName} = \"{newColumnValue}\" " +
                    $"WHERE Id = {rowUpdateId};";

                mySqlCommand.CommandText = updateQuery;

                mySqlCommand.ExecuteNonQuery();

                PrintDataInTable(tableToUpdateIn);


                connection.Close();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                Debugger.Break();
            }

            Console.ReadLine();
        }

        static void PrintDataInTable(string tableName)
        {
            Console.WriteLine($"Reading data from Table {tableName}");
            var selectQuery = $"SELECT * FROM {tableName}";
            MySqlCommand mySqlCommand = new MySqlCommand(selectQuery, connection);

            using (MySqlDataReader reader = mySqlCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write(reader.GetName(i) + "\t");
                    }
                    Console.WriteLine();
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader[i] + "\t");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
