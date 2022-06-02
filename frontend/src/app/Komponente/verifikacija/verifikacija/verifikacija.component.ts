import { Component, OnInit } from '@angular/core';
import { Korisnik } from 'src/app/Modeli/Korisnik';

@Component({
  selector: 'app-verifikacija',
  templateUrl: './verifikacija.component.html',
  styleUrls: ['./verifikacija.component.css'],
})
export class VerifikacijaComponent implements OnInit {
  korisnici: Korisnik[] = [];
  // verifikuj(id: number, accountStatus: string) {
  //   console.log('id', id);
  //   this.userService.verificateUser(id, accountStatus).subscribe(
  //     (data: Korisnik) => {
  //       console.log(data);
  //       if (data === null) {
  //         //this.toastr.error('Nema korisnika.');
  //       } else {
  //         for (let i = 0; i < this.korisnici.length; i++) {
  //           if (data.id === this.korisnici[i].id) {
  //             this.korisnici[i].statuskorisnika = data.statuskorisnika;
  //             return;
  //           }
  //         }
  //       }
  //     },
  //     (error) => {
  //       this.toastr.error('Desila se neka greska.');
  //     }
  //   );
  // }
  constructor() {}

  ngOnInit(): void {
  //   this.userService.getUsers().subscribe(
  //     (data: Korisnik[]) => {
  //       console.log(data);
  //       if (data === null) {
  //         this.toastr.error('Nema korisnika.');
  //       } else {
  //         for (let i = 0; i < data.length; i++) {
  //           console.log(data[i]);
  //           this.korisnici.push(data[i]);
  //         }
  //       }
  //     },
  //     (error) => {
  //       this.toastr.error('Desila se neka greska.');
  //     }
  //   );
  // }
}
