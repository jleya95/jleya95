import axios from 'axios';

export default {
    getRandomRecord() {
        return axios.get(`https://jakesrecordcollection.azurewebsites.net/Records/random`)
    },
    addRecord(recordData) {
        return axios.post(`https://jakesrecordcollection.azurewebsites.net/Records/add?fileAs=${recordData.file}&artist=${recordData.artist}&title=${recordData.title}
        &releaseYear=${recordData.releaseYear}&recordLabel=${recordData.label}&issueYear=${recordData.issueYear}
        &serialNumber=${recordData.serialNumber}&pressing=${recordData.pressing}&discNumber=${recordData.discNumber}
        &color=${recordData.color}&notes=${recordData.notes}&needleInfo=${recordData.needleInfo}`)
    },
    getAllRecords() {
        return axios.get('https://jakesrecordcollection.azurewebsites.net/Records')
    },
    // getSingleRecord(record) {
    //     return axios.get(`/Records/${record.artist}/${record.title}?serial=${record.serialNumber}&releaseYear=${record.releaseYear}&issueYear=${record.issueYear}`)
    // },
    getSingleRecord1(record) {
        return axios.get(`https://jakesrecordcollection.azurewebsites.net/Records/Record?artist=${record.artist}&title=${record.title}&serial=${record.serialNumber}&releaseYear=${record.releaseYear}&issueYear=${record.issueYear}`)
    }

}