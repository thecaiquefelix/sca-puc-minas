import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Maintenance, Type, Status } from '../../maintenance.model';
import { MaintenancesService } from '../../maintenances.service';

@Component({
  selector: 'app-maintenance-list',
  templateUrl: './maintenance-list.component.html',
  styleUrls: ['./maintenance-list.component.scss']
})
export class MaintenanceListComponent implements OnInit {

  maintenances$!: Observable<Maintenance[]>;

  colunasTabela = ['assetName','type','status','date'];

  constructor(private maintenancesService: MaintenancesService) { }

  ngOnInit(): void {
    this.list();
  }

  list(){
    this.maintenances$ = this.maintenancesService.list();
  }

  Type(type:number){
    return Type[type];
  }

  Status(status:number){
    return Status[status];
  }

  // validPeriod(dateMaintenance:Date){
  //   var today = new Date();
  //   return dateMaintenance < today;
  // }

  validPeriod(dateMaintenance:Date){
    let today = new Date();
    today.setHours(0,0,0,0);
    let date = new Date(dateMaintenance);
 
    let result = date.getTime() < today.getTime();
    return result;
  }
}
