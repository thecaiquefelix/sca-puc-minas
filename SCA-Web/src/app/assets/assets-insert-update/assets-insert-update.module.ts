import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AssetsInsertUpdateRoutingModule } from './assets-insert-update-routing.module';
import { AssetsInsertUpdateComponent } from './assets-insert-update/assets-insert-update.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from "@angular/material/form-field"
import { MatInputModule } from "@angular/material/input"
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';


@NgModule({
  declarations: [
    AssetsInsertUpdateComponent
  ],
  imports: [
    CommonModule,
    AssetsInsertUpdateRoutingModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule, 
    MatToolbarModule,
    MatButtonModule
  ]
})
export class AssetsInsertUpdateModule { }
