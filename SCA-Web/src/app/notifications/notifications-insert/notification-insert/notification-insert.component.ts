import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NotificationsService } from '../../notifications.service';

@Component({
  selector: 'app-notification-insert',
  templateUrl: './notification-insert.component.html',
  styleUrls: ['./notification-insert.component.scss']
})
export class NotificationInsertComponent implements OnInit {

  formGroup!: FormGroup;
  
  constructor(private formBuilder: FormBuilder, 
              private notificationsService: NotificationsService,
              private router: Router) { }

  ngOnInit(){
    this.formGroup = this.formBuilder.group({
      damId: [ 1 , Validators.required],
      message: [ "", Validators.required]
    })
  }

  send()
  {
    this.notificationsService.insert(this.formGroup.value).subscribe(
      notificationInserted => {
        this.router.navigateByUrl("/monitors");
      },
      error => {
        alert("Erro ao enviar o alerta");
      }
    )
  }

}
