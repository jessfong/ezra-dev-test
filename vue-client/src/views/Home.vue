<template>
  <div class="home">
    <h1>Members</h1>

    <table class="table table-striped" v-if="members">
      <thead>
        <tr>
          <th>ID</th>
          <th>Name</th>
          <th>Email</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="member in members" :key="member.id">
          <td>{{ member.id }}</td>
          <td>{{ member.name }}</td>
          <td>{{ member.email }}</td>
          <td class="btn-group">
            <button class="img-btn btn-link" @click="deleteMember(member.id)">
              <img src="/delete.svg" width="12px" height="12px" />
            </button>
            <button class="img-btn btn-link" @click="editMember(member.id)">
              <img src="/edit.svg" width="12px" height="12px" />
            </button>
          </td>
        </tr>
      </tbody>
    </table>

    <p v-else>
      <em>
        Loading...
      </em>
    </p>
  </div>
</template>

<script>
  export default {
    name: "Home",

    data() {
      return {
        members: null
      };
    },

    methods: {
      async deleteMember(memberId) {
        // TODO
        throw "Implement me";
      },

      async editMember(memberId) {
        // TODO
        throw "Implement me";
      }
    },

    async mounted() {
      const response = await fetch("http://localhost:5000/members");
      const data = await response.json();
      this.members = data;
    }
  };
</script>
