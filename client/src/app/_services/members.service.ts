import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Member } from '../_models/member';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
private http=inject(HttpClient);
baseUrl=environment.apiUrl;
private accountService=inject(AccountService);
getMembers(){
  return this.http.get<Member[]>(this.baseUrl+'users');
}
getMember(username:string){
  return this.http.get<Member[]>(this.baseUrl+'users/'+username);
}
getHttpOptions(){
  return{
    headers:new HttpHeaders({
      authorization:`Bearer ${this.accountService.currentUser()?.token}`
    })
  }
}
}
