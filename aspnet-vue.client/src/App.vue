<script setup>
  import { RouterView, RouterLink } from 'vue-router';
</script>

<template>
  <div class="layout">
    <header>
      <nav>
        <RouterLink to="/">Submit Form</RouterLink> |
        <RouterLink to="/submissions">View Submissions</RouterLink>
      </nav>
    </header>

    <main>
      <RouterView />
    </main>
  </div>
</template>

<style scoped>
  .layout {
    display: flex;
    flex-direction: column;
    min-height: 100vh;
  }

  header {
    background: #f8f9fa;
    padding: 1rem;
    text-align: center;
  }

  nav {
    display: flex;
    justify-content: center;
    gap: 1rem;
  }

  main {
    flex: 1;
    padding: 1rem;
  }
</style>
