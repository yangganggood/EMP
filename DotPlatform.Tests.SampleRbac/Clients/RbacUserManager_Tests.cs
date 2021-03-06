﻿using DotPlatform.Dependency;
using DotPlatform.RBAC.Domain.Repositories;
using DotPlatform.RBAC.Repository.EntityFramework.Repositories;
using DotPlatform.TestBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.SampleRbac.Clients
{
    [TestClass]
    public class RbacUserManager_Tests : UnitTestBase
    {
        protected override void PostInitialize()
        {
            IocManager.Instance.Register<IUserRepository, UserRepository>();

            IocManager.Instance.Build();
        }

        [TestMethod]
        public void Shoud_Get_User_Test()
        {
            var userRepository = IocManager.Instance.Resolve<IUserRepository>();
            var user = userRepository.Find("gang.yang@advantech.com.cn");
            Assert.IsNotNull(user);
            Assert.IsNotNull(user.Tenant);
        }
    }
}
