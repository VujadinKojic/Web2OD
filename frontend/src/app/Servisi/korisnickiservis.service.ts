import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Korisnik } from '../Modeli/Korisnik';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root',
})
export class KorisnickiservisService {
  registracija(r: Korisnik): Observable<Korisnik> {
    return this.http.post<Korisnik>(
      environment.serverURL + '/api/KorisnickiProfil/registracija',
      r
    );
  }

  constructor(private http: HttpClient) {}
}
