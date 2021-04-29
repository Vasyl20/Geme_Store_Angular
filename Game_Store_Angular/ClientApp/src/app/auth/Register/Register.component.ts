import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NotifierService } from 'angular-notifier';
import { RegisterModel } from 'src/app/Models/register.model';
import { AuthService } from 'src/app/Services/Auth.service';

@Component({
  selector: 'app-Register',
  templateUrl: './Register.component.html',
  styleUrls: ['./Register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(
    private notifier: NotifierService,
    private router: Router,
    private authService: AuthService
  ) { }

  confirmPassword: string;
  model = new RegisterModel();


  subitRegister() {
    console.log(this.model)
    if(!this.model.isValid()) {
      this.notifier.notify("error","Please, enter all fields!")
    }
    else if(this.confirmPassword != this.model.Password) {
      this.notifier.notify("error", "Password dont't match!")
    }
    else if(!this.model.isEmail()) {
       this.notifier.notify("error", "Please, enter correct email!")
    }
    else{
      this.authService.register(this.model).subscribe(data => {
        console.log(data)
        if(data.code == 200){
          this.notifier.notify("success", "You success register in system!");
          this.router.navigate(['/login'])
        } else {
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
