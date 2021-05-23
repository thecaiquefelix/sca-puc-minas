import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NotificationsInsertRoutingModule } from './notifications-insert-routing.module';
import { NotificationInsertComponent } from './notification-insert/notification-insert.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatOptionModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';


@NgModule({
  declarations: [
    NotificationInsertComponent
  ],
  imports: [
    CommonModule,
    NotificationsInsertRoutingModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule, 
    MatToolbarModule,
    MatButtonModule,
    MatOptionModule,
    MatSelectModule,
    MatProgressSpinnerModule
  ]
})
export class NotificationsInsertModule { }
