import { Routes, RouterModule, PreloadAllModules } from '@angular/router';
import { NgModule } from '@angular/core';
// import { StartComponent } from './start/start.component';
// import { ErrorComponent } from './error/error.component';
import { CustomerSupportComponent } from './components/customer-support/customer-support.component';

const routes: Routes = [
  //{ path: 'error', component: ErrorComponent },
 // { path: 'success', component: ErrorComponent },
  { path: '', component: CustomerSupportComponent },
//   {
//     path: '**',
//     component: ErrorComponent,
//     data: { error: 404 }
//   }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}