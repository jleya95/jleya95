import axios from 'axios';

export default {
    getRandomRecord() {
        return axios.get(`/Records/random`)
    },
    addRecord(recordData) {
        return axios.post(`/Records/add?fileAs=${recordData.file}&artist=${recordData.artist}&title=${recordData.title}
        &releaseYear=${recordData.releaseYear}&recordLabel=${recordData.label}&issueYear=${recordData.issueYear}
        &serialNumber=${recordData.serialNumber}&pressing=${recordData.pressing}&discNumber=${recordData.discNumber}
        &color=${recordData.color}&notes=${recordData.notes}&needleInfo=${recordData.needleInfo}`)
    },
    getAllRecords() {
        return axios.get('/Records')
    },
    // getSingleRecord(record) {
    //     return axios.get(`/Records/${record.artist}/${record.title}?serial=${record.serialNumber}&releaseYear=${record.releaseYear}&issueYear=${record.issueYear}`)
    // },
    getSingleRecord1(record) {
        return axios.get(`/Records/Record?artist=${record.artist}&title=${record.title}&serial=${record.serialNumber}&releaseYear=${record.releaseYear}&issueYear=${record.issueYear}`)
    }

}