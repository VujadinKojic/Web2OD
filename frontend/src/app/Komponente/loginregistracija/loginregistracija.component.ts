import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Korisnik } from 'src/app/Modeli/Korisnik';

@Component({
  selector: 'app-loginregistracija',
  templateUrl: './loginregistracija.component.html',
  styleUrls: ['./loginregistracija.component.css'],
})
export class LoginregistracijaComponent implements OnInit {
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
      console.log('nije usao');
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
  registrecija() {
    if (
      this.registracijaForma.valid &&
      this.url.length !== 0 &&
      this.registracijaForma.controls['lozinka'].value ===
        this.registracijaForma.controls['lozinka2'].value
    ) {
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
        //     this.service.register(korisnik).subscribe(
        //       (data) => {
        //         console.log('Vraceni podaci' + data);
        //         this.router.navigateByUrl('/login');
        //       },
        //       (error) => {
        //         this.toastr.error('Desila se neka greska.');
        //       }
        //     );
        //   }
        // } else {
        //   this.alertError = 'Popunite pravilno sve parametre za registraciju.';
        // }
      }
    }
  }

  constructor(
    //private service: UserService,
    private router: Router //private toastr: ToastrService
  ) {}

  ngOnInit(): void {}
}
