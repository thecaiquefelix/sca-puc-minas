import { Component, OnInit, ViewChild } from '@angular/core';
import { AssetsService } from '../../assets.service';
import { Asset, Manufacturer, Category } from '../../asset.model';
import { MatPaginator } from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-asset-list',
  templateUrl: './asset-list.component.html',
  styleUrls: ['./asset-list.component.scss']
})
export class AssetListComponent implements OnInit {
  colunasTabela = ['name', 'manufacturer', 'category','manufactureDate','serial'];
  dataSource!: MatTableDataSource<Asset>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private assetsService: AssetsService) { }

  ngOnInit(){
    this.listItens();
  }

  listItens(){
    this.assetsService.list().subscribe(assets => {
      this.dataSource = new MatTableDataSource(assets);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  Manufacturer(manufacturer:number){
    return Manufacturer[manufacturer];
  }

  Category(category:number){
    return Category[category];
  }

}
