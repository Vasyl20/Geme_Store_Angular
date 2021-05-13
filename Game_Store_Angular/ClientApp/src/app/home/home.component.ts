import { Component, OnInit } from '@angular/core';
import { Game } from '../Models/games';
import { ServiceGame } from '../Services/ServiceGame';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  game: Game[];
  constructor(private serviceGame: ServiceGame) {}

  ngOnInit() {
    this.load();
  }

  load() {
    this.serviceGame.getGames().subscribe((data: Game[]) => this.game = data);
  }

}
