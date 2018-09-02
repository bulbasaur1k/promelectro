import {AUTH_REQUEST, AUTH_ERROR, AUTH_SUCCESS, AUTH_LOGOUT, REG_REQUEST} from '../actions/auth';
import {USER_REQUEST} from '../actions/user';
import {apiUrl} from '../../services/account.service'
import axios from 'axios'

const state = {
  token: process.browser ? localStorage.getItem('token') ? localStorage.getItem('token') : '' : '',
  status: '',
  hasLoadedOnce: false
};

const getters = {
  isAuthenticated: state => !!state.token,
  authStatus: state => state.status
};

const actions = {
  [AUTH_REQUEST]: ({commit, dispatch}, user) => {
    console.log(state.token);
    return new Promise(((resolve, reject) => {
      commit(AUTH_REQUEST);
     
      axios({url: `${apiUrl}/auth/login`, data: user, method: 'POST'})
        .then(resp => {
          console.log(resp.data);
          console.log(resp.data.token);
          const token = resp.data.token;
          if (process.browser) {
            localStorage.setItem('user-token', token);
          }
          commit(AUTH_SUCCESS, token);
          commit(USER_REQUEST);
          resolve(resp);
        })
        .catch(err => {
          commit(AUTH_ERROR, err);
          if (process.browser) {
            localStorage.removeItem('user-token')
          }
          reject(err)
        })
    }))
  },
  [REG_REQUEST]: ({commit, dispath}, regData )=>{
    console.log(state.token);
    return new Promise(((resolve, reject) => {
      commit(REG_REQUEST);
      axios({url: `${apiUrl}/auth/register`})
    }))
  },
  [AUTH_LOGOUT]: ({commit, dispatch}) => {
    return new Promise(((resolve, reject) => {
      commit(AUTH_LOGOUT);
      if (process.browser) {
        localStorage.removeItem('user-token');
      }
      resolve()
    }))
  }
};

const mutations = {
  [AUTH_REQUEST]: (state) => {
    state.status = 'loading';
  },
  [REG_REQUEST]: (state) => {
    state.status = 'loading';
  },
  [AUTH_SUCCESS]: (state, token) => {
    axios.defaults.headers.Authorization = `Bearer ${token}`;
    state.status = 'success';
    state.token = token;
    state.hasLoadedOnce = true;
  },
  [AUTH_ERROR]: (state) => {
    state.status = 'error';
    state.hasLoadedOnce = true;
  },
  [AUTH_LOGOUT]: (state) => {
    state.token = ''
  }
};

export default {
  state,
  getters,
  actions,
  mutations,
}
