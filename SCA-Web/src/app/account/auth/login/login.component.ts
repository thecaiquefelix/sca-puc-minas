import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from '../../shared/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  formGroup!: FormGroup;

  constructor(private accountService: AccountService,
              private router: Router,
              private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.formGroup = this.formBuilder.group({
      username: [ "", Validators.required],
      password: [ "", Validators.required],
    })
  }

  async submitLogin(){
    try{
      const result = await this.accountService.login(this.formGroup.value);
      this.router.navigate(['']);
    }catch(error){
      console.error(error)
    }
  }

}

