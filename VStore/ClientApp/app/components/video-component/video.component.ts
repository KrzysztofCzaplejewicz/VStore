import { Component, OnInit, OnDestroy } from '@angular/core';
import { VideoService } from "../../services/video.service";
import { VideoArr, Video } from "../../models/video.interface";
import { Subscription } from "rxjs/Subscription";
import { DataTableResource } from "angular-4-data-table-bootstrap-4/dist";


@Component({
    selector: 'app-video-component',
    templateUrl: './video.component.html',
    styleUrls: ['./video.component.css']
})
/** video-component component*/
export class VideoComponent implements OnInit, OnDestroy {
    videos: VideoArr[];
    subscription: Subscription;
    tableResource: DataTableResource<VideoArr>;
    items: VideoArr[] = [];
    itemCount: number;

    constructor(private videoService: VideoService) {
        this.subscription = this.videoService.getAllVideos()
            .subscribe(videos => {
                this.videos = videos;

                this.initializeTable(videos);
            });
    }

    private initializeTable(videos: VideoArr[]) {

        this.tableResource = new DataTableResource(videos);
        this.tableResource.query({ offset: 0 })
            .then(items => this.items = items);
        this.tableResource.count()
            .then(count => this.itemCount = count);
    }

    reloadItems(params: any) {
        if (!this.tableResource) return;

        this.tableResource.query(params)
            .then(items => this.items = items);
    }

    filter(query: string) {
        let filteredVideos = (query) ?
            this.videos.filter(v => v.title.toLowerCase().includes(query.toLowerCase())) :
            this.videos;

        this.initializeTable(filteredVideos);
    }

    ngOnDestroy() {
        this.subscription.unsubscribe();
    }

    ngOnInit(): void { }
}