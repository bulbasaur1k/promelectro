
import Vue from 'vue'
import Vuex from 'vuex'
import auth from './modules/auth'
import user from './modules/user'
import axios from "axios";

Vue.use(Vuex);

const store = () => {
  return new Vuex.Store({

    state: {
      pageName: ''
    },
    modules: {
      auth,
      user
    },
    actions: {
      nuxtServerInit ({ commit }, { req }) {
        console.log('show server init')
        if (process.browser) {
          const token = localStorage.getItem('user-token');
          console.log(`axios plugin ${token}`);
          if(token){
            $axios.headers.common['Authorization'] = `Bearer ${token}`;
            axios.headers.common['Authorization'] = `Bearer ${token}`;
          }
        }
      }
    },
    mutations: {
      setPageName(state, page) {
        state.pageName = page
      }
    }
  });
};

export default store
