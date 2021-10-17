import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpEvent, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { RegisterUser } from '../_model/register-user.model';
import { LoginUser } from '../_model/login-user.model';
import { User } from '../_model/user.model';

@Injectable({ providedIn: 'root' })
export class UserService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  register(form: RegisterUser) {
    var formData = new FormData();
    formData.append("UserName", form.Login);
    formData.append("Password", form.Password);
    formData.append("ForName", form.ForName);
    formData.append("SurName", form.SurName);
    return this.http.put<boolean>(this.baseUrl + `weatherforecast`, formData);
  }
}
