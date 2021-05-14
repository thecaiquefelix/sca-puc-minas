import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MaintenanceInsertUpdateComponent } from './maintenance-insert-update/maintenance-insert-update.component';
import { MaintenancesResolverService } from './maintenances-resolver.service';

const routes: Routes = [
  {
    path:"",
    component: MaintenanceInsertUpdateComponent,
    resolve:{
      maintenance: MaintenancesResolverService
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MaintenanceInsertUpdateRoutingModule { }
