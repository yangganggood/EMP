﻿using System;
using System.Collections.Generic;

namespace DotPlatform.Events.Storage
{
    /// <summary>
    /// 表示为领域事件存储
    /// </summary>
    interface IDomainEventStorage
    {
        /// <summary>
        /// 保存领域事件
        /// </summary>
        /// <param name="domainEvent">表示要存储的领域事件</param>
        void Save(IDomainEvent domainEvent);

        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="aggregateRootType">聚合根类型</param>
        /// <param name="aggregateRootId">聚合 Id</param>
        /// <returns><see cref="IDomainEvent"/>领域事件集</returns>
        IEnumerable<IDomainEvent> Load(Type aggregateRootType, Guid aggregateRootId);

        /// <summary>
        /// 加载事件
        /// </summary>
        /// <param name="aggregateRootType">聚合根类型</param>
        /// <param name="aggregateRootId">聚合 Id</param>
        /// <param name="version">事件版本号</param>
        /// <returns><see cref="IDomainEvent"/>领域事件集</returns>
        IEnumerable<IDomainEvent> Load(Type aggregateRootType, Guid aggregateRootId, int version);
    }
}
