import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TaxSystemModel } from '../../models/tax-system.model';

@Component({
  selector: 'app-tax-system',
  templateUrl: './tax-system.component.html',
  styleUrls: ['./tax-system.component.css']
})
export class TaxSystemComponent {
  @Input({required: true})
  taxSystem!: TaxSystemModel;

  @Output()
  editTaxSystem = new EventEmitter<TaxSystemModel>();
  
  onEditTaxSystem(): void {
    this.editTaxSystem.emit(this.taxSystem);
  }
}
