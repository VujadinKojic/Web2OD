import { Component, OnInit } from '@angular/core';
import { Porudzbina } from 'src/app/Modeli/Porudzbina';

@Component({
  selector: 'app-noveporudzbine',
  templateUrl: './noveporudzbine.component.html',
  styleUrls: ['./noveporudzbine.component.css'],
})
export class NoveporudzbineComponent implements OnInit {
  neprihvaceneporudzbine: Porudzbina[] = [];
  prihvati(id: number) {}
  constructor() {}

  ngOnInit(): void {}
}
