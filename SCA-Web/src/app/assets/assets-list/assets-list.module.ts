import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AssetsListRoutingModule } from './assets-list-routing.module';
import { AssetListComponent } from './asset-list/asset-list.component';

import {MatTableModule} from '@angular/material/table';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatButtonModule} from '@angular/material/button';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';

@NgModule({
  declarations: [
    AssetListComponent
  ],
  imports: [
    CommonModule,
    AssetsListRoutingModule,
    MatSortModule,
    MatPaginatorModule,
    MatTableModule,
    MatProgressSpinnerModule,
    MatToolbarModule,
    MatButtonModule 
  ]
})
export class AssetsListModule { }
