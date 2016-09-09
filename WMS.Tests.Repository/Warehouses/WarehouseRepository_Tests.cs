﻿using DotPlatform.Dependency;
using DotPlatform.TestBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WMS.Domain.Repositories.Query;

namespace WMS.Tests.Repository.Warehouses
{
    [TestClass]
    public class WarehouseRepository_Tests : UnitTestBase
    {
        [TestMethod]
        public void Shoud_Find_Warehouse_Test()
        {
            using (var service = IocManager.Instance.Resolve<IWarehouseQueryRepository>())
            {
                var warehouse = service.Find("");

                Assert.IsNull(warehouse);
            }
        }

        [TestMethod]
        public void Shoud_Get_Warehouse_Test()
        {
            using (var service = IocManager.Instance.Resolve<IWarehouseQueryRepository>())
            {
                var warehouse = service.FirstOrDefault(w => w.Name == "");

                Assert.IsNull(warehouse);
            }
        }
    }
}
