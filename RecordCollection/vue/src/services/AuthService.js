import axios from 'axios';

export default {

  login(user) {
    return axios.post('https://jakesrecordcollection.azurewebsites.net/login', user)
  },

  register(user) {
    return axios.post('https://jakesrecordcollection.azurewebsites.net/register', user)
  }

}
