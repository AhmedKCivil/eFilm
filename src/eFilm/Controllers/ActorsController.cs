using eFilm.Data.Services.Interfaces;
using eFilm.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eFilm.Controllers
{
    public class ActorsController : Controller
    {

        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;

        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();

            return View(data);
        }

        [HttpGet]
        //Get Data
        public IActionResult Create()
        {
            return View();

        }

        //Post Data
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor) 
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);

            if (actorDetails == null) return NotFound();

            return View(actorDetails);
        }

        [HttpGet]
        //Get Data
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return NotFound();

            return View(actorDetails);

        }

        //Post Data
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateAsync(id, actor);

            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        //Get Data
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return NotFound();

            return View(actorDetails);

        }

        //Post Data
        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return NotFound();
           
            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));

        }

        



    }


}






//    [HttpGet]
//    //Get
//    public IActionResult Update(int? id) 
//    { 
//        if (id == null || id == 0)
//        {
//            return NotFound();
//        }

//        var actorEdit = _db.ActorsTable.Find(id);
//        if (actorEdit == null)
//        {
//            return NotFound();
//        }
//        return View(actorEdit);
//    }


//    [HttpPost]
//    //Post
//    public IActionResult UpdateActor(Actor obj) //in the form asp-action should be named as the Post method name "UpdateActor" AND Have different method name compared to the "GET"
//    {
//        if (ModelState.IsValid)
//        {
//            _db.ActorsTable.Update(obj);
//            _db.SaveChanges();
//            return RedirectToAction("Index");
//        }
//        return View(obj);
//    }

//    [HttpGet]
//    //Get
//    public IActionResult Delete(int? id)
//    {
//      if (id == null)
//        {
//            return NotFound();
//        }
//        var deleteActor = _db.ActorsTable.Find(id);
//        if (deleteActor == null)
//        {
//            return NotFound();
//        }
//        return View(deleteActor);
//    }

//    [HttpPost]
//    //Post
//    public IActionResult DeletePost(int? id)
//    {
//        var actorDelete = _db.ActorsTable.Find(id);
//        if (actorDelete == null)
//        {
//            return NotFound();
//        }

//            _db.ActorsTable.Remove(actorDelete);
//            _db.SaveChanges();
//            return RedirectToAction("Index");
//    }

//    public IActionResult Details(int? id)
//    {
//        var actorDetails = _db.ActorsTable.Find(id);
//        if (actorDetails == null)
//        {
//            return NotFound();
//        }
//        return View(actorDetails);


//    }

//}
//}








////////////
///

//private readonly ApplicationDbContext _db;

//public ActorsController(ApplicationDbContext db)
//{
//    _db = db;

//}

//private readonly IActorsService _service;

//public ActorsController(IActorsService service)
//{
//    _service = service;

//}

//public IActionResult Index()
//{
//    IEnumerable<Actor> ActorsList = _db.ActorsTable;

//    return View(ActorsList);

//}


//[HttpGet]
////Get Data
//public IActionResult Create()
//{
//    return View();

//}

////Post Data
//public IActionResult Create(Actor actor)
//{

//    _db.ActorsTable.Add(actor);
//    _db.SaveChanges();
//    return RedirectToAction("Index");

//}
//[HttpGet]
////Get
//public IActionResult Update(int? id)
//{
//    if (id == null || id == 0)
//    {
//        return NotFound();
//    }

//    var actorEdit = _db.ActorsTable.Find(id);
//    if (actorEdit == null)
//    {
//        return NotFound();
//    }
//    return View(actorEdit);
//}


//[HttpPost]
////Post
//public IActionResult UpdateActor(Actor obj) //in the form asp-action should be named as the Post method name "UpdateActor" AND Have different method name compared to the "GET"
//{
//    if (ModelState.IsValid)
//    {
//        _db.ActorsTable.Update(obj);
//        _db.SaveChanges();
//        return RedirectToAction("Index");
//    }
//    return View(obj);
//}

//[HttpGet]
////Get
//public IActionResult Delete(int? id)
//{
//    if (id == null)
//    {
//        return NotFound();
//    }
//    var deleteActor = _db.ActorsTable.Find(id);
//    if (deleteActor == null)
//    {
//        return NotFound();
//    }
//    return View(deleteActor);
//}

//[HttpPost]
////Post
//public IActionResult DeletePost(int? id)
//{
//    var actorDelete = _db.ActorsTable.Find(id);
//    if (actorDelete == null)
//    {
//        return NotFound();
//    }

//    _db.ActorsTable.Remove(actorDelete);
//    _db.SaveChanges();
//    return RedirectToAction("Index");
//}

//public IActionResult Details(int? id)
//{
//    var actorDetails = _db.ActorsTable.Find(id);
//    if (actorDetails == null)
//    {
//        return NotFound();
//    }
//    return View(actorDetails);


//}