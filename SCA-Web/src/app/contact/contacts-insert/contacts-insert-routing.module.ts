import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactInsertComponent } from './contact-insert/contact-insert.component';

const routes: Routes = [
  {path:"", component: ContactInsertComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ContactsInsertRoutingModule { }
