import axios from "axios";

export default {
    searchDiscogsForRecord(record){
        return axios.get(`https://jakesrecordcollection.azurewebsites.net/API/search?title=${record.title}&artist=${record.artist}&label=${record.label}&releaseYear=${record.releaseYear}&issueYear=${record.issueYear}&serial=${record.serialNumber}`)
    }
}