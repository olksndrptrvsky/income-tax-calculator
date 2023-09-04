import { Component, OnInit, inject } from '@angular/core';
import { TaxSystemModel } from '../../models/tax-system.model';
import { Subscription } from 'rxjs';
import { TaxSystemService } from '../../services/tax-system.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tax-systems-list',
  templateUrl: './tax-systems-list.component.html',
  styleUrls: ['./tax-systems-list.component.css']
})
export class TaxSystemsListComponent implements OnInit {
  taxSystems!: TaxSystemModel[];
  taxSystems$!: Subscription;

  private taxSystemService = inject(TaxSystemService);
  private router = inject(Router);

  ngOnInit(): void {
    this.taxSystems$ = this.taxSystemService.getAllTaxSystems().subscribe(data =>
      {
        this.taxSystems = data;
      });
  }

  ngOnDestroy(): void {
    this.taxSystems$?.unsubscribe();
  }

  onEditTaxSystem(taxSystem: TaxSystemModel): void {
    this.router.navigate(['tax-system', taxSystem.id, 'edit']);
  }
}
