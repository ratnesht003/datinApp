import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [FormsModule,BsDropdownModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  accounService = inject(AccountService);
  model:any={};

  login(){
    this.accounService.login(this.model).subscribe({
        next:response=>{
          console.log(response);
        },
        error:error=>console.log(error)
      });
  }
  logout(){
    this.accounService.logout();
  }
}
