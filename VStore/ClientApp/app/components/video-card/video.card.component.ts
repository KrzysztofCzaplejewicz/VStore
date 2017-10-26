import { Component, Input } from '@angular/core';
import {Video} from "../../models/video.interface";

@Component({
    selector: 'video-card',
    templateUrl: './video.card.component.html',
    styleUrls: ['./video.card.component.css']
})
export class VideoCardComponent 
{
    @Input('video') video: Video;
    @Input('show-actions') showActions = true;
    constructor() { }

   
}