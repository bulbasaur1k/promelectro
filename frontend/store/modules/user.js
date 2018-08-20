import { USER_REQUEST, USER_ERROR, USER_SUCCESS } from '../actions/user'
import Vue from 'vue'
import { AUTH_LOGOUT } from '../actions/auth'
import axios from "axios";
import apiUrl from '../../services/account.service'
const state = { status: '', profile: {} };

const getters = {
  profile: state => state.profile,
  isProfileLoaded: state => !!state.profile.name,
};

const actions = {
  [USER_REQUEST]: ({commit, dispatch}) => {
    commit(USER_REQUEST);
    console.log(apiUrl)
    axios.get(`${apiUrl.apiUrl}/user/me`)
      .then(resp => {
        console.log(axios.defaults.headers.common['Authorization']);
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
