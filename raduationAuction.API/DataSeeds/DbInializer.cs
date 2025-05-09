
using GraduationAuction.API.Persistance;
using Microsoft.EntityFrameworkCore;
using raduationAuction.API.Model;
using System;
using System.Text.Json;

namespace raduationAuction.API.DataSeeds
{
    //public class DbInializer(webDbContext context) : IDbInializer
    //{
    //    //public async Task InializerAsync()
    //    //{

    //    //    if ((await context.Database.GetPendingMigrationsAsync()).Any())
    //    //    {
    //    //        await context.Database.MigrateAsync();
    //    //    }
    //    //    if (!context.Set<User>().Any())
    //    //    {
    //    //        var data = await File.ReadAllTextAsync("Seeds/user.json");
    //    //        var objects = JsonSerializer.Deserialize<List<User>>(data);

    //    //        if (objects is not null && objects.Any())
    //    //        {
    //    //            context.Set<User>().AddRange(objects);
    //    //            await context.SaveChangesAsync();
    //    //        }
    //    //    }

    //        if (!context.Set<Item>().Any()) 
    //        {
    //            var data = await File.ReadAllTextAsync("Seeds/Item.json");
    //            var objects = JsonSerializer.Deserialize<List<Item>>(data);

    //            if (objects is not null && objects.Any())
    //            {
    //                context.Set<Item>().AddRange(objects);
    //                await context.SaveChangesAsync();
    //            }

    //        }
    //    }
    //}
}
