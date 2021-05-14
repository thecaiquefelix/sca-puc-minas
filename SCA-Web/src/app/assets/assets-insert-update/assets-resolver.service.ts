import { Injectable } from '@angular/core';
import { Asset } from '../asset.model';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AssetsService } from '../assets.service';
import { empty, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AssetsResolverService implements Resolve<Asset> {

  constructor(private assetsService: AssetsService) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot)
  : Observable<any> | Promise<any> | any {
      let id = route.params['id'];
      if (id)
      {
        return this.assetsService.getById(id);
      }
  }
}
