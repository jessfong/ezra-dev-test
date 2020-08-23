using System;

namespace EzraTest.Models
{
    public class Member
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public string Name { get; set; }
        public string Email { get; set; }
    }
}