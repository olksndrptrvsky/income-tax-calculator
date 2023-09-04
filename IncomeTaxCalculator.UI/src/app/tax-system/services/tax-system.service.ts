import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TaxSystemModel } from '../models/tax-system.model';
import { TaxesModel } from 'src/app/calculator/models/taxes.model';

@Injectable({
  providedIn: 'root'
})
export class TaxSystemService {

  private readonly apiUrl: string = "/api/TaxSystems";

  constructor(private httpClient: HttpClient) { }

  getAllTaxSystems() : Observable<TaxSystemModel[]> {
    return this.httpClient.get<TaxSystemModel[]>(this.apiUrl);
  }

  getTaxes(taxSystemId: number, annualSalary: number) : Observable<TaxesModel> {
    const params = new HttpParams()
      .set('annualSalary', annualSalary);
    return this.httpClient.get<TaxesModel>(`${this.apiUrl}/${taxSystemId}/taxes`, { params: params });
  }

  getTaxSystem(taxSystemId: number) : Observable<TaxSystemModel> {
    return this.httpClient.get<TaxSystemModel>(`${this.apiUrl}/${taxSystemId}`);
  }

  updateTaxSystem(taxSystem: TaxSystemModel) : Observable<any> {
    return this.httpClient.put(`${this.apiUrl}/${taxSystem.id}`, taxSystem);
  }
}
