using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using System;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Daos
{
    public class ProductDaoDb : IProductDao
    {
        private readonly IDbConnectionService _dbConnectionService;
        private readonly IProductCategoryDao _productCategoryDao;
        private readonly ISupplierDao _supplierDao;
        public ProductDaoDb(IDbConnectionService dbConnectionService, IProductCategoryDao productCategoryDao
                            ,ISupplierDao supplierDao)
        {
            _dbConnectionService = dbConnectionService;
            _productCategoryDao = productCategoryDao;
            _supplierDao = supplierDao;
        }

        public void Add(Product item)
        {
            throw new System.NotImplementedException();
        }

        public Product Get(int id)
        {
            Product product = null;
            using var conn = _dbConnectionService.GetConnection();
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.Connection = conn;
                command.CommandText = $"SELECT * FROM products WHERE Id = {id}";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        product = new Product
                        {
                            Id = (int)reader["Id"],
                            Name = (String)reader["Name"],
                            DefaultPrice = (decimal)reader["DefaultPrice"],
                            Currency = (String)reader["Currency"],
                            Description = (String)reader["Description"],
                            ProductCategory = _productCategoryDao.Get((int)reader["ProductCategoryId"]),
                            Supplier = _supplierDao.Get((int)reader["SupplierID"])
                        };
                    }
                }
                return product;
            }
            finally
            {
                conn.Close();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            using var conn = _dbConnectionService.GetConnection();
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM products;";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = (int)reader["Id"],
                            Name = (String)reader["Name"],
                            DefaultPrice = (decimal)reader["DefaultPrice"],
                            Currency = (String)reader["Currency"],
                            Description = (String)reader["Description"],
                            ProductCategory = _productCategoryDao.Get((int)reader["ProductCategoryId"]),
                            Supplier = _supplierDao.Get((int)reader["SupplierID"])
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

        public IEnumerable<Product> GetBy(Supplier supplier)
        {
            List<Product> products = new List<Product>();
            using var conn = _dbConnectionService.GetConnection();
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.Connection = conn;
                command.CommandText = $@"SELECT * FROM products AS p
                                        JOIN suppliers AS s ON p.ProductCategoryId=s.Id
                                        WHERE s.Name='{supplier.Name}';";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = (int)reader["Id"],
                            Name = (String)reader["Name"],
                            DefaultPrice = (decimal)reader["DefaultPrice"],
                            Currency = (String)reader["Currency"],
                            Description = (String)reader["Description"],
                            ProductCategory = _productCategoryDao.Get((int)reader["ProductCategoryId"]),
                            Supplier = _supplierDao.Get((int)reader["SupplierID"])
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

        public IEnumerable<Product> GetBy(ProductCategory productCategory)
        {
            List<Product> products = new List<Product>();
            using var conn = _dbConnectionService.GetConnection();
            try
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.Connection = conn;
                command.CommandText = $@"SELECT * FROM products AS p
                                        JOIN categories AS c ON p.ProductCategoryId=c.Id
                                        WHERE c.Name='{productCategory.Name}';";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product {
                            Id = (int)reader["Id"],
                            Name = (String)reader["Name"],
                            DefaultPrice = (decimal)reader["DefaultPrice"],
                            Currency = (String)reader["Currency"],
                            Description = (String)reader["Description"],
                            ProductCategory = _productCategoryDao.Get((int)reader["ProductCategoryId"]),
                            Supplier = _supplierDao.Get((int)reader["SupplierID"])
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
