using Aula23.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Aula23.Repository
{
    public abstract class BaseRepository<T> where T : BaseModels
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\havan.HAVA\Documents\GitHub\Aula23\Aula23\Aula23\App_Data\Tenis.mdf;Integrated Security=True";

        public void Create(Tenis model)
        {
            ExecNoQuery($"INSERT INTO Tenis (Nome, Valor, Marca) VALUES ('{model.Nome}',{model.Valor.ToString(CultureInfo.InvariantCulture)},'{model.Marca}')");
        }
        public List<Tenis> Read()
        {
            List<Tenis> list = new List<Tenis>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = "SELECT Id, Nome, Valor, Marca FROM Tenis";
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Tenis model = new Tenis();
                            model.Id = Convert.ToInt32(dataReader["Id"]);
                            model.Nome = Convert.ToString(dataReader["Nome"]);
                            model.Valor = Convert.ToDecimal(dataReader["Valor"]);
                            model.Marca = Convert.ToString(dataReader["Marca"]);
                            list.Add(model);
                        }
                    }
                }
            }
            return list;
        }
        public Tenis Read(int id)
        {
            Tenis model = new Tenis();
            using (var conn = new SqlConnection())
            {
                conn.Open();
                using(var command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = $"SELECT Id, Nome, Valor, Marca FROM Tenis WHERE Id = {id}";
                    using (var dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {

                            model.Id = Convert.ToInt32(dataReader["Id"]);
                            model.Nome = Convert.ToString(dataReader["Nome"]);
                            model.Valor = Convert.ToDecimal(dataReader["Valor"]);
                            model.Marca = Convert.ToString(dataReader["Marca"]);
                        }
                    }
                }
            }
            return model;
        }
        public void Update(Tenis model)
        {
            ExecNoQuery($"UPDATE Tenis SET Nome = '{model.Nome}', Valor = '{model.Valor.ToString(CultureInfo.InvariantCulture)}', Marca = '{model.Marca}' WHERE Id = {model.Id}");
        }
        public void Delete(int id)
        {
            ExecNoQuery($"DELETE FROM Tenis WHERE Id = {id}");
        }
        private void ExecNoQuery(string comando)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = comando;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}