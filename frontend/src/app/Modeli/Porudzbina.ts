import { ProizvodiPorudzbine } from './ProizvodiPorudzbine';
export class Porudzbina {
  id: number = 0;
  proizvodi: ProizvodiPorudzbine[] = [];
  adresa: string = '';
  komentar: string = '';
  cena: number = 0;
  vremedostave: number = this.vreme();
  prihvacena: boolean = false;
  vremeprihvatanja: string = '';
  korisnikovId: number = 0;

  public vreme() {
    let min = 1;
    let max = 3;
    return Math.floor(Math.random() * (max - min) + min);
  }
}
