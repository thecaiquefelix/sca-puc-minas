import { HttpClient } from '@angular/common/http';
import { stringify } from '@angular/compiler/src/util';
import { Injectable } from '@angular/core';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private baseURL = "https://localhost:5001"
  private endpoint = "api/v1/account/login"

  constructor(private httpClient: HttpClient) { }

  async login(user: any){
    console.log(user);
    const result = await this.httpClient.post<any>(`https://localhost:5001/v1/account/login`, user).toPromise();
    if(result && result.token){
      window.localStorage.setItem("token", result.token);
      window.localStorage.setItem("role", result.user.role);
      return true;
    }

    return false;
  }

  getAuthorizationToken() {
    const token = window.localStorage.getItem('token');
    return token;
  }

  containsRole(values:string[]) {
    const role = window.localStorage.getItem('role');
    let roles = role?.toString().split(';') ?? [];
    let result = roles.some(r=> values.indexOf(r) >= 0);
    return result;
  }

  logout(){
    window.localStorage.clear();
  }

  getTokenExpirationDate(token: string): Date {
    const decoded: any = jwt_decode(token);

    if (decoded.exp === undefined) {
      return null as any; 
    }

    const date = new Date(0);
    date.setUTCSeconds(decoded.exp);
    return date;
  }

  isTokenExpired(token?: string): boolean {
    if (!token) {
      return true;
    }

    const date = this.getTokenExpirationDate(token);
    if (date === undefined) {
      return false;
    }

    return !(date.valueOf() > new Date().valueOf());
  }

  isUserLoggedIn() {
    const token = this.getAuthorizationToken();
    if (!token) {
      return false;
    } else if (this.isTokenExpired(token)) {
      return false;
    }

    return true;
  }

}
