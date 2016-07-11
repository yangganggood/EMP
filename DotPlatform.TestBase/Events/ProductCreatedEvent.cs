﻿using DotPlatform.Events;
using DotPlatform.Domain.Entities;

namespace DotPlatform.TestBase.Events
{
    /// <summary>
    /// 产品创建事件
    /// </summary>
    public class ProductCreatedEvent : DomainEvent
    {
        protected ProductCreatedEvent(IEntity entity) : base(entity)
        {

        }
    }
}