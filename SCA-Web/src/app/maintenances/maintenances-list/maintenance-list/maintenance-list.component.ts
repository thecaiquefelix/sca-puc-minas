import { Component, OnInit, ViewChild } from '@angular/core';
import { MaintenancesService } from '../../maintenances.service';
import { Maintenance, Type, Status } from '../../maintenance.model';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-maintenance-list',
  templateUrl: './maintenance-list.component.html',
  styleUrls: ['./maintenance-list.component.scss']
})
export class MaintenanceListComponent implements OnInit {
  colunasTabela = ['assetName','type','status','date'];
  dataSource!: MatTableDataSource<Maintenance>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private maintenancesService: MaintenancesService) { }

  ngOnInit(){
    this.list();
  }

  list(){
    this.maintenancesService.list().subscribe(maintenances => {
      this.dataSource = new MatTableDataSource(maintenances);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  Type(type:number){
    return Type[type];
  }

  Status(status:number){
    return Status[status];
  }

  validPeriod(dateMaintenance:Date, status:number){
    if(status == 2)
    {
      return false;
    }
    

    let today = new Date();
    today.setHours(0,0,0,0);
    let date = new Date(dateMaintenance);
 
    let result = date.getTime() < today.getTime();
    return result;
  }
}
