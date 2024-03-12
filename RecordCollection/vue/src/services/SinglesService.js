import axios from "axios";

export default {
    getRandomSingle() {
        return axios.get(`/Singles/random`)
    },
    getAllSingles() {
        return axios.get(`/Singles`)
    },
    addSingle(singleData) {
        return axios.post(`/Singles/add?fileAs=${singleData.file}&artist=${singleData.artist}&title=${singleData.title}
        &releaseYear=${singleData.releaseYear}&recordLabel=${singleData.label}&issueYear=${singleData.issueYear}
        &serialNumber=${singleData.serialNumber}&pressing=${singleData.pressing}&
        color=${singleData.color}&notes=${singleData.notes}`)
    },
    getSingleRecord(record) {
        return axios.get(`/Records/${record.artist}/${record.title}?serial=${record.serialNumber}&releaseYear=${record.releaseYear}&issueYear=${record.issueYear}`)
    },
    getSingleSingle(single) {
        return axios.get(`/Singles/${single.artist}/${single.title}?serial=${single.serialNumber}&releaseYear=${single.releaseYear}&issueYear=${single.issueYear}`)
    }
}