import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from '../model/user';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  apiUrl = environment.apiUrl;
  loggedToken: boolean = false;
  wasLoginSuccessful: boolean = true;

  constructor(
    private http: HttpClient
  ) {
    const token = localStorage.getItem('authToken');
    token ? this.loggedToken = true : this.loggedToken = false;
  }

  register(user: User): Observable<any> {
    return this.http.post<string>(`${this.apiUrl}auth/register`, user);
  }

  // login(email: string, password: string): Observable<any > {
  //   return this.http.post<string>(`${this.apiUrl}auth/login`, { email, password });
  // }

  login(email: string, password: string): Observable<{ token: string }> {
    return this.http.post<{ token: string }>(`${this.apiUrl}auth/login`, { email, password });
  }

  // saveToken(token: string): void {
  //   localStorage.setItem('authToken', token); // Save token to localStorage
  // }

  // logout(): void {
  //   localStorage.removeItem('authToken'); // Remove the token on logout
  // }

  setLoginData() {
    const token = localStorage.getItem('authToken');
    token ? this.loggedToken = true : this.loggedToken = false;
  }

}
