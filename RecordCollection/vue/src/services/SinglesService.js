import axios from "axios";

export default {
    getRandomSingle() {
        return axios.get(`https://jakesrecordcollection.azurewebsites.net/Singles/random`)
    },
    getAllSingles() {
        return axios.get(`https://jakesrecordcollection.azurewebsites.net/Singles`)
    },
    addSingle(singleData) {
        return axios.post(`https://jakesrecordcollection.azurewebsites.net/Singles/add?fileAs=${singleData.file}&artist=${singleData.artist}&title=${singleData.title}
        &releaseYear=${singleData.releaseYear}&recordLabel=${singleData.label}&issueYear=${singleData.issueYear}
        &serialNumber=${singleData.serialNumber}&pressing=${singleData.pressing}&
        color=${singleData.color}&notes=${singleData.notes}`)
    },
    // getSingleSingle(single) {
    //     return axios.get(`/Singles/${single.artist}/${single.title}?serial=${single.serialNumber}&releaseYear=${single.releaseYear}&issueYear=${single.issueYear}`)
    // },
    getSingleSingle1(single) {
        return axios.get(`https://jakesrecordcollection.azurewebsites.net/Singles/Single?artist=${single.artist}&title=${single.title}&serial=${single.serialNumber}&releaseYear=${single.releaseYear}&issueYear=${single.issueYear}`)
    }

}