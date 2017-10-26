
import { Injectable } from '@angular/core';
import { Http } from "@angular/http";
import { SaveVideo, UpdateVideo } from "../models/video.interface";

@Injectable()
export class VideoService {
    constructor(private http: Http) { }
    create(video: SaveVideo) {
        return this.http.post("/api/videos", video).map(res => res.json());
    }
    getAllVideos() {
        return this.http.get("/api/videos").map(res => res.json());
    }
    get(id: any) {
        return this.http.get("/api/videos/" + id).map(res => res.json());
    }
    update(videoId: any, video: SaveVideo) {
        return this.http.put("/api/videos/" + videoId, video).map(res => res.json());
    }
    delete(id: any) {
        return this.http.delete("/api/videos/" + id).map(res => res.json());
    }
}
