import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ErrorHandler, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppComponent } from './app.component';
import { CustomerSupportComponent } from './components/customer-support/customer-support.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { ErrorHandlerOverride } from 'src/handlers/ErrorHandlerOverride';
import { MatDialogModule } from '@angular/material/dialog';
import { SnackbarService } from 'src/services/snackbar.service';
import { AppRoutingModule } from './app.routing.module';

@NgModule({
  declarations: [
    AppComponent,
    CustomerSupportComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatSnackBarModule,
    MatDialogModule,
    BrowserAnimationsModule,
    AppRoutingModule
  ],
  providers: [
    SnackbarService,
    { provide: ErrorHandler, useClass: ErrorHandlerOverride },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
