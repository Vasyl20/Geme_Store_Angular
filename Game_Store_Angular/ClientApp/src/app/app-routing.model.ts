import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule, CanActivate } from '@angular/router';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { LoginComponent } from './auth/Login/Login.component';
import { RegisterComponent } from './auth/Register/Register.component';
import { AdminGuard } from './Guards/admin.guard';
import { NotLogetInGuard } from './Guards/inNotLogin.guard';
import { UserGuard } from './Guards/user.guard';
import { HomeComponent } from './home/home.component';
import { UserProfileComponent } from './user-profile/user-profile.component';

const routes: Routes = [

    { path: '', component: HomeComponent, pathMatch: 'full' },
    { path: 'login',canActivate: [NotLogetInGuard], component: LoginComponent },
    { path: 'register', canActivate: [NotLogetInGuard], component: RegisterComponent },
    { path: 'admin-panel',  canActivate: [AdminGuard], component: AdminPanelComponent },
    { path: 'user-profile',  canActivate:[UserGuard], component: UserProfileComponent },

];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }