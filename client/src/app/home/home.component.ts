import { Component, OnInit, inject } from '@angular/core';
import { RegisterComponent } from '../register/register.component';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RegisterComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  
  ngOnInit(): void {
    this.getUsers();
  }
  http = inject(HttpClient);
regiterMode=false;
users:any;
registerToggle(){
  this.regiterMode = !this.regiterMode;
}
cancelRegisterMode(event:boolean){
  this.regiterMode=event;
}
getUsers(){
  this.http.get('https://localhost:5001/api/users').subscribe({
    next: respnse =>this.users=respnse,
    error:error=>console.log(error),
    complete:()=>console.log('request has complete')
  });
}
}
