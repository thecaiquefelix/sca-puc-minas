import { Component, OnInit, ViewChild } from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { DamId } from 'src/app/monitors/monitors.model';
import { NotificationsService } from '../../notifications.service';

@Component({
  selector: 'app-notification-list',
  templateUrl: './notification-list.component.html',
  styleUrls: ['./notification-list.component.scss']
})
export class NotificationListComponent implements OnInit {

  colunasTabela = ['date','damId','message'];
  dataSource!: MatTableDataSource<Notification>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  
  constructor(private notificationsService: NotificationsService) { }

  ngOnInit(){
    this.list();
  }

  list(){
    this.notificationsService.list().subscribe(notifications => {
      this.dataSource = new MatTableDataSource(notifications);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  Dam(id:number)
  {
    return DamId[id];
  }

}
