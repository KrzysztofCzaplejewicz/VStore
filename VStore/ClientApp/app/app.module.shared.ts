import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { CustomFormsModule } from 'ng2-validation';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { LoginFormComponent } from "./components/login-form/login.form.component";
import { VideoFormComponent } from "./components/video-form/video.form.component";
import { VideoComponent } from "./components/video-component/video.component";
import { DataTableModule } from "angular-4-data-table-bootstrap-4";
import { VideosComponent } from "./components/videos/videos.component";
import {VideoFilterComponent} from "./components/videos/video-filter/video.filter.component";
import {VideoCardComponent} from "./components/video-card/video.card.component";


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        LoginFormComponent,
        VideoFormComponent,
        VideoComponent,
        VideosComponent,
        VideoFilterComponent,
        VideoCardComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        CustomFormsModule,
        DataTableModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'videos', pathMatch: 'full' },
            { path: 'login', component: LoginFormComponent },
            { path: 'video/new', component: VideoFormComponent },
            { path: 'video/:id', component: VideoFormComponent },
            { path: 'video', component: VideoComponent },
            { path: 'videos', component: VideosComponent },
            { path: '**', redirectTo: 'videos' }
        ])
    ]
})
export class AppModuleShared {
}
