import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MaintenancesListRoutingModule } from './maintenances-list-routing.module';
import { MaintenanceListComponent } from './maintenance-list/maintenance-list.component';
import { MatTableModule } from '@angular/material/table';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';

@NgModule({
  declarations: [
    MaintenanceListComponent
  ],
  imports: [
    CommonModule,
    MaintenancesListRoutingModule,
    MatSortModule,
    MatPaginatorModule,
    MatTableModule,
    MatProgressSpinnerModule,
    MatToolbarModule,
    MatButtonModule
  ]
})
export class MaintenancesListModule { }
