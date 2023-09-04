import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaxSystemsListComponent } from './tax-systems-list.component';

describe('TaxSystemsListComponent', () => {
  let component: TaxSystemsListComponent;
  let fixture: ComponentFixture<TaxSystemsListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TaxSystemsListComponent]
    });
    fixture = TestBed.createComponent(TaxSystemsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
