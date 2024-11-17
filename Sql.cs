using System.Data;
using System.Data.SqlClient;

namespace StudentsService
{
    internal class Sql
    {
        private const string connectionString = $"server=DESKTOP-JR023V5\\SQLEXPRESS;database=StudentService;trusted_connection=true;integrated security=true;";
        private static SqlConnection connection = new SqlConnection(connectionString);

        public void Execute(string sql)
        {
            try
            {

                Sql.connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                int result = command.ExecuteNonQuery();
                //Console.WriteLine(result);
                connection.Close();
            }
            catch
            {
                throw new Exception("Razval sssr");

            }
            finally
            {
                connection.Close();
            }
        }
        public DataTable ExecuteQuery(string query)
        {
            DataTable table = new DataTable();

            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(table);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return table;
        }


    }
}
