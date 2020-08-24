using EzraTest.Models;
using System;
using System.Collections.Generic;

namespace EzraTest.DB
{
    public class MembersStore : IMembersStore
    {
        public IMembersRepository _membersRepository;

        public MembersStore (IMembersRepository membersRepository) 
        {
            _membersRepository = membersRepository;
        }

        public IEnumerable<Member> GetMembers()
        {
            if (_membersRepository.GetMembers() == null)
            {
                throw new KeyNotFoundException("No members in list");
            }

            return _membersRepository.GetMembers();
        }

        public Member GetMember(string id)
        {
            if (_membersRepository.GetMember(id) == null)
            {
                throw new KeyNotFoundException("Member not found");
            }

            return _membersRepository.GetMember(id);
        }

        public void AddMember(Member member)
        {
            if (string.IsNullOrEmpty(member.Name))
            {
                throw new ArgumentException("Member name must be set");
            }

            if (string.IsNullOrEmpty(member.Email))
            {
                throw new ArgumentException("Member email must be set");
            }

            _membersRepository.AddMember(member);
        }

        public void UpdateMember(string id, Member member)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Member ID must be set");
            }

            if (_membersRepository.GetMember(id) == null)
            {
                throw new KeyNotFoundException("Member not found");
            }

            _membersRepository.UpdateMember(id, member);
        }

        public void DeleteMember(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Member ID must be set");
            }

            if (_membersRepository.GetMember(id) == null)
            {
                throw new KeyNotFoundException("Member not found");
            }

            _membersRepository.DeleteMember(id);
        }
    }
}
