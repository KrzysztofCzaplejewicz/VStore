import { Component, OnInit } from '@angular/core';
import { Video } from "../../models/video.interface";
import { VideoService } from "../../services/video.service";
import { ActivatedRoute } from "@angular/router";
import 'rxjs/add/operator/switchMap';


@Component({
    selector: 'videos',
    templateUrl: './videos.component.html',
    styleUrls: ['./videos.component.css']
})
/** videos component*/
export class VideosComponent implements OnInit {
    videos: Video[] = [];
    filteredVideos: Video[] = [];
    genre: any;

    constructor(
        private videoService: VideoService,
        private route: ActivatedRoute) {

        videoService
            .getAllVideos()
            .switchMap(videos => {
                this.videos = videos;
                return route.queryParamMap;
            })
            .subscribe(params => {
                // ReSharper disable once TsResolvedFromInaccessibleModule
                this.genre = params.get('genre');

                this.filteredVideos = (this.genre) ?
                    this.videos.filter(v => v.genre.name === this.genre) :
                    this.videos;
            });
    }


    ngOnInit(): void { }
}