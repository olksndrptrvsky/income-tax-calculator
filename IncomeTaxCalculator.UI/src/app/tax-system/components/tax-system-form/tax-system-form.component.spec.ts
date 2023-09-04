import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaxSystemFormComponent } from './tax-system-form.component';

describe('TaxSystemFormComponent', () => {
  let component: TaxSystemFormComponent;
  let fixture: ComponentFixture<TaxSystemFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TaxSystemFormComponent]
    });
    fixture = TestBed.createComponent(TaxSystemFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
