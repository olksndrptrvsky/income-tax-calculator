import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CalculatorComponent } from './calculator/components/calculator/calculator.component';
import { TaxSystemsListComponent } from './tax-system/components/tax-systems-list/tax-systems-list.component';
import { TaxSystemFormComponent } from './tax-system/components/tax-system-form/tax-system-form.component';

const routes: Routes = [
  {
    path: "home",
    component: CalculatorComponent,
  },
  {
    path: "configurate",
    component: TaxSystemsListComponent,
  },
  {
    path: "tax-system/:id/edit",
    component: TaxSystemFormComponent,
  },
  {
    path: "**",
    redirectTo: "/home"
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
