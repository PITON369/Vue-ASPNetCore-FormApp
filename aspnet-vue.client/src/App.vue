<script setup>
  import { RouterView, RouterLink } from 'vue-router';
</script>

<template>
  <header>
    <nav>
      <RouterLink to="/">Submit Form</RouterLink> |
      <RouterLink to="/submissions">View Submissions</RouterLink>
    </nav>
  </header>

  <main>
    <RouterView />
  </main>
</template>

<style scoped>
  nav {
    display: flex;
    gap: 1rem;
    padding: 1rem;
  }
</style>
