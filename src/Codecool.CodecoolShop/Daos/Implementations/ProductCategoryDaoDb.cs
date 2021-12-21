using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using System;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Daos.Implementations
{
    public class ProductCategoryDaoDb : IProductCategoryDao
    {
        private readonly IDbConnectionService _dbConnectionService;
        public ProductCategoryDaoDb(IDbConnectionService dbConnectionService)
        {
            _dbConnectionService = dbConnectionService;
        }
        public void Add(ProductCategory item)
        {
            throw new System.NotImplementedException();
        }

        public ProductCategory Get(int id)
        {
            ProductCategory category = null;
            using var conn = _dbConnectionService.GetConnection();
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.Connection = conn;
                command.CommandText = $"SELECT * FROM categories WHERE id = {id}";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        category = new ProductCategory
                        {
                            Id = (int)reader["Id"],
                            Name = (String)reader["Name"],
                            Department = (String)reader["Department"],
                            Description = (String)reader["Description"]
                        };
                    }
                }
                return category;
            }
            finally
            {
                conn.Close();
            }
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
