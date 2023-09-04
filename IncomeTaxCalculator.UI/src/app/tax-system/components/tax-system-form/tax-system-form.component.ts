import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TaxSystemModel } from '../../models/tax-system.model';
import { Subscription } from 'rxjs';
import { TaxSystemService } from '../../services/tax-system.service';
import { TaxBandModel } from '../../models/tax-band.model';

@Component({
  selector: 'app-tax-system-form',
  templateUrl: './tax-system-form.component.html',
  styleUrls: ['./tax-system-form.component.css']
})
export class TaxSystemFormComponent implements OnInit {
  taxSystemId!: number;
  taxSystem: TaxSystemModel | undefined;
  taxSystem$!: Subscription;

  private route = inject(ActivatedRoute);
  private taxSystemService = inject(TaxSystemService);

  ngOnInit(): void {
    this.taxSystemId = Number(this.route.snapshot.paramMap.get('id'));
    this.taxSystem$ = this.taxSystemService.getTaxSystem(this.taxSystemId).subscribe(data => {
      data.bands = data.bands.sort((a, b) => a.lowerLimit - b.lowerLimit);
      this.taxSystem = data;
    });
  }

  ngOnDestroy(): void {
    this.taxSystem$?.unsubscribe();
  }

  onSubmit(): void {
    console.log(this.taxSystem);
  }

  onRemoveBand(bandIndex: number): void {
    if (this.taxSystem)
    {
      this.taxSystem.bands = this.taxSystem?.bands.filter((_, index) => index != bandIndex);
    }
  }

  onAddNewBand(): void {
    this.taxSystem?.bands.push(new TaxBandModel(0, null, 0));
  }
}
