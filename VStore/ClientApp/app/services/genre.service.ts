
import { Injectable } from '@angular/core';
import { Http } from "@angular/http";
import 'rxjs/add/operator/map';

@Injectable()
export class GenreService {

    constructor(private http: Http) { }

    getGenres() {
        return this.http.get('/api/genres').map(res => res.json());
    }
}
