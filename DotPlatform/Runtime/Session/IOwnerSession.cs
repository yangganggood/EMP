﻿using System;

namespace DotPlatform.Runtime.Session
{
    /// <summary>
    /// 表示实现此接口的类为当前会话者的相关信息
    /// </summary>
    /// <typeparam name="TKey">会话信息主体<see cref="DotPlatform.Domain.Entities.Entity"/>主键类型</typeparam>
    public interface IOwnerSession<TKey>
    {
        TKey UserId { get; }

        TKey TenantId { get; }
    }

    /// <summary>
    /// 表示实现此接口的类为当前会话者的相关信息。
    /// 其中实体<see cref="DotPlatform.Domain.Entities.Entity"/>主键类型为 <see cref="System.Nullable{Guid}"/>
    /// </summary>
    public interface IOwnerSession : IOwnerSession<Guid?>
    {

    }
}
