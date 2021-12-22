using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using System;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class SupplierDaoDb : ISupplierDao
    {
        private readonly IDbConnectionService _dbConnectionService;
        public SupplierDaoDb(IDbConnectionService dbConnectionService)
        {
            _dbConnectionService = dbConnectionService;
        }
        public void Add(Supplier item)
        {
            throw new System.NotImplementedException();
        }

        public Supplier Get(int id)
        {
            Supplier supplier = null;
            using var conn = _dbConnectionService.GetConnection();
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.Connection = conn;
                command.CommandText = $"SELECT * FROM suppliers WHERE id = {id}";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        supplier = new Supplier
                        {
                            Id = (int)reader["Id"],
                            Name = (String)reader["Name"],
                            Description = (String)reader["Description"]
                        };
                    }
                }
                return supplier;
            }
            finally
            {
                conn.Close();
            }
        }

        public IEnumerable<Supplier> GetAll()
        {
            List<Supplier> products = new List<Supplier>();
            using var conn = _dbConnectionService.GetConnection();
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM suppliers;";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Supplier
                        {
                            Id = (int)reader["Id"],
                            Name = (String)reader["Name"],
                            Description = (String)reader["Description"]
                        });
                    }
                }
                return products;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
