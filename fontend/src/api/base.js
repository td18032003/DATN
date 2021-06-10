import Axios from 'axios';
import store from "@/store/index.js";
export default class BaseAPI{
    constructor(){
        this.store = store;
    }
    api = "https://localhost:44352/api/"

    controller = ""

    async Get(route){
        var res =  await Axios.get(this.api + this.controller + route)
        return res
    }

    async PostNotAuthen(route,data){
        return await Axios.post(this.api + this.controller + route, data,
        {
            headers: { 'Content-Type': "application/json" }
        }).then(response => {
            return response;
        }).catch(error => {
            console.log(error);
        });;
    }
    async Post(route,data){
        debugger
        return await Axios.post(this.api + this.controller + route, data,
            {
                headers: { Authorization: `Bearer ${this.store.getters.token}` }
            }).then(response => {
                return response;
            }).catch(error => {
                console.log(error);
            });;
    }

    async Delete(id){
        var res =  await Axios.delete(this.api + this.controller + `/${id}`);
        return res;
    }

    async Insert(data){
        var res =  await Axios.post(this.api + this.controller + "/insert", data);
        return res;
    }

    async Update(data){
        var res =  await Axios.post(this.api + this.controller + "/update", data);
        return res;
    }

    //Hàm get ALL
    async GetAll(){
        return  await Axios.get(this.api + this.controller + "/get-all");
    }
}
