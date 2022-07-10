import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { CustomerInfo } from 'src/models/customer-info';

@Injectable({
  providedIn: 'root'
})
export class InquiryService {

  constructor(private http: HttpClient) {
    }

  addInquiry(requestBody:CustomerInfo): Observable<any> {
    return this.http.post(environment.API.customerInquiry, requestBody);
  }
}
