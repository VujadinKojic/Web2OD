import { Porudzbina } from './Porudzbina';

export class Korisnik {
  id: number = 0;
  korime: string = '';
  email: string = '';
  lozinka: string = '';
  ime: string = '';
  prezime: string = '';
  rodjenje: string = '';
  adresa: string = '';
  slika: string = '';
  tipkorisnika: string = '';
  statuskorisnika: string = '';
  porudzbine: Porudzbina[] = [];

  // public verificated(accountStatus: string) {
  //   if (accountStatus === String(AccountStatus.processing)) {
  //     return true;
  //   } else {
  //     return false;
  //   }
  // }

  // public isAccepted(accountStatus: string) {
  //   if (accountStatus === 'accepted') {
  //     return true;
  //   } else {
  //     return false;
  //   }
  // }

  // public isProcessing(accountStatus: string) {
  //   if (accountStatus === 'processing') {
  //     return true;
  //   } else {
  //     return false;
  //   }
  // }

  // public isAdministrator(userType: string) {
  //   if (userType === 'administrator') {
  //     return true;
  //   } else {
  //     return false;
  //   }
  // }
  // public isOrdinaryUser(userType: string) {
  //   if (userType === 'ordinaryUser') {
  //     return true;
  //   } else {
  //     return false;
  //   }
  // }

  // public isDeliverer(userType: string) {
  //   if (userType === 'deliverer') {
  //     return true;
  //   } else {
  //     return false;
  //   }
  // }
}
