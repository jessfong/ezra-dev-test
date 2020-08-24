using System;
using System.Collections.Generic;

using EzraTest.DB;
using EzraTest.Models;

using Microsoft.AspNetCore.Mvc;

namespace EzraTest.Controllers
{
    [ApiController]
    [Route("members")]
    public class MembersController : ControllerBase
    {
        private readonly IMembersRepository _membersRepository;
        private readonly IMembersStore _membersStore;

        public MembersController(IMembersRepository membersRepository, IMembersStore membersStore)
        {
            _membersRepository = membersRepository;
            _membersStore = membersStore;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Member>> GetAllMembers()
        {
            try
            {
                return Ok(_membersStore.GetMembers());
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Member> GetMember(string id)
        {
            try
            {
                return Ok(_membersStore.GetMember(id));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public IActionResult AddMember(Member member)
        {
            try
            {
                _membersStore.AddMember(member);
                return Ok();
            }
            catch(ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateMember(string id, Member member)
        {
            try
            {
                _membersStore.UpdateMember(id, member);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteMember(string id)
        {
            try
            {
                _membersStore.DeleteMember(id);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
