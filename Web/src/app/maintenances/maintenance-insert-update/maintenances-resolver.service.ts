import { Injectable } from '@angular/core';
import { Maintenance } from '../maintenance.model';
import { MaintenancesService } from '../maintenances.service';
import { ActivatedRouteSnapshot, RouterStateSnapshot, Resolve } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MaintenancesResolverService implements Resolve<Maintenance> {

  constructor(private maintenancesService: MaintenancesService) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot)
  : Observable<any> | Promise<any> | any {
      let id = route.params['id'];
      if (id)
      {
        return this.maintenancesService.getById(id);
      }
  }
}
