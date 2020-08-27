using System;

namespace EzraTest.Models
{
    public class Member
    {
        public Member()
        {
            Id = Guid.NewGuid().ToString("N");
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}