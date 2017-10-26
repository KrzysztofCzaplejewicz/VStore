import { Component, OnInit, Input } from '@angular/core';
import {GenreService} from "../../../services/genre.service";

@Component({
    selector: 'video-filter',
    templateUrl: './video.filter.component.html',
    styleUrls: ['./video.filter.component.css']
})
export class VideoFilterComponent implements OnInit
{
    genres$: any;
    @Input('genre') genre: any;
    constructor(private genreService: GenreService) {
        this.genres$ = genreService.getGenres();
    }

    ngOnInit(): void { }
}