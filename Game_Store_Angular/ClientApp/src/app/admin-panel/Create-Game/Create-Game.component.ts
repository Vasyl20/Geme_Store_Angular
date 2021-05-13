import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Game } from 'src/app/Models/games';
import { ServiceGame } from 'src/app/Services/ServiceGame';

@Component({
  selector: 'Create-Game',
  templateUrl: './Create-Game.component.html',
  styleUrls: ['./Create-Game.component.css']
})
export class CreateGameComponent implements OnInit {

  constructor(private DataService: ServiceGame, private router: Router) {}
  ngOnInit() {
  }
  
  game: Game = new Game();
  save() {
      this.DataService.createGame(this.game).subscribe(data => this.router.navigateByUrl("game-create"));
  }


}
