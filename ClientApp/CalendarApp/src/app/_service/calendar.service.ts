import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpEvent, HttpRequest } from '@angular/common/http';

import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { WeatherForecast } from '../_models/weather';

@Injectable({ providedIn: 'root' })
export class WeatherService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }
  get() {
    return this.http.get<WeatherForecast[]>(this.baseUrl + `weatherforecast`);
  }
}
