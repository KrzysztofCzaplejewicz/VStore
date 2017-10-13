import { Component, OnInit } from '@angular/core';
import { GenreService } from "../../services/genre.service";
import { SaveVideo, Video } from "../../models/video.interface";
import { VideoService } from "../../services/video.service";

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
    constructor(private genreService: GenreService, private videoService: VideoService) {
        this.genres$ = genreService.getGenres();
    }

    private setVideo(v: Video) {
        this.video.id = v.id;
        this.video.genreId = v.genre.id;
        this.video.price = v.price;
        this.video.quantity = v.quantity;
        this.video.title = v.title;
    }

    save(video: SaveVideo) {
        this.videoService.create(video).subscribe(x=> console.log(x));
    }
   
    ngOnInit(): void {
        var sources = [
            this.genreService.getGenres()
        ];
        if (this.video.id)
            sources.push(this.genreService.getGenres());
        
    }


}