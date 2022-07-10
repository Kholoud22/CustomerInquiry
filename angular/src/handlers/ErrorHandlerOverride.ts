import { HttpErrorResponse } from "@angular/common/http";
import { ErrorHandler, Injectable, Injector } from "@angular/core";
import { SnackbarService } from "src/services/snackbar.service";

@Injectable({ providedIn: "root" })
export class ErrorHandlerOverride extends ErrorHandler {
  public snackbar: SnackbarService | undefined;

  constructor(public injector: Injector) {
    super();
  }

  override handleError(error: any | HttpErrorResponse): void {
    if (!this.snackbar) {
      this.snackbar = this.injector.get(SnackbarService);
    }

    if (error instanceof HttpErrorResponse) {
      if (!navigator.onLine) {
        this.snackbar.error('No acces to the internet.');
      } else {
        var description = error.error.errors ? JSON.stringify(error.error.errors) : error.error.description;
        this.snackbar.error(`${error.status} - ${error.statusText}: ${description}`);
      }
    } else {
      this.snackbar.error("Something went wrong try again later");
    }
    super.handleError(error);
  }
}