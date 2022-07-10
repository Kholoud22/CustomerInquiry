import { Component, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CustomerInfo } from 'src/models/customer-info';
import { Enumeration } from 'src/models/enumeration';
import { InquiryService } from 'src/services/customer-inquiry.service';
import { SnackbarService } from 'src/services/snackbar.service';

@Component({
  selector: 'customer-support',
  templateUrl: './customer-support.component.html',
  styleUrls: ['./customer-support.component.scss']
})

export class CustomerSupportComponent {
  customerInfoForm: FormGroup = new FormGroup('');
  public customerInfo: CustomerInfo = new CustomerInfo();
  submitted = false;
  public InquiryTypes = [
    new Enumeration(1, 'General'),
    new Enumeration(2, 'Complain'),
    new Enumeration(3, 'Other')
 ]
  constructor(private formBuilder: FormBuilder, private service:InquiryService, private snackbar:SnackbarService) {
    this.createForm();
  }

  createForm() {
    this.customerInfoForm = this.formBuilder.group({
      email: ['', Validators.required],
      phone: ['', Validators.required],
      number: [''],
      inquiry: ['', Validators.required],
      description: ['', Validators.required],
      TC: [false, Validators.requiredTrue]
    });
  }

  get f() { return this.customerInfoForm.controls; }

  changeInquiry(e: any) {
    this.f['inquiry']?.setValue(e.target.value, {
      onlySelf: true,
    });
  }

  public onSubmit() {
    this.submitted = true;
    if (this.customerInfoForm.invalid) {
      return;
    } else {
    this.customerInfo.email = this.f["email"].value;
    this.customerInfo.description = this.f["description"].value;
    this.customerInfo.phone = this.f["phone"].value;
    this.customerInfo.number = this.f["number"]?.value;
    this.customerInfo.termsAndCondition = true;
    this.customerInfo.inquiryType = this.f["inquiry"]?.value;

    this.service.addInquiry(this.customerInfo).subscribe(res =>{
      this.snackbar.success("Request has been sent successfully.");
    });
    }
  }
}
