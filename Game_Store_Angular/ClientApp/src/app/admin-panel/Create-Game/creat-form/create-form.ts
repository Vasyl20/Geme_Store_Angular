import { Component, Input, OnInit } from '@angular/core';
import { Game } from 'src/app/Models/games';

@Component({
  selector: 'game-create',
  templateUrl: './create-form.html',
})
export class GameCreateComponent  {

  @Input() game: Game;
  constructor() { }

  ngOnInit() {
  }

}