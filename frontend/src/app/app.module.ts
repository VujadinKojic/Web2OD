import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginregistracijaComponent } from './Komponente/loginregistracija/loginregistracija.component';
import { DodajproizvodComponent } from './Komponente/dodajproizvod/dodajproizvod/dodajproizvod.component';
import { VerifikacijaComponent } from './Komponente/verifikacija/verifikacija/verifikacija.component';
import {
  FormControl,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { PorudzbineComponent } from './Komponente/porudzbine/porudzbine/porudzbine.component';
import { NovatrenutnaporudzbinaComponent } from './Komponente/novatrenutnaporudzbina/novatrenutnaporudzbina/novatrenutnaporudzbina.component';
import { NoveporudzbineComponent } from './Komponente/noveporudzbine/noveporudzbine/noveporudzbine.component';
@NgModule({
  declarations: [
    LoginregistracijaComponent,
    DodajproizvodComponent,
    VerifikacijaComponent,
    AppComponent,
    PorudzbineComponent,
    NovatrenutnaporudzbinaComponent,
    NoveporudzbineComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, ReactiveFormsModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
