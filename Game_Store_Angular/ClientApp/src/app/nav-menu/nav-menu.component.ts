import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../Services/Auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  isLoggedIn: boolean;
  isAdmin: boolean;

 constructor(
   private authService: AuthService,
   private router: Router
 ){
   this.isLoggedIn = this.authService.isLoggedIn();
   this.isAdmin = this.authService.isAdmin();

   this.authService.loginStatus.subscribe((status) => {
     this.isLoggedIn = status;
     this.isAdmin = this.authService.isAdmin();
   })
 }

  Logout() {
    this.authService.Logout();
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
