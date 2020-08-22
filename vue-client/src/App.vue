<template>
  <div id="app" class="container">
    <header>
      <b-navbar class="border-bottom box-shadow" toggleable="sm" type="light">
        <b-container>
          <b-navbar-brand to="/">Ezra Test</b-navbar-brand>

          <b-navbar-toggle target="nav-collapse" />

          <b-collapse id="nav-collapse" is-nav>
            <b-navbar-nav class="ml-auto">
              <b-nav-item to="/">Home</b-nav-item>
              <b-nav-item to="/add-member">Add Member</b-nav-item>
            </b-navbar-nav>
          </b-collapse>
        </b-container>
      </b-navbar>
    </header>

    <router-view />
  </div>
</template>

<style>
  a.navbar-brand {
    white-space: normal;
    text-align: center;
    word-break: break-all;
  }

  html {
    font-size: 14px;
  }
  @media (min-width: 768px) {
    html {
      font-size: 16px;
    }
  }

  .box-shadow {
    box-shadow: 0 0.25rem 0.75rem rgba(0, 0, 0, 0.05);
  }
</style>
