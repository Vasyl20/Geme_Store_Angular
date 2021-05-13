import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../Models/api.response';
import { LoginModel } from '../Models/login.model';
import { RegisterModel } from '../Models/register.model';
import jwt_decode from "jwt-decode";
import { trigger } from '@angular/animations';
import { Game } from '../Models/games';


@Injectable()

export class ServiceGame {
   private url = "/api/games";

   constructor(private http: HttpClient) {

   }

   getGames() {
    return this.http.get(this.url)
   }

   getGame(id: number) {
       return this.http.get(this.url + '/' + id);
   }

   createGame(game: Game) {
       return this.http.post(this.url,game);
   }

   updateGame(game: Game) {
       return this.http.put(this.url, game);
   }

}