import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {CalendarDate} from "calendar-date";
import {FormControl} from "@angular/forms";

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  constructor(
    private _httpClient: HttpClient,
    @Inject('BASE_URL') private _baseUrl: string) {
  }

  usernameControl: FormControl<string | null>;
  username: string;
  dateOfBirthControl: FormControl<CalendarDate | null>;
  dateOfBirth: CalendarDate;
  passwordControl: FormControl<string | null>;
  password: string;
  emailControl: FormControl<string | null>;
  email: string;

  onClick(): void {

    let body: RegisterUserDto = {
      username: this.username,
      dateOfBirth: this.dateOfBirth,
      email: this.email,
      password: this.password
    };

    this._httpClient
      .post(this._baseUrl + 'api/authorization/sign-up', body)
      .subscribe({
        next: (data: any) => console.log(data),
        error: error => console.error(error)
      });
  }

  ngOnInit() {
    this.usernameControl = new FormControl<string | null>(null);
    this.usernameControl.valueChanges
      .subscribe(v => {
        if (v != null) {
          this.username = v
        }
      });

    this.dateOfBirthControl = new FormControl<CalendarDate | null>(null);
    this.dateOfBirthControl.valueChanges
      .subscribe(v => {
        if (v != null) {
          this.dateOfBirth = v
        }
      });

    this.emailControl = new FormControl<string | null>(null);
    this.emailControl.valueChanges
      .subscribe(v => {
        if (v != null) {
          this.email = v
        }
      });

    this.passwordControl = new FormControl<string | null>(null);
    this.passwordControl.valueChanges
      .subscribe(v => {
        if (v != null) {
          this.password = v
        }
      });
  }
}

export type RegisterUserDto = {
  dateOfBirth: CalendarDate,
  username: string,
  email: string,
  password: string
}
