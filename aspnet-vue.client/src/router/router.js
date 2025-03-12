import { createRouter, createWebHistory } from 'vue-router';
import ContactForm from '@/pages/ContactForm.vue';
import SubmissionsList from '@/pages/SubmissionsList.vue';
const routes = [
  {
    path: '/',
    name: 'ContactForm',
    component: ContactForm
  },
  {
    path: '/submissions',
    name: 'SubmissionsList',
    component: SubmissionsList
  }
];

const router = createRouter({
  routes,
  history: createWebHistory()
});

export default router;
