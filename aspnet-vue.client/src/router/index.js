import { createRouter, createWebHistory } from 'vue-router';
import ContactForm from '../components/ContactForm.vue';
import SubmissionsList from '../components/SubmissionsList.vue';

const routes = [
  { path: '/', component: ContactForm },
  { path: '/submissions', component: SubmissionsList },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
