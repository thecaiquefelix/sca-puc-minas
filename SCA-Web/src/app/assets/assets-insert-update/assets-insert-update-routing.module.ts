import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AssetsInsertUpdateComponent } from './assets-insert-update/assets-insert-update.component';
import { AssetsResolverService } from './assets-resolver.service';

const routes: Routes = [
  {
    path:"", 
    component: AssetsInsertUpdateComponent,
    resolve: {
      asset: AssetsResolverService
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AssetsInsertUpdateRoutingModule { }
