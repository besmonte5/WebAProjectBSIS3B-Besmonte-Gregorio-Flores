using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using project.Data;
using project.Models;

namespace project.Controllers
{

  public class ItemController : Controller
  {

    private readonly ApplicationDbContext _db;

    public ItemController(ApplicationDbContext db)
    {

      _db = db;

    } 

    [HttpGet]

    public IActionResult Index()
    {
        IEnumerable<Item> itemList = _db.Items;
       return View(itemList);

    }

    [HttpGet]
    public IActionResult Create()
    {

        return View();
    }


    [HttpPost]
    public IActionResult Create(Item item)
    {
       if(ModelState.IsValid)
       {
         _db.Items.Add(item);
         _db.SaveChanges();
         return RedirectToAction("Index");

       }

       return View();


    }

     [HttpGet]
    public IActionResult Edit(int id)
    {
        var item = _db.Items.Find(id);
        if(item == null)
        {
            return NotFound();
        }
        return View(item);
    }

      [HttpPost]
    public IActionResult Edit(Item item)
    {
       if(ModelState.IsValid)
       {
         _db.Items.Update(item);
         _db.SaveChanges();
         return RedirectToAction("Index");

       }

       return View();


    }


     [HttpGet]
    public IActionResult Delete(int id)
    {
        var item = _db.Items.Find(id);
        if(item == null)
        {
            return NotFound();
        }
        return View(item);
    }

    [HttpPost] 
    [ActionName("Delete")]

    public IActionResult DeletePost(int id)
    {
        var item = _db.Items.Find(id);
        if(item == null)
        {
            return NotFound();
        }
         _db.Items.Remove(item);
         _db.SaveChanges();
         return RedirectToAction("Index");

    }
  }



}