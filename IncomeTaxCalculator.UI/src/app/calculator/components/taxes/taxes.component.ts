import { Component, Input } from '@angular/core';
import { TaxesModel } from '../../models/taxes.model';

@Component({
  selector: 'app-taxes',
  templateUrl: './taxes.component.html',
  styleUrls: ['./taxes.component.css']
})
export class TaxesComponent {  
  @Input({required: true})
  taxes!: TaxesModel;
}
