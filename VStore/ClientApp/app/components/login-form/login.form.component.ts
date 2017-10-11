import { Component, OnInit } from '@angular/core';
import { AuthService } from "../../auth/auth.service";


@Component({
    selector: 'app-login-form',
    templateUrl: './login.form.component.html',
    styleUrls: ['./login.form.component.css']
})
/** login-form component*/
export class LoginFormComponent implements OnInit
{
    constructor(public auth: AuthService) {
        auth.handleAuthentication();
    }

    /** Called by Angular after login-form component initialized */
    ngOnInit(): void { }
}