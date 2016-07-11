﻿using System.Data.Entity;
using DotPlatform.EntityFramework;
using DotPlatform.Runtime.Session;
using DotPlatform.Repository.Tests.EntityFramework.EntityConfigurarion;

namespace DotPlatform.Repository.Tests.EntityFramework
{
    public class TestEfDbContext : EfDbContext
    {
        public TestEfDbContext() : base("MyTest")
        {
            this.OwnerSession = NullSession.Instance;
        }

        protected override void CreateModel(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductEntityTypeConfuguration());
            modelBuilder.Configurations.Add(new OrderEntityTypeConfuguration());
            modelBuilder.Configurations.Add(new OrderLineEntityTypeConfuguration());
        }
    }
}
