import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user';
import { map, filter, switchMap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  constructor(private http: HttpClient) { }

  // url to web api
  _url : string = "https://localhost:44330/api/account";
  
  login(username: string, password: string){    
    console.log(username);
    console.log(password);
    return this.http.post<Observable<any>>(this._url + '/authenticate', {username: username, password:password})
    .pipe(map((user: any) => {
      console.log(user);      
      if(user && user.token){
        localStorage.setItem('currentUser', JSON.stringify(user))
      }

      return user;
    }));
  }

  logout(){
    localStorage.removeItem('currentUser');
  }
}
