import { Injectable, NgZone } from '@angular/core';
import {MatSnackBar, MatSnackBarConfig} from '@angular/material/snack-bar'
@Injectable({
  providedIn: 'root'
})
export class SnackbarService {

  constructor(
    public snackbar: MatSnackBar,
    private zone: NgZone,
  ) { }

  error(message: string) {
    const config = new MatSnackBarConfig();
    config.panelClass = ['snack-bar-error'];
    config.duration = 4000;
    this.zone.run(() => {
      this.snackbar.open(message, 'X', config);
    });
  }

  success(message: string) {
    const config = new MatSnackBarConfig();
    config.panelClass = ['snack-bar-success'];
    config.duration = 4000;
    config.verticalPosition = 'top'
    config.horizontalPosition = 'right'
    this.zone.run(() => {
      this.snackbar.open(message, 'Ok', config);
    });
  }

}