import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NoveporudzbineComponent } from './noveporudzbine.component';

describe('NoveporudzbineComponent', () => {
  let component: NoveporudzbineComponent;
  let fixture: ComponentFixture<NoveporudzbineComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NoveporudzbineComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NoveporudzbineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
