using Game_Store_Angular.DDTO.DataAccess;
using Game_Store_Angular.DDTO.DataAccess.Entity;
using Game_Store_Angular.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game_Store_Angular.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class AdminCreateGamesController : Controller
    {

        private readonly EFContext _context;
        private readonly Games _gamesDb;

        public AdminCreateGamesController(EFContext context, Games gamesDb)
        {
            _context = context;
            _gamesDb = gamesDb;
        }

        EFContext db;

        public AdminCreateGamesController(EFContext _contex)
        {
            db = _contex;
            if(!db.games.Any())
            {
                db.games.Add(new Games
                {
                    Game_name = "GTA 5",
                    BriefDescription = "Grand Theft Auto V — це пригодницька відеогра 2013 року, розроблена Rockstar North та видана компанією Rockstar Games. Події відбуваються у вигаданому штаті Сан-Андреас, що заснований на південній Каліфорнії",
                    Вescription = "Grand Theft Auto V — це пригодницька відеогра 2013 року, розроблена Rockstar North та видана компанією Rockstar Games.",
                    Price = 245,
                    Genre = "Відкритий світ, action-adventure, шутер від третьої особи",
                    Game_Icon = "https://upload.wikimedia.org/wikipedia/uk/thumb/a/a5/Grand_Theft_Auto_V.png/220px-Grand_Theft_Auto_V.png",
                    Picture1 = "data:image/jpeg;base64,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",
                    Picture2 = "https://i.rutab.net/upload/2019/userfiles/gta-5-cheats-1.jpg",
                    Picture3 = "https://www.ixbt.com/img/n1/news/2021/2/5/GTA5_1.JPG",
                    Picture4 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRWEhz1810cG7mqE6F89XFztAXKE8ripwNRPQ&usqp=CAU"
                });
                db.SaveChanges();
            }

        }

        [HttpGet]
        public IEnumerable<Games> Get()
        {
            return db.games.ToList();
        }
            

        [HttpGet("{id}")]
        public Games Get(int id)
        {
            Games gamest = db.games.FirstOrDefault(x => x.Id == id);
            return gamest;
        }

        [HttpPost]
        public IActionResult Post(Games gamest)
        {
            if(ModelState.IsValid)
            {
                db.games.Add(gamest);
                db.SaveChanges();
                return Ok(gamest);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Games gamest)
        {
            if(ModelState.IsValid)
            {
                db.Update(gamest);
                db.SaveChanges();
                return Ok(gamest);
            }
            return BadRequest(ModelState);
        }



        //[HttpGet]
        //public IEnumerable<GameModel> getGames()
        //{
        //    List<GameModel> gamest = new List<GameModel>();

        //    var dbgames = _context.games.ToList();

        //    foreach (var item in dbgames)
        //    {
        //        GameModel gamess = new GameModel();
        //        var infogm = _context.games.FirstOrDefault(t => t.Id == item.Id);

        //        gamess.Id = infogm.Id;
        //        gamess.Game_name = infogm.Game_name;
        //        gamess.BriefDescription = infogm.BriefDescription;
        //        gamess.Вescription = infogm.Вescription;
        //        gamess.Price = infogm.Price;
        //        gamess.Release_date = infogm.Release_date;
        //        gamess.Genre = infogm.Genre;
        //        gamess.Game_Icon = infogm.Game_Icon;
        //        gamess.Picture1 = infogm.Picture1;
        //        gamess.Picture2 = infogm.Picture2;
        //        gamess.Picture3 = infogm.Picture3;
        //        gamess.Picture4 = infogm.Picture4;

        //        gamest.Add(gamess);
        //    }
        //    return gamest;
        //}


        //[HttpPost("{id}")]
        //public GameModel GetGames([FromRoute] int id)
        //{
        //    var gamesg = _context.games.FirstOrDefault(t => t.Id == id);
        //    var gameMrInfo = _context.games.FirstOrDefault(t => t.Id == id);

        //    GameModel model = new GameModel();
        //    model.Id = gamesg.Id;
        //    model.Game_name = gamesg.Game_name;
        //    model.BriefDescription = gamesg.BriefDescription;
        //    model.Вescription = gamesg.Вescription;
        //    model.Price = gamesg.Price;
        //    model.Release_date = gamesg.Release_date;
        //    model.Genre = gamesg.Genre;
        //    model.Game_Icon = gamesg.Game_Icon;
        //    model.Picture1 = gamesg.Picture1;
        //    model.Picture2 = gamesg.Picture2;
        //    model.Picture3 = gamesg.Picture3;
        //    model.Picture4 = gamesg.Picture4;

        //    return model;
        //}


        //[HttpPost("game-create")]
        //public ActionResult Create(CreatGameModel model)
        //{
        //    try
        //    {
        //        _context.games.Add(new Games
        //        {
        //            Game_name = model.Game_name,
        //            BriefDescription = model.BriefDescription,
        //            Вescription = model.Вescription,
        //            Price = model.Price,
        //            Release_date = model.Release_date,
        //            Genre = model.Genre,
        //            Game_Icon = model.Game_Icon,
        //            Picture1 = model.Picture1,
        //            Picture2 = model.Picture1,
        //            Picture3 = model.Picture1,
        //            Picture4 = model.Picture1,
        //        });

        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Message);
        //    }

        //    _context.SaveChanges();

        //    return Ok();
        //}

    }
}
