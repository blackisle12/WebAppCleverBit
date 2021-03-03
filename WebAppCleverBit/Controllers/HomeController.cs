using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebAppCleverBit.Data;
using WebAppCleverBit.Models;
using WebAppCleverBit.Data.Entities;
using System.Threading.Tasks;

namespace WebAppCleverBit.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext context { get; }

        public HomeController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var model = context.Match
                .Where(m => m.ExpiryDate > DateTime.Now)
                .OrderBy(m => m.ExpiryDate)
                .Select(m => new MatchViewModel
                {
                    MatchID = m.MatchID,
                    ExpiryDate = m.ExpiryDate
                })
                .ToList();

            return View(model);
        }

        public IActionResult Play(int ID)
        {
            var match = context.Match
                .Include(m => m.ApplicationUserMatches)
                    .ThenInclude(a => a.ApplicationUser)
                .FirstOrDefault(m => m.MatchID == ID);

            if (match is null)
            {
                return NotFound();
            }

            ApplicationUserMatch applicationUserMatch = null;

            if (User.Identity.IsAuthenticated)
            {
                applicationUserMatch = match.ApplicationUserMatches.FirstOrDefault(a => a.ApplicationUserID == User.Claims.First().Value);
            }

            var model = new MatchViewModel
            {
                MatchID = ID,
                ExpiryDate = match.ExpiryDate,
                HasPlayed = User.Identity.IsAuthenticated ? applicationUserMatch != null : false,
                Number = applicationUserMatch?.Number ?? 0,
                MatchVotes = match.ApplicationUserMatches
                    .OrderByDescending(a => a.Number)
                    .Select(a => new MatchVoteViewModel
                    {
                        Username = a.ApplicationUser.UserName,
                        Number = a.Number
                    })
                    .ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Vote(VoteViewModel model)
        {
            if (
                model is null ||
                model.Number < 0 ||
                model.Number > 100 ||
                !context.Match.Any(m => m.MatchID == model.MatchID) ||
                context.ApplicationUserMatch.Any(m => m.MatchID == model.MatchID && m.ApplicationUserID == User.Claims.First().Value))
            {
                return new JsonResult(new { IsSuccess = false });
            }

            var applicationUserMatch = new ApplicationUserMatch
            {
                ApplicationUserID = User.Claims.First().Value,
                MatchID = model.MatchID,
                Number = model.Number
            };

            context.ApplicationUserMatch.Add(applicationUserMatch);
            await context.SaveChangesAsync();

            return new JsonResult(new { IsSuccess = true });
        }
    }
}
