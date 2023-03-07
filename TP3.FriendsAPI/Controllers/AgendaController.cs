﻿using Microsoft.AspNetCore.Mvc;
using TP3.Application.Interfaces;
using TP3.Application.ViewModels;

namespace TP3.FriendsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgendaController : Controller
    {
        IFriendService _context;


        public AgendaController(IFriendService context)
        {
            _context = context;
        }

        [HttpPost("addfriend")]
        public async Task<IActionResult> AddFriend([FromBody] FriendViewModel creatFriend)
        {
            FriendViewModel friend = await _context.AddFriendAsync(creatFriend);
           
            return CreatedAtAction(nameof(GetFriendsById), new { Id = friend.Id }, friend);
        }

        [HttpGet("allfriends")]
        public async Task<IActionResult> GetAllFriends()
        {
            var friendList = await _context.GetAllFriendAsync();

            return Ok(friendList);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetFriendsById(Guid id)
        {
            FriendViewModel model = await _context.GetFriendBydId(id);
            if (model == null) return NoContent();

            return Ok(model);
        } 



        [HttpPost("delete")]
        public IActionResult Delete(Guid Id)
        {
            _context.DeleteFriendAsync(Id);

            return NoContent();
        }
    }
}