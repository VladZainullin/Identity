import {Component, Inject, OnDestroy, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {CalendarDate} from "calendar-date";
import {FormControl} from "@angular/forms";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit, OnDestroy {
  constructor(
    private _httpClient: HttpClient,
    @Inject('BASE_URL') private _baseUrl: string) {
  }

  usernameControl: FormControl<string | null>;
  usernameSubscribe: Subscription;
  username: string;
  dateOfBirthControl: FormControl<CalendarDate | null>;
  dateOfBirthSubscribe: Subscription;
  dateOfBirth: CalendarDate;
  passwordControl: FormControl<string | null>;
  passwordSubscribe: Subscription;
  password: string;
  emailControl: FormControl<string | null>;

  emailSubscribe: Subscription;
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
    this.usernameSubscribe = this.usernameControl.valueChanges
      .subscribe(v => {
        if (v != null) {
          this.username = v
        }
      });

    this.dateOfBirthControl = new FormControl<CalendarDate | null>(null);
    this.dateOfBirthSubscribe = this.dateOfBirthControl.valueChanges
      .subscribe(v => {
        if (v != null) {
          this.dateOfBirth = v
        }
      });

    this.emailControl = new FormControl<string | null>(null);
    this.emailSubscribe = this.emailControl.valueChanges
      .subscribe(v => {
        if (v != null) {
          this.email = v
        }
      });

    this.passwordControl = new FormControl<string | null>(null);
    this.passwordSubscribe = this.passwordControl.valueChanges
      .subscribe(v => {
        if (v != null) {
          this.password = v
        }
      });
  }

  ngOnDestroy(): void {
    this.usernameSubscribe.unsubscribe();
    this.dateOfBirthSubscribe.unsubscribe();
    this.emailSubscribe.unsubscribe();
    this.passwordSubscribe.unsubscribe();
  }
}

export type RegisterUserDto = {
  dateOfBirth: CalendarDate,
  username: string,
  email: string,
  password: string
}
