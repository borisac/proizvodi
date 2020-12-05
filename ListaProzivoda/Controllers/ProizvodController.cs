using ListaProzivoda.Models;
using ListaProzivoda.Repositories;
using System.Linq;
using System.Web.Mvc;

namespace ListaProzivoda.Controllers
{
    public class ProizvodController : Controller
    {
        private readonly IRepository<Proizvod> _repository;

        public ProizvodController()
        {
            _repository = DataFactory.DataFactory.GetService<Proizvod>();
        }
        // GET: Proizvod
        public ActionResult Index()
        {
            return View(_repository.GetAll());
        }

        // GET: Proizvod/Details/5
        public ActionResult Details(int id)
        {
            return View(_repository.GetById(id));

        }

        // GET: Proizvod/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proizvod/Create
        [HttpPost]
        public ActionResult Create(Proizvod p)
        {
            try
            {
                _repository.Create(p);
                _repository.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proizvod/Edit/5
        public ActionResult Edit(int id)
        {
            
                return View(_repository.GetById(id));
            
        }

        // POST: Proizvod/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Proizvod p)
        {
            try
            {
                _repository.Edit(p);
                _repository.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proizvod/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repository.GetById(id));
        }

        // POST: Proizvod/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _repository.Delete(id);
                _repository.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

    internal class ProizvodModel
    {
    }
}
