import { Component, OnInit } from '@angular/core';
import { Porudzbina } from 'src/app/Modeli/Porudzbina';

@Component({
  selector: 'app-porudzbine',
  templateUrl: './porudzbine.component.html',
  styleUrls: ['./porudzbine.component.css'],
})
export class PorudzbineComponent implements OnInit {
  porudzbine: Porudzbina[] = [];
  constructor() {}

  ngOnInit(): void {
    //  this.orderService.getUserOrders().subscribe(
    //    (data: Order[]) => {
    //      console.log(data);
    //      if (data === null) {
    //        this.toastr.error('Nema porudzbina.');
    //      } else {
    //        for (let i = 0; i < data.length; i++) {
    //          this.orders.push(data[i]);
    //        }
    //      }
    //    },
    //    (error) => {
    //      this.toastr.error('Desila se neka greska.');
    //    }
    //  );
  }
}
