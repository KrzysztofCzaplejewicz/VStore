import { Component, OnInit } from '@angular/core';
import { GenreService } from "../../services/genre.service";
import { SaveVideo, Video, UpdateVideo } from "../../models/video.interface";
import { VideoService } from "../../services/video.service";
import { ActivatedRoute, Router } from "@angular/router";
import 'rxjs/add/operator/take';

@Component({
    selector: 'app-video-form',
    templateUrl: './video.form.component.html',
    styleUrls: ['./video.form.component.css']
})

export class VideoFormComponent implements OnInit
{
    genres$: any;
    video: SaveVideo = {
        id: 0,
        genreId: 0,
        price: 0,
        quantity: 0,
        title: ''
    }
    videos: Video;
    videoTest = {};
    id: any;

    constructor(
        private genreService: GenreService,
        private videoService: VideoService,
        private route: ActivatedRoute,
        private router: Router,
    )
    {
        this.genres$ = genreService.getGenres();

       this.id = this.route.snapshot.paramMap.get("id");
       if (this.id) this.videoService.get(this.id).take(1).subscribe(v => this.video = v);

      
    }

    private setVideo(v: Video) {
        this.video.id = v.id;
        this.video.genreId = v.genre.id;
        this.video.price = v.price;
        this.video.quantity = v.quantity;
        this.video.title = v.title;
    }
    delete() {
        if (this.id) this.videoService.delete(this.id).subscribe(x => console.log(x));

        this.router.navigate(['/video']);

    }

    save(video: UpdateVideo | SaveVideo) {
        if (this.id) this.videoService.update(this.id, video).subscribe(x => console.log(x));
        else this.videoService.create(video).subscribe(x => console.log(x));

        this.router.navigate(['/video']);
    }
   
    ngOnInit(): void {
        var sources = [
            this.videoService.getAllVideos()
        ];
        if (this.video.id)
            sources.push(this.videoService.get(this.video.id));
        
    }


}