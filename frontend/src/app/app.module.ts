import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginregistracijaComponent } from './Komponente/loginregistracija/loginregistracija.component';
import { DodajproizvodComponent } from './Komponente/dodajproizvod/dodajproizvod/dodajproizvod.component';
import { VerifikacijaComponent } from './Komponente/verifikacija/verifikacija/verifikacija.component';

@NgModule({
  declarations: [LoginregistracijaComponent, DodajproizvodComponent, VerifikacijaComponent],
  imports: [BrowserModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
