import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'root',
  standalone: true,
  imports: [RouterOutlet,CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  http = inject(HttpClient);
  title = 'datingApp';
  users:any;
  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/users').subscribe({
      next: respnse =>this.users=respnse,
      error:error=>console.log(error),
      complete:()=>console.log('request has complete')
    });
  }
  
}
