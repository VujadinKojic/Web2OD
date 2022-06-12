import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Porudzbina } from 'src/app/Modeli/Porudzbina';
import { Proizvod } from 'src/app/Modeli/Proizvod';
import { ProizvodiPorudzbine } from 'src/app/Modeli/ProizvodiPorudzbine';

@Component({
  selector: 'app-novatrenutnaporudzbina',
  templateUrl: './novatrenutnaporudzbina.component.html',
  styleUrls: ['./novatrenutnaporudzbina.component.css'],
})
export class NovatrenutnaporudzbinaComponent implements OnInit {
  imatekucaporudzbina: boolean = true;
  trenutnaporudzbina: Porudzbina = new Porudzbina();

  proizvodi: Proizvod[] = [];
  porudzbina: Porudzbina = new Porudzbina();
  porudzbinaForma = new FormGroup({
    address: new FormControl('', Validators.required),
    comment: new FormControl('', Validators.required),
  });
  posaljiporudzbinu() {
    if (this.porudzbinaForma.valid) {
      if (this.porudzbina.proizvodi.length > 0) {
        this.porudzbina.adresa = this.porudzbinaForma.controls['address'].value;
        this.porudzbina.komentar =
          this.porudzbinaForma.controls['comment'].value;
        this.porudzbina.cena += 300;
        // this.porudzbinaService.addporudzbina(this.porudzbina).subscribe(
        //   (data: Porudzbina) => {
        //     console.log(data);
        //     if (data === null) {
        //       this.toastr.error('Neuspjesno poslata porudzbina.');
        //     } else {
        //       this.toastr.success('Porudzbina je na cekanju.');
        //     }
        //   },
        //   (error) => {
        //     this.toastr.error('Desila se neka greska pri konekciji.');
        //   }
        // );
        this.porudzbinaForma.controls['address'].setValue('');
        this.porudzbinaForma.controls['comment'].setValue('');
        this.porudzbina = new Porudzbina();
        //this.alertError = '';
      } else {
        //this.alertError = 'Morate nesto poruciti.';
      }
    } else {
      //this.alertError = 'Popunite adresu i komentar.';
    }
  }
  dodiajproizvod(id: Number) {
    console.log(id);
    for (let j = 0; j < this.porudzbina.proizvodi.length; j++) {
      if (this.porudzbina.proizvodi[j].id === id) {
        return;
      }
    }
    for (let i = 0; i < this.proizvodi.length; i++) {
      if (this.proizvodi[i].id === id) {
        let p = new ProizvodiPorudzbine();
        p.id = this.proizvodi[i].id;
        p.kolicina = 1;
        p.sastojci = this.proizvodi[i].sastojci;
        p.ime = this.proizvodi[i].ime;
        p.cena = this.proizvodi[i].cena;
        this.porudzbina.proizvodi.unshift(p);
        this.porudzbina.cena += p.cena;
      }
    }
  }
  smanjikolicinu(id: number) {
    for (let i = 0; i < this.porudzbina.proizvodi.length; i++) {
      if (this.porudzbina.proizvodi[i].id === id) {
        if (this.porudzbina.proizvodi[i].kolicina === 1) {
          this.porudzbina.cena -= this.porudzbina.proizvodi[i].cena;
          this.porudzbina.proizvodi.splice(i, 1);
          return;
        } else {
          this.porudzbina.proizvodi[i].kolicina =
            this.porudzbina.proizvodi[i].kolicina - 1;
          this.porudzbina.cena -= this.porudzbina.proizvodi[i].cena;

          return;
        }
      }
    }
  }
  povecajkolicinu(id: Number) {
    for (let i = 0; i < this.porudzbina.proizvodi.length; i++) {
      if (this.porudzbina.proizvodi[i].id === id) {
        this.porudzbina.proizvodi[i].kolicina =
          this.porudzbina.proizvodi[i].kolicina + 1;
        this.porudzbina.cena =
          this.porudzbina.cena + this.porudzbina.proizvodi[i].cena;
        return;
      }
    }
  }
  //TRENUTNA PORUDZBINA
  // getTime(str: string) {
  //   const myArray = str.split(' ');
  //   const date = myArray[0].split('/');
  //   const day = Number(date[1]);
  //   const month = Number(date[0]);
  //   const year = Number(date[2]);
  //   console.log('day ' + day + ' month ' + month + ' year ' + year);
  //   const time = myArray[1].split(':');
  //   const hours = Number(
  //     myArray[2] === 'PM' ? Number(time[0]) + 12 : Number(time[0])
  //   );
  //   const minutes = Number(time[1]);
  //   const seconds = Number(time[2]);
  //   console.log('sati ' + hours + ' minuti ' + minutes + ' sekunde ' + seconds);
  //   return new Date(year, month, day, hours, minutes, seconds);
  // }
  // startTimer() {
  //   let date: Date = this.getTime(this.trenutnaporudzbina.vremeprihvatanja);
  //   let nowDate: Date = new Date();
  //   console.log(nowDate.getHours(), date.getHours());
  //   console.log(this.trenutnaporudzbina.vremedostave);
  //   if (nowDate.getHours() === date.getHours()) {
  //     this.trenutnaporudzbina.vremedostave -=
  //       nowDate.getMinutes() - date.getMinutes();
  //   } else if (nowDate.getHours() > date.getHours()) {
  //     this.trenutnaporudzbina.vremedostave -= 60 - date.getMinutes();
  //     this.trenutnaporudzbina.vremedostave -= nowDate.getMinutes();
  //   }
  //   if (this.trenutnaporudzbina.vremedostave <= 0) {
  //     this.imatekucaporudzbina = false;
  //   }
  //   console.log('preostalo vrijeme: ', this.trenutnaporudzbina.deliverTime);
  //   this.timer.minutes = this.trenutnaporudzbina.deliverTime;
  //   //while (true) {
  //   // this.subscription = interval(1000).subscribe((x) => {
  //   //   if (this.timer.seconds - 1 <= -1) {
  //   //     this.timer.seconds = 59;
  //   //     this.timer.minutes -= 1;
  //   //   }
  //   //   if (this.timer.minutes === 0) {
  //   //     console.log('kraj');
  //   //   }
  //   // });

  //   let interval = setInterval(() => {
  //     if (this.timer.seconds > 0) {
  //       this.timer.seconds--;
  //     } else {
  //       if (this.timer.minutes === 0 && this.timer.seconds === 0) {
  //         clearInterval(interval);
  //         //this.toastr.success('Delivery finished.');
  //       } else {
  //         this.timer.seconds = 59;
  //         this.timer.minutes--;
  //       }
  //     }
  //   }, 1000);
  // }
  constructor() {}

  ngOnInit(): void {
    //   this.userService.checkDeliverStatus().subscribe(
    //     (data: Porudzbina) => {
    //       console.log(data);
    //       if (data === null) {
    //         this.imatekucaporudzbina = false;
    //         this.proizvodiervice.getproizvodi().subscribe(
    //           (data: Proizvod[]) => {
    //             console.log(data);
    //             if (data === null) {
    //               this.toastr.error('Nema proizvoda na stanju.');
    //             } else {
    //               for (let i = 0; i < data.length; i++) {
    //                 this.proizvodi.push(data[i]);
    //               }
    //             }
    //           },
    //           (error) => {
    //             this.toastr.error('Desila se neka greska.');
    //           }
    //         );
    //       } else {
    //         this.imatekucaporudzbina = true;
    //         this.trenutnaporudzbina = data;
    //       }
    //     },
    //     (error) => {
    //       this.toastr.error('Desila se neka greska.');
    //     }
    //   );
  }
}
