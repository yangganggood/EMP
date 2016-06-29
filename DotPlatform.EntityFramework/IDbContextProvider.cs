﻿using System.Data.Entity;

namespace DotPlatform.EntityFramework
{
    /// <summary>
    /// DB 上下文对象提供者
    /// </summary>
    /// <typeparam name="TDbContext"><see cref="System.Data.Entity.DbContext"/></typeparam>
    public interface IDbContextProvider<out TDbContext>
        where TDbContext : DbContext
    {
        /// <summary>
        /// 获取 DB 上下文对象
        /// </summary>
        TDbContext DbContext { get; }
    }
}
