using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;

namespace CarRental.DL
{
	public class DBHelper
	{
		private string _connection;

		public string Connection
		{
			get { return _connection; }
			set { _connection = value; }
		}

		private string _sqlquery;

		public string SQLQuery
		{
			get { return _sqlquery; }
			set { _sqlquery = value; }
		}

		public object Getsinglevalue()
		{
			object output = null;
			using (SqlConnection sqlConnection = new SqlConnection(Connection))
			{
				try
				{
					sqlConnection.Open();
					using (SqlCommand sqlCommand = new SqlCommand())
					{
						sqlCommand.Connection = sqlConnection;
						sqlCommand.CommandText = SQLQuery;
						output = sqlCommand.ExecuteScalar();

					}
				}
				catch (Exception ex)
				{

				}
				finally
				{
					sqlConnection.Close();
				}
			}

			return output;
		}

		public object Insertvalue()
		{
			object output = null;
            using (SqlConnection sqlConnection = new SqlConnection(Connection))
            {
                try
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandText = SQLQuery;
                        output = sqlCommand.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
					output = null;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }

            return output;

        }
	}
}

