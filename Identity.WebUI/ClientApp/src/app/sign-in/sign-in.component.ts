import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {CalendarDate} from "calendar-date";

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  customerForm!: FormGroup;

  constructor(private formBuilder: FormBuilder) {
  }

  ngOnInit(): void {
    let configuration = {
      username: ['', [
        Validators.required,
        Validators.min(1),
        Validators.max(20)]],
      dateOfBirth: ['',[
        Validators.required,
      ]],
      email: ['', [
        Validators.required,
        Validators.email
      ]],
      password: ['', [
        Validators.required,
        Validators.min(8),
      ]]
    }

    this.customerForm = this.formBuilder.group(configuration);
  }

  save(): void {

  }

}
