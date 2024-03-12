import { createStore as _createStore } from 'vuex';
import axios from 'axios';

export function createStore(currentToken, currentUser) {
  let store = _createStore({
    state: {
      token: currentToken || '',
      user: currentUser || {},
      currentRecord: [],
      currentSingle: [],
      records: [],
      singles: []
    },
    mutations: {
      SET_AUTH_TOKEN(state, token) {
        state.token = token;
        localStorage.setItem('token', token);
        axios.defaults.headers.common['Authorization'] = `Bearer ${token}`;
      },
      SET_USER(state, user) {
        state.user = user;
        localStorage.setItem('user', JSON.stringify(user));
      },
      LOGOUT(state) {
        localStorage.removeItem('token');
        localStorage.removeItem('user');
        state.token = '';
        state.user = {};
        axios.defaults.headers.common = {};
      },
      GET_RECORD(state, record) {
        state.currentRecord = record
      },
      GET_SINGLE(state, single) {
        state.currentSingle = single
      },
      GET_LIST_OF_RECORDS(state, recordsList) {
        state.records = recordsList
      },
      GET_LIST_OF_SINGLES(state, singlesList) {
        state.singles = singlesList
      }
    },
  });
  return store;
}
