import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Proizvod } from 'src/app/Modeli/Proizvod';

@Component({
  selector: 'app-dodajproizvod',
  templateUrl: './dodajproizvod.component.html',
  styleUrls: ['./dodajproizvod.component.css'],
})
export class DodajproizvodComponent implements OnInit {
  proizvodi: Proizvod[] = [];
  dodaajproizvodForma = new FormGroup({
    ime: new FormControl('', Validators.required),
    sastojci: new FormControl('', Validators.required),
    cena: new FormControl(0, [Validators.required, Validators.min(0)]),
  });
  dodajproizvod() {
    if (this.dodaajproizvodForma.valid) {
      let proizvod = new Proizvod();
      proizvod.ime = this.dodaajproizvodForma.controls['ime'].value;
      proizvod.sastojci = this.dodaajproizvodForma.controls['sastojci'].value;
      proizvod.price = this.dodaajproizvodForma.controls['cena'].value;

      // this.proizvodService.addProduct(proizvod).subscribe(
      //   (data: Proizvod) => {
      //     if (data === null) {
      //       //this.toastr.error('Proizvod nije dodat.');
      //     } else {
      //       console.log(data);
      //       this.proizvodi.unshift(proizvod);
      //       this.dodaajproizvodForma.controls['ime'].setValue('');
      //       this.dodaajproizvodForma.controls['sastojci'].setValue('');
      //       this.dodaajproizvodForma.controls['cena'].setValue('');
      //     }
      //   },
      //   (error) => {
      //     this.toastr.error('Nema proizvoda');
      //   }
      // );
      // this.alertError = '';
    } else {
      //this.alertError = 'Popunite pravilno sva polja za unos novog proizvoda.';
    }
  }

  constructor() // private router: Router, // private productService: ProductService,
  // private toastr: ToastrService
  {}

  ngOnInit(): void {
    // this.productService.getProducts().subscribe(
    //   (data: Proizvod[]) => {
    //     if (data === null) {
    //       this.toastr.error('Nema proizvoda dodatih.');
    //     } else {
    //       console.log(data);
    //       for (let i = 0; i < data.length; i++) {
    //         this.proizvodi.push(data[i]);
    //       }
    //     }
    //   },
    //   (error) => {
    //     this.toastr.error('Desila se neka greska.');
    //   }
    // );
  }
}
