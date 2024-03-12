import axios from "axios";

export default {
    getRandomSingle() {
        return axios.get(`/Singles/random`)
    },
    getAllSingles() {
        return axios.get(`/Singles`)
    }
}