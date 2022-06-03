import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DodajproizvodComponent } from './Komponente/dodajproizvod/dodajproizvod/dodajproizvod.component';
import { LoginregistracijaComponent } from './Komponente/loginregistracija/loginregistracija.component';
import { PorudzbineComponent } from './Komponente/porudzbine/porudzbine/porudzbine.component';
import { VerifikacijaComponent } from './Komponente/verifikacija/verifikacija/verifikacija.component';

const routes: Routes = [
  { path: '', redirectTo: '/logreg', pathMatch: 'full' },
  { path: 'logreg', component: LoginregistracijaComponent },
  { path: 'dodajproizvod', component: DodajproizvodComponent },
  { path: 'verifikuj', component: VerifikacijaComponent },
  { path: 'porudzbine', component: PorudzbineComponent },
];

@NgModule({
  //declarations: [LoginregistracijaComponent],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
