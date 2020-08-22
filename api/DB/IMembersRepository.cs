using System;
using System.Collections.Generic;

using EzraTest.Models;

namespace EzraTest.DB
{
    public interface IMembersRepository
    {
        /// <summary>
        /// Get all the members.
        /// </summary>
        /// <returns>All the members in the database.</returns>
        IEnumerable<Member> GetMembers();

        /// <summary>
        /// Gets the member for <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the member to get.</param>
        /// <returns>The member if found; null otherwise.</returns>
        Member GetMember(Guid id);

        /// <summary>
        /// Adds the member to the database.
        /// </summary>
        /// <param name="member">The member to add.</param>
        void AddMember(Member member);

        /// <summary>
        /// Updates the member with <paramref name="id"/> to the values in <paramref name="member"/>.
        /// </summary>
        /// <param name="id">The id of the member to update.</param>
        /// <param name="member">The new member data.</param>
        void UpdateMember(Guid id, Member member);

        /// <summary>
        /// Removes the member from the database with <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The id of the member.</param>
        void DeleteMember(Guid id);
    }
}