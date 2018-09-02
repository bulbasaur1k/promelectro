import { USER_REQUEST, USER_ERROR, USER_SUCCESS } from '../actions/user'
import Vue from 'vue'
import { AUTH_LOGOUT } from '../actions/auth'
import apiUrl from '../../services/account.service'
import axios from 'axios'

const state = { status: '', profile: {} };


const getters = {
  profile: state => state.profile,
  isProfileLoaded: state => !!state.profile.name,
};

const actions = {
  [USER_REQUEST]: ({commit, dispatch}) => {
    commit(USER_REQUEST);
    console.log(apiUrl);
    if (process.browser) {
      const token = localStorage.getItem('user-token');
      console.log(`axios plugin ${token}`);
      if(token){
        axios.defaults.headers.common = {
          'Authorization': `Bearer ${token}`
      }
       // axios.headers.common['Authorization'] = `Bearer ${token}`;
      }
    }
    axios({url: `${apiUrl}/user/me`, method: 'GET'})
      .then(resp => {
        console.log(resp);
        commit(USER_SUCCESS, resp.data)
      })
      .catch(err => {
        console.log(`Vuex user USER_REQUEST Err: ${err}`);
        commit(USER_ERROR);
        // if resp is unauthorized, logout, to
       // dispatch(AUTH_LOGOUT)
      })
  }
};

const mutations = {
  [USER_REQUEST]: (state) => {
    state.status = 'loading'
  },
  [USER_SUCCESS]: (state, resp) => {
    state.status = 'success';
    Vue.set(state, 'profile', resp)
  },
  [USER_ERROR]: (state) => {
    state.status = 'error'
  },
  [AUTH_LOGOUT]: (state) => {
    state.profile = {}
  }
};

export default {
  state,
  getters,
  actions,
  mutations,
}
