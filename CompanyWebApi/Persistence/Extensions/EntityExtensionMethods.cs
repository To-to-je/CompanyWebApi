using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Reflection;

namespace CompanyWebApi.Persistence.Extensions
{
    public static class EntityExtensionMethods
    {
        public static async void Change<TClass>(this DbContext context, TClass changes) where TClass : class
        {
            //var dbSet = context.Set<TClass>();
            //var properties = dbSet.EntityType.GetProperties();

            //foreach (var property in properties)
            //{
            //    new CustomAttributeData()
            //}


        }
    }
}
