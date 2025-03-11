<template>
  <div class="form-container">
    <h2>Форма отправки</h2>
    <form @submit.prevent="submitForm">
      <div class="form-group">
        <label for="name">Имя:</label>
        <input type="text" v-model="formData.name" required />
      </div>

      <div class="form-group">
        <label for="email">Email:</label>
        <input type="email" v-model="formData.email" required />
      </div>

      <div class="form-group">
        <label for="dropdown">Выберите опцию:</label>
        <select v-model="formData.option" required>
          <option disabled value="">Пожалуйста, выберите</option>
          <option value="option1">Опция 1</option>
          <option value="option2">Опция 2</option>
        </select>
      </div>

      <div class="form-group radio-checkbox-group">
        <label>Пол:</label>
        <div class="radio-buttons">
          <label for="male">Мужчина</label>
          <input type="radio" id="male" value="male" v-model="formData.gender" required />
          <label for="female">Женщина</label>
          <input type="radio" id="female" value="female" v-model="formData.gender" required />
        </div>
      </div>

      <div class="form-group checkbox-group">
        <div class="checkbox-container">
          <label for="agree">Я согласен с условиями</label>
          <input type="checkbox" id="agree" v-model="formData.agree" required />
        </div>
      </div>

      <div class="form-group">
        <label for="date">Дата:</label>
        <input type="date" v-model="formData.date" required />
      </div>

      <button type="submit">Отправить</button>
    </form>

    <div v-if="submitted" class="thank-you">
      Спасибо за ваше сообщение!
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
      const response = await fetch('/api/submissions', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(this.formData),
      });
      if (response.ok) {
        this.submitted = true;
      }
      console.log(this.formData);
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
