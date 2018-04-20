import { Injectable } from "@angular/core";
import { HttpClient, HttpHandler } from "@angular/common/http";
//import { HttpClientModule } from "@angular/common/http";

@Injectable()
export class ApiService {

    swapi: HttpClient

    constructor(client: HttpClient) {
        this.swapi = client;
    }

    getSwapi(id: number) {
        this.swapi.get("https://swapi.co/api/people/" + id.toString()).toPromise().then(this.pass, this.fail);
        //this.swapi[id];
    }

    pass(response: any) {
        console.log(response);
    }

    fail(response: any) {
        console.log(response);
    }

}