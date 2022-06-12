import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Korisnik } from 'src/app/Modeli/Korisnik';
import { KorisnickiservisService } from 'src/app/Servisi/korisnickiservis.service';

@Component({
  selector: 'app-loginregistracija',
  templateUrl: './loginregistracija.component.html',
  styleUrls: ['./loginregistracija.component.css'],
})
export class LoginregistracijaComponent implements OnInit {
  greska: string = '';
  regg: boolean = false;
  logg: boolean = true;
  loginForma = new FormGroup({
    korisnickoime: new FormControl('', Validators.required),
    lozinka: new FormControl('', Validators.required),
  });
  url: string = '';
  registracijaForma = new FormGroup({
    korisnickoime: new FormControl('', Validators.required),
    email: new FormControl('', [Validators.required, Validators.email]),
    lozinka: new FormControl('', [
      Validators.required,
      Validators.minLength(4),
    ]),
    lozinka2: new FormControl('', [
      Validators.required,
      Validators.minLength(4),
    ]),
    ime: new FormControl('', Validators.required),
    prezime: new FormControl('', Validators.required),
    rodjenje: new FormControl('', Validators.required),
    adresa: new FormControl('', Validators.required),
    tipkorisnika: new FormControl('', Validators.required),
  });

  login() {
    if (this.loginForma.valid) {
      console.log('usaoooo');
      let login: Korisnik = new Korisnik();
      login.korime = this.loginForma.controls['korisnickoime'].value;
      login.lozinka = this.loginForma.controls['lozinka'].value;
      console.log('Login', login);
      this.greska = '';
      // this.service.login(login).subscribe(
      //   (data: Token) => {
      //     if (data === null) {
      //       this.toastr.error(
      //         'Incorrect korisnikname or password.',
      //         'Authentication failed.'
      //       );
      //     } else {
      //       console.log(data);
      //       //localStorage.setItem('token', data._Token);
      //       setToken(data._Token);
      //       this.service.checkDeliverStatus().subscribe(
      //         (data: Order) => {
      //           if (data === null) {
      //             this.router.navigateByUrl('/korisnik');
      //           } else {
      //             this.router.navigate(['/currentdel'], {
      //               state: { order: data },
      //             });
      //           }
      //         },
      //         (error) => {
      //           this.toastr.error('Desila se neka greska.');
      //         }
      //       );
      //     }
      //   },
      //   (error) => {
      //     this.toastr.error(
      //       'Incorrect korisnikname or password.',
      //       'Authentication failed.'
      //     );
      //   }
      // );
    } else {
      this.greska = 'Popunite pravilno polja.';
    }
  }
  onSelectFile(e: any) {
    if (e.target.files) {
      var reader = new FileReader();
      reader.readAsDataURL(e.target.files[0]);
      reader.onload = (event: any) => {
        this.url = event.target.result;
      };
    }
  }
  registracija() {
    let korisnik2: Korisnik = new Korisnik();
    korisnik2.korime = this.registracijaForma.controls['korisnickoime'].value;
    korisnik2.email = this.registracijaForma.controls['email'].value;
    korisnik2.lozinka = this.registracijaForma.controls['lozinka'].value;
    korisnik2.ime = this.registracijaForma.controls['ime'].value;
    korisnik2.prezime = this.registracijaForma.controls['prezime'].value;
    korisnik2.rodjenje = this.registracijaForma.controls['rodjenje'].value;
    korisnik2.adresa = this.registracijaForma.controls['adresa'].value;
    korisnik2.slika = this.url;
    korisnik2.tipkorisnika =
      this.registracijaForma.controls['tipkorisnika'].value;

    if (
      korisnik2.tipkorisnika == 'porucilac' ||
      korisnik2.tipkorisnika == 'admin'
    ) {
      korisnik2.statuskorisnika = 'prihvacen';
    } else {
      korisnik2.statuskorisnika = 'provera';
    }
    console.log(korisnik2);
    if (
      this.registracijaForma.valid &&
      this.url.length !== 0 &&
      this.registracijaForma.controls['lozinka'].value ===
        this.registracijaForma.controls['lozinka2'].value
    ) {
      this.greska = '';
      var givenDate = this.registracijaForma.controls['rodjenje'].value;
      var currentDate = new Date();
      givenDate = new Date(givenDate);
      if (givenDate < currentDate) {
        let korisnik: Korisnik = new Korisnik();
        korisnik.korime =
          this.registracijaForma.controls['korisnickoime'].value;
        korisnik.email = this.registracijaForma.controls['email'].value;
        korisnik.lozinka = this.registracijaForma.controls['lozinka'].value;
        korisnik.ime = this.registracijaForma.controls['ime'].value;
        korisnik.prezime = this.registracijaForma.controls['prezime'].value;
        korisnik.rodjenje = this.registracijaForma.controls['rodjenje'].value;
        korisnik.adresa = this.registracijaForma.controls['adresa'].value;
        korisnik.slika = this.url;
        korisnik.tipkorisnika =
          this.registracijaForma.controls['tipkorisnika'].value;

        if (
          korisnik.tipkorisnika == 'porucilac' ||
          korisnik.tipkorisnika == 'admin'
        ) {
          korisnik.statuskorisnika = 'prihvacen';
        } else {
          korisnik.statuskorisnika = 'provera';
        }
        console.log('Registracija', korisnik);
        this.korser.registracija(korisnik).subscribe(
          (data: Korisnik) => {
            console.log('Vraceni podaci' + data);
            this.router.navigateByUrl('/login');
          },
          () => {
            console.log();
          }
        );
      } else {
        this.greska = 'Datum mora biti stariji od danasnjeg.';
      }
    } else {
      this.greska = 'Popinite sva polja za unos. Lozinke se moraju poklapati.';
    }
  }
  reg() {
    this.logg = false;
    this.regg = true;
    console.log(this.logg, this.regg);
  }
  log() {
    this.logg = true;
    this.regg = false;
    console.log(this.logg, this.regg);
  }
  constructor(
    private korser: KorisnickiservisService,
    private router: Router //private toastr: ToastrService
  ) {}

  ngOnInit(): void {}
}
