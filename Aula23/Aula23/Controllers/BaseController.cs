using Aula23.Models;
using Aula23.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aula23.Controllers
{
    public class BaseController<M, R> : Controller where M : BaseModels where R : BaseRepository<M>
    {
        R repository;
        public BaseController(R repository)
        {
            this.repository = repository;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(M model)
        {
            repository.Create(model);
            ModelState.Clear();
            return View();
        }
        public ActionResult List()
        {
            return View(repository.Read());
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(repository.Read(id));
        }
        [HttpPost]
        public ActionResult Edit(M model)
        {
            repository.Update(model);
            return RedirectToAction("List");
        }
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("List");
        }
        public ActionResult Details(int id)
        {
            return View(repository.Read(id));
        }
    }
}