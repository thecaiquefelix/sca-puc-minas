import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MonitorsListRoutingModule } from './monitors-list-routing.module';
import { MonitorListComponent } from './monitor-list/monitor-list.component';

import {MatGridListModule} from '@angular/material/grid-list';
import { MatTableModule } from '@angular/material/table';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatOptionModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    MonitorListComponent
  ],
  imports: [
    CommonModule,
    MonitorsListRoutingModule,
    MatFormFieldModule,
    MatInputModule, 
    MatToolbarModule,
    MatButtonModule,
    MatOptionModule,
    MatSelectModule,
    MatProgressSpinnerModule,
    MatGridListModule,
    MatTableModule,
    FormsModule
  ]
})
export class MonitorsListModule { }
