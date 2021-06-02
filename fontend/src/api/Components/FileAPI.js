import BaseAPI from "../base";
import Axios from 'axios';
class FileAPI extends BaseAPI {
    constructor(){
        super();
        this.controller = "File"
    }
    async UploadFile(file){
        return  Axios.post(`https://localhost:44352/api/File/upload-file`, file,
        {
            headers: { 'Content-Type': 'multipart/form-data' }
        }).then(response => {
            return response;
        }).catch(error => {
            console.log(error);
        });;
    }
    async GetPersonal(param){
        return this.Post("/personal",param);
    }
}
export default new FileAPI();