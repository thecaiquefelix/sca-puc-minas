import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MaintenancesListRoutingModule } from './maintenances-list-routing.module';
import { MaintenanceListComponent } from './maintenance-list/maintenance-list.component';
import { MatTableModule } from '@angular/material/table';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';


@NgModule({
  declarations: [
    MaintenanceListComponent
  ],
  imports: [
    CommonModule,
    MaintenancesListRoutingModule,
    MatTableModule,
    MatProgressSpinnerModule,
    MatToolbarModule,
    MatButtonModule
  ]
})
export class MaintenancesListModule { }
