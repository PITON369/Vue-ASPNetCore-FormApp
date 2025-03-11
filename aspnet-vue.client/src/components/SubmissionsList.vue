// SubmissionsList.vue
<script setup>
import { ref, onMounted } from 'vue';

const submissions = ref([]);

onMounted(async () => {
  const response = await fetch('/api/submissions'); // todo change to real API
  submissions.value = await response.json();
});
</script>

<template>
  <div>
    <h1>Submitted Forms</h1>
    <table>
      <thead>
        <tr>
          <th>ID</th>
          <th>Data</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(submission, index) in submissions" :key="index">
          <td>{{ index + 1 }}</td>
          <td>{{ submission }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<style scoped>
  table {
    width: 100%;
    border-collapse: collapse;
  }

  th, td {
    border: 1px solid #ddd;
    padding: 8px;
  }

  th {
    background-color: #f4f4f4;
  }
</style>
