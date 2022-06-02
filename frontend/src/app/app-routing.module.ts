import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginregistracijaComponent } from './Komponente/loginregistracija/loginregistracija.component';

const routes: Routes = [
  { path: '', redirectTo: '/logreg', pathMatch: 'full' },
  { path: 'logreg', component: LoginregistracijaComponent },
];

@NgModule({
  //declarations: [LoginregistracijaComponent],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
