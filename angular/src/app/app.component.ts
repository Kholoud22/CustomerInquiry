import { Component } from '@angular/core';
import { CustomerInfo } from 'src/models/customer-info';
import { InquiryService } from '../services/customer-inquiry.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'customer-support-form';
}
