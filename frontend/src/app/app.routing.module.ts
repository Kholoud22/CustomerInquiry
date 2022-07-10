import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { NgModule } from '@angular/core';
// import { StartComponent } from './start/start.component';
// import { ErrorComponent } from './error/error.component';
import { CustomerSupportComponent } from './components/customer-support/customer-support.component';

const routes: Routes = [
  { path: '', component: CustomerSupportComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}