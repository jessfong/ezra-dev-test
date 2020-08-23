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

        public MembersController()
        {
            _membersRepository = new MembersRepository("app.db");
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Member>> GetAllMembers()
        {
            return Ok(_membersRepository.GetMembers());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Member> GetMember(string id)
        {
            if (_membersRepository.GetMember(id) == null)
            {
                return NotFound();
            }

            return Ok(_membersRepository.GetMember(id));
        }

        [HttpPost]
        public IActionResult AddMember(Member member)
        {
            _membersRepository.AddMember(member);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateMember(string id, Member member)
        {
            if (_membersRepository.GetMember(id) == null)
            {
                return NotFound();
            }

            _membersRepository.UpdateMember(id, member);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteMember(string id)
        {
            if (_membersRepository.GetMember(id) == null)
            {
                return NotFound();
            }

            _membersRepository.DeleteMember(id);
            return Ok();
        }
    }
}
