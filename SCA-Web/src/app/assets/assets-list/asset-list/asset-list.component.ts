import { Component, OnInit } from '@angular/core';
import { AssetsService } from '../../assets.service';
import { Observable } from 'rxjs';
import { Asset, Manufacturer, Category } from '../../asset.model';

@Component({
  selector: 'app-asset-list',
  templateUrl: './asset-list.component.html',
  styleUrls: ['./asset-list.component.scss']
})
export class AssetListComponent implements OnInit {

  assets$!: Observable<Asset[]>;

  colunasTabela = ['name', 'manufacturer', 'category','manufactureDate','serial'];

  constructor(private assetsService: AssetsService) { }

  ngOnInit(): void {
    this.listItens();
  }

  listItens(){
    this.assets$ = this.assetsService.list();
  }

  Manufacturer(manufacturer:number){
    return Manufacturer[manufacturer];
  }

  Category(category:number){
    return Category[category];
  }

}
