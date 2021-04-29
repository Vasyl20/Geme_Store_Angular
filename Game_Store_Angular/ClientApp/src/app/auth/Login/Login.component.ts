import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NotifierService } from 'angular-notifier';
import { LoginModel } from 'src/app/Models/login.model';
import { RegisterModel } from 'src/app/Models/register.model';
import { AuthService } from 'src/app/Services/Auth.service';
import jwt_decode from "jwt-decode";
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-Login',
  templateUrl: './Login.component.html',
  styleUrls: ['./Login.component.css']
})
export class LoginComponent implements OnInit {

    constructor(
      private notifier: NotifierService,
      private router: Router,
      private authService: AuthService,
      private spinner: NgxSpinnerService
    ) { }
  
    model = new LoginModel();
    token_data: any;
  
  
    submitLogin() {
      this.spinner.show();
      if(!this.model.isValid()) {
        this.notifier.notify("error","Please, enter all fields!")
      }
      else if(!this.model.isEmail()) {
         this.notifier.notify("error", "Please, enter correct email!")
      }
      else{
        this.authService.login(this.model).subscribe(data => {
          console.log(data)
          if(data.code == 200){
            this.notifier.notify("success", "You success register in system!");
            localStorage.setItem("togen", data.token);
            
            this.authService.loginStatus.emit(true);

            this.token_data = jwt_decode(data.token);

            if(this.token_data.roles == "Admin") {
                this.router.navigate(['/admin-panel'])
            }
            else if(this.token_data.roles == "User") {
                this.router.navigate(['/user-profile'])
            }
            this.spinner.hide();
               
          } else {
            this.spinner.hide();
            for(var i = 0; i < data.errors.length; i++) {
               this.notifier.notify("error", data.errors[i]);
            }
          }
        })
      }
    
    }

  ngOnInit() {
  }

}
