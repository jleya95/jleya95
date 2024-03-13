import { createRouter as createRouter, createWebHistory } from 'vue-router'
import { useStore } from 'vuex'

// Import components
import HomeView from '../views/HomeView.vue';
import LoginView from '../views/LoginView.vue';
import LogoutView from '../views/LogoutView.vue';
import RegisterView from '../views/RegisterView.vue';
import RandomRecordView from '../views/RandomRecordView.vue';
import AddRecordView from '../views/AddRecordView.vue';
import AllRecordsView from '../views/AllRecordsView.vue';
import SingleRecordView from '../views/SingleRecordView.vue';
import SingleSingleView from '../views/SingleSingleView.vue';
import RandomSingleView from '../views/RandomSingleView.vue';

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */
const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView,
    meta: {
      requiresAuth: false
    }
  },
  {
    path: "/login",
    name: "login",
    component: LoginView,
    meta: {
      requiresAuth: false
    }
  },
  {
    path: "/logout",
    name: "logout",
    component: LogoutView,
    meta: {
      requiresAuth: false
    }
  },
  {
    path: "/register",
    name: "register",
    component: RegisterView,
    meta: {
      requiresAuth: false
    }
  },
  {
    path: "/records/random",
    name: "RandomRecord",
    component: RandomRecordView,
    meta: {
      requiresAuth: false
    }
  },
  {
    path: "/singles/random",
    name: "RandomSingle",
    component: RandomSingleView,
    meta: {
      requiresAuth: false
    }
  },
  {
    path: "/add",
    name: "AddRecord",
    component: AddRecordView,
    meta: {
      requiresAuth: false
    }
  },
  {
    path: "/records",
    name: "AllRecords",
    component: AllRecordsView,
    meta: {
      requiresAuth: false,
    }
  },
  // {
  //   path: "/records/:artist/:title",
  //   name: "SingleRecord",
  //   component: SingleRecordView,
  //   meta: {
  //     requiresAuth: false
  //   }
  // },
  {
    path: "/records/record",
    name: "SingleRecord1",
    component: SingleRecordView,
    meta: {
      requiresAuth: false
    }
  },
  {
    path: "/singles/:artist/:title",
    name: "SingleSingle",
    component: SingleSingleView,
    meta: {
      requiresAuth: false
    }
  },
  {
    path: "/singles/single",
    name: "SingleSingle1",
    component: SingleSingleView,
    meta: {
      requiresAuth: false
    }
  }
];

// Create the router
const router = createRouter({
  history: createWebHistory(),
  routes: routes
});

router.beforeEach((to) => {

  // Get the Vuex store
  const store = useStore();

  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === '') {
    return {name: "login"};
  }
  // Otherwise, do nothing and they'll go to their next destination
});

export default router;
