﻿using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Repository;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Repositories
{
    public class ProductRepositoryAsync : GenericRepositoryAsync<Product>, IProductRepositoryAsync
    {
        public ProductRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
