import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CalculatorComponent } from './calculator/components/calculator/calculator.component';
import { TaxSystemsListComponent } from './tax-system/components/tax-systems-list/tax-systems-list.component';
import { TaxSystemComponent } from './tax-system/components/tax-system/tax-system.component';
import { HttpClientModule } from '@angular/common/http';
import { TaxesComponent } from './calculator/components/taxes/taxes.component';
import { TaxSystemFormComponent } from './tax-system/components/tax-system-form/tax-system-form.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    CalculatorComponent,
    TaxSystemsListComponent,
    TaxSystemComponent,
    TaxesComponent,
    TaxSystemFormComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
