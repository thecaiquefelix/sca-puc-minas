import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotificationInsertComponent } from './notification-insert/notification-insert.component';

const routes: Routes = [
  {path: "", component: NotificationInsertComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class NotificationsInsertRoutingModule { }
