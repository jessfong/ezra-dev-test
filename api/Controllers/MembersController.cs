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
        public IEnumerable<Member> GetAllMembers()
        {
            return _membersRepository.GetMembers();
        }

        [HttpGet]
        [Route("{id}")]
        public Member GetMember(Guid id)
        {
            return _membersRepository.GetMember(id);
        }

        [HttpPost]
        public void AddMember(Member member)
        {
            _membersRepository.AddMember(member);
        }

        [HttpPut]
        [Route("{id}")]
        public void UpdateMember(Guid id, Member member)
        {
            _membersRepository.UpdateMember(id, member);
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteMember(Guid id)
        {
            _membersRepository.DeleteMember(id);
        }
    }
}
