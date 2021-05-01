import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../Models/api.response';
import { LoginModel } from '../Models/login.model';
import { RegisterModel } from '../Models/register.model';
import jwt_decode from "jwt-decode";


@Injectable({
  providedIn: 'root'
})
export class AuthService {


constructor(private http: HttpClient) { }

currect_token: any;
token_data: any;
baseUrl = "/api/Account";
loginStatus = new EventEmitter<boolean>();

register(model: RegisterModel): Observable<ApiResponse> {
  return this.http.post<ApiResponse>(this.baseUrl + "/register", model)
}

login(model: LoginModel): Observable<ApiResponse> {
  return this.http.post<ApiResponse>(this.baseUrl + "/login", model)
}

isAdmin(): boolean {
  this.currect_token = localStorage.getItem('token');

   if(this.currect_token != null) {
     this.currect_token = jwt_decode(this.currect_token);
     if(this.currect_token.roles == "Admin") {
       return true;
     } else {
       return false;
     }
   } else {
       return false;
   }
  }
    isLoggedIn(): boolean {
      this.currect_token = localStorage.getItem('token');

     if(this.currect_token != null) {
       return true;
     } else {
       return false;
     }
   }
   
  
   Logout() {
     this.loginStatus.emit(false);
    localStorage.removeItem('token');
   }
}
                                               