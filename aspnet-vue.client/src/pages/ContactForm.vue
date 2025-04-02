<template>
  <div class="form-container">
    <h2>Sending form</h2>
    <form @submit.prevent="submitForm">
      <div class="form-group">
        <label for="name">Name:</label>
        <input type="text" v-model="formData.name" required />
      </div>

      <div class="form-group">
        <label for="email">Email:</label>
        <input type="email" v-model="formData.email" required />
      </div>

      <div class="form-group">
        <label for="dropdown">Option:</label>
        <select v-model="formData.option" required>
          <option disabled value="">Choose</option>
          <option value="option1">Option 1</option>
          <option value="option2">Option 2</option>
        </select>
      </div>

      <div class="form-group radio-checkbox-group">
        <label>Gender:</label>
        <div class="radio-buttons">
          <label for="male">Male</label>
          <input type="radio" id="male" value="male" v-model="formData.gender" required />
          <label for="female">Female</label>
          <input type="radio" id="female" value="female" v-model="formData.gender" required />
        </div>
      </div>

      <div class="form-group checkbox-group">
        <div class="checkbox-container">
          <label for="agree">I agree to the terms and conditions</label>
          <input type="checkbox" id="agree" v-model="formData.agree" required />
        </div>
      </div>

      <div class="form-group">
        <label for="date">Date:</label>
        <input type="date" v-model="formData.date" required />
      </div>

      <button type="submit">Send</button>
    </form>

    <div v-if="submitted" class="thank-you">
      Thank you!
    </div>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        formData: {
          name: '',
          email: '',
          option: '',
          gender: '',
          agree: false,
          date: ''
        },
        submitted: false
      };
    },
    methods: {
      async submitForm() {
        try {
          const response = await fetch('/api/submissions', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(this.formData),
          });

          if (!response.ok) {
            const errorText = await response.text();
            throw new Error(`Error: ${response.status} - ${errorText}`);
          }

          this.$router.push('/submissions');
        } catch (error) {
          console.error('Form error:', error);
          alert(`Form error: ${error.message}`);
        }
      }
    }
  };
</script>

<style scoped>
  .form-container {
    max-width: 600px;
    margin: auto;
    padding: 20px;
    border: 1px solid #ccc;
    border-radius: 8px;
    background-color: #f9f9f9;
  }

  .form-group {
    margin-bottom: 15px;
  }

  .radio-checkbox-group {
    display: flex;
    align-items: center;
  }

  label {
    margin-right: 5px;
  }

  input[type="text"],
  input[type="email"],
  input[type="date"],
  select {
    width: 100%;
    padding: 5px 5px;
    font-size: 16px;
    margin: 5px;
    border: 1px solid #ccc;
    border-radius: 5px;
  }

  .radio-buttons {
    display: flex;
    align-items: center;
    gap: 5px;
  }

  .checkbox-container {
    display: flex;
    align-items: center;
    gap: 5px;
  }

  button {
    padding: 10px 15px;
    background-color: #28a745;
    color: white;
    border: none;
    border-radius: 4px;
    cursor: pointer;
  }

    button:hover {
      background-color: #218838;
    }

  .thank-you {
    margin-top: 20px;
    color: #28a745;
  }
</style>
