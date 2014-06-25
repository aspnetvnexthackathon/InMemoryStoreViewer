using Microsoft.Data.Entity.Infrastructure;
using System;
using JetBrains.Annotations;
using Microsoft.Data.Entity;

namespace WebApp.Models
{
    public class CustomersDbContextInitializer : DbSetInitializer
    {
        public override void InitializeSets(DbContext context)
        {
            base.InitializeSets(context);
        }
    }
}