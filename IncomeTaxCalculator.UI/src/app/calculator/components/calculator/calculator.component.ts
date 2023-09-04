import { Component, OnInit, inject } from '@angular/core';
import { TaxSystemModel } from 'src/app/tax-system/models/tax-system.model';
import { TaxSystemService } from 'src/app/tax-system/services/tax-system.service';
import { Subscription } from 'rxjs';
import { TaxesModel } from '../../models/taxes.model';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})
export class CalculatorComponent implements OnInit {
  selectedTaxSystem: TaxSystemModel | undefined;
  availableTaxSystems: TaxSystemModel[] = [];
  taxes: TaxesModel | undefined;

  private availableTaxSystems$!: Subscription;
  private taxes$: Subscription | undefined;

  private taxSystemService = inject(TaxSystemService);

  ngOnInit() {
    this.availableTaxSystems$ = this.taxSystemService.getAllTaxSystems().subscribe(data =>
      {
        this.availableTaxSystems = data;
        this.selectedTaxSystem = data[0];
      });
  }

  ngOnDestroy() {
    this.availableTaxSystems$?.unsubscribe();
    this.taxes$?.unsubscribe();
  }

  onSelectTaxSystem(taxSystemId: number) {
    this.selectedTaxSystem = this.availableTaxSystems.find(x => x.id == taxSystemId);
  }

  onCalculateTaxes(annualSalary: number) {
    if (this.selectedTaxSystem) {
      this.taxes$ = this.taxSystemService.getTaxes(this.selectedTaxSystem.id, annualSalary).subscribe(data => {
        this.taxes = data;

        console.log(this.taxes);
      });
    }
  }
}
