<script setup>
  import { ref, onMounted } from 'vue';

  const submissions = ref([]);
  const errorMessage = ref('');

  onMounted(async () => {
    try {
      const response = await fetch('/api/submissions'); // todo change to real API

      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Load error: ${response.status} - ${errorText}`);
      }

      submissions.value = await response.json();
    } catch (error) {
      console.error('Error when uploading data:', error);
      errorMessage.value = 'The data could not be uploaded. Try again later.';
    }
  });
</script>

<template>
  <div>
    <h1>Submitted Forms</h1>

    <p v-if="errorMessage" class="error">{{ errorMessage }}</p>
    <p v-else-if="submissions.length === 0">There are no submitted forms yet.</p>

    <table v-else>
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

  .error {
    color: red;
    font-weight: bold;
    margin-bottom: 1rem;
  }
</style>
