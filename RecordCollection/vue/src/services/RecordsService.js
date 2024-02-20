import axios from 'axios';

export default {
    getRandomRecord() {
        return axios.get(`Records/random`)
    }
}