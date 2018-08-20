
import Vue from 'vue'
import Vuex from 'vuex'
import auth from './modules/auth'
import user from './modules/user'

Vue.use(Vuex);

const store = () => new Vuex.Store({

  state: {
    pageName:''
  },
  modules:{
    auth,
    user
  },
  mutations:{
    setPageName(state, page){
      state.pageName = page
    }
  }
});

export default store
