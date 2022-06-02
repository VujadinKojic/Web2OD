import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginregistracijaComponent } from './loginregistracija.component';

describe('LoginregistracijaComponent', () => {
  let component: LoginregistracijaComponent;
  let fixture: ComponentFixture<LoginregistracijaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoginregistracijaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginregistracijaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
