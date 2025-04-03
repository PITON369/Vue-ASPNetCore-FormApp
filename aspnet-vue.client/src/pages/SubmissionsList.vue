<script setup>
  import { ref, onMounted, computed } from 'vue';

  const submissions = ref([]);
  const errorMessage = ref('');
  const headers = ref([]);
  const selectedColumn = ref('');
  const filterValue = ref('');

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

  const filteredSubmissions = computed(() => {
    return submissions.value.filter(submission => {
      if (selectedColumn.value && filterValue.value) {
        return submission.data[selectedColumn.value]?.toString().toLowerCase().includes(filterValue.value.toLowerCase());
      }
      return true;
    });
  });
</script>

<template>
  <div>
    <h1>Submitted Forms</h1>

    <p v-if="errorMessage" class="error">{{ errorMessage }}</p>
    <p v-else-if="submissions.length === 0">There are no submitted forms yet.</p>

    <div v-else>
      <div>
        <label for="column">Filter by Column:</label>
        <select id="column" v-model="selectedColumn">
          <option value="">Select Column</option>
          <option v-for="header in headers" :key="header" :value="header">{{ header }}</option>
        </select>
        <input v-if="selectedColumn" v-model="filterValue" placeholder="Filter value..." />
      </div>

      <table>
        <thead>
          <tr>
            <th>ID</th>
            <th v-for="header in headers" :key="header">{{ header }}</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="submission in filteredSubmissions" :key="submission.id">
            <td>{{ submission.id }}</td>
            <td v-for="header in headers" :key="header">{{ submission.data[header] }}</td>
          </tr>
        </tbody>
      </table>
    </div>
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

  label {
    margin-right: 8px;
  }

  input, select {
    margin-bottom: 1rem;
  }
</style>
