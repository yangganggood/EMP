﻿using System.Web.Mvc;
using WMS.DataTransferObject.Dtos;
using WMS.Application.Services;

namespace WMS.Web.Areas.Admin.Controllers
{
    public class WarehouseController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            using (var service = IocResolver.Resolve<IWarehouseAppService>())
            {
                var warehouses = service.GetAllWarehouses();
                return JsonEx(warehouses);
            }
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WarehouseDto model)
        {
            if (!ModelState.IsValid)
                return Json(false, "Input data is invalid.");

            try
            {
                using (var service = IocResolver.Resolve<IWarehouseAppService>())
                {
                    service.CreateWarehouse(model);
                }

                return Json(true);
            }
            catch
            {
                return Json(false);
            }
        }
    }
}
