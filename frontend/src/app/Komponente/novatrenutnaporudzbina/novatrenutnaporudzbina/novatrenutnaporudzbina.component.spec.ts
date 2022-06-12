import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NovatrenutnaporudzbinaComponent } from './novatrenutnaporudzbina.component';

describe('NovatrenutnaporudzbinaComponent', () => {
  let component: NovatrenutnaporudzbinaComponent;
  let fixture: ComponentFixture<NovatrenutnaporudzbinaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NovatrenutnaporudzbinaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NovatrenutnaporudzbinaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
