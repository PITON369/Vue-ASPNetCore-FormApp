<script setup>
  import { ref, onMounted } from 'vue';

  const submissions = ref([]);
  const errorMessage = ref('');
  const headers = ref([]);

  onMounted(async () => {
    try {
      const response = await fetch('/api/submissions');
      if (!response.ok) throw new Error(`Error: ${response.status}`);
      const data = await response.json();
      submissions.value = data;

      // Extract headers from the first submission
      if (data.length > 0) {
        headers.value = Object.keys(data[0].data);
      }
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
          <th v-for="header in headers" :key="header">{{ header }}</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="submission in submissions" :key="submission.id">
          <td>{{ submission.id }}</td>
          <td v-for="header in headers" :key="header">{{ submission.data[header] }}</td>
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
    text-align: left;
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
