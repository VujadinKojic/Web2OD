import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DodajproizvodComponent } from './dodajproizvod.component';

describe('DodajproizvodComponent', () => {
  let component: DodajproizvodComponent;
  let fixture: ComponentFixture<DodajproizvodComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DodajproizvodComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DodajproizvodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
