import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './account/shared/auth.guard';
import { HomeComponent } from './home/home.component';
import { AuthenticationComponent } from './layout/authentication/authentication.component';
import { MainComponent } from './main/main.component';

const routes: Routes = [
  {
    path:"", 
    component: MainComponent,
    children: [
      {
        path:"", 
        component: HomeComponent
      },
      {
        path: "assets",
        loadChildren: () => import('./assets/assets-list/assets-list.module').then(module => module.AssetsListModule)
      },
      {
        path: "assets/insert",
        loadChildren: () => import('./assets/assets-insert-update/assets-insert-update.module').then(module => module.AssetsInsertUpdateModule)
      },
      { 
        path: "assets/update/:id",
        loadChildren: () => import('./assets/assets-insert-update/assets-insert-update.module').then(module => module.AssetsInsertUpdateModule)
      },
      {
        path: "maintenances",
        loadChildren: () => import('./maintenances/maintenances-list/maintenances-list.module').then(module => module.MaintenancesListModule)
      },
      {
        path: "maintenances/insert",
        loadChildren: () => import('./maintenances/maintenance-insert-update/maintenance-insert-update.module').then(module => module.MaintenanceInsertUpdateModule)
      },
      { 
        path: "maintenances/update/:id",
        loadChildren: () => import('./maintenances/maintenance-insert-update/maintenance-insert-update.module').then(module => module.MaintenanceInsertUpdateModule)
      },
      {
        path: "monitors",
        loadChildren: () => import('./monitors/monitors-list/monitors-list.module').then(module => module.MonitorsListModule)
      },
      {
        path: "notifications/insert",
        loadChildren: () => import('./notifications/notifications-insert/notifications-insert.module').then(module => module.NotificationsInsertModule)
      }
    ], canActivate: [AuthGuard]
  },
  {
    path:"",
    component: AuthenticationComponent,
    children: [
      {
        path: "",
        redirectTo: "login",
        pathMatch: "full"
      },
      {
        path: "login",
        loadChildren: () => import('./account/auth/auth.module').then(module => module.AuthModule)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
