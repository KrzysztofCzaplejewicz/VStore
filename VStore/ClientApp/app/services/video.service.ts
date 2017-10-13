
import { Injectable } from '@angular/core';
import { Http } from "@angular/http";
import { SaveVideo } from "../models/video.interface";

@Injectable()
export class VideoService {
    constructor(private http: Http) { }
    create(video: SaveVideo) {
        return this.http.post("/api/videos", video).map(res => res.json());
    }
}
