import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Game } from '../Models/games';
import { AuthService } from '../Services/Auth.service';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.css']
})

export class AdminPanelComponent  {

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

