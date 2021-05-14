import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AssetsService } from '../../assets.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Asset } from '../../asset.model';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-assets-insert-update',
  templateUrl: './assets-insert-update.component.html',
  styleUrls: ['./assets-insert-update.component.scss']
})
export class AssetsInsertUpdateComponent implements OnInit {

  formGroup!: FormGroup;
  asset!: Asset;

  constructor(
    private formBuilder: FormBuilder, 
    private assetsService: AssetsService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    public datepipe: DatePipe) { }

  ngOnInit(){
    this.asset = this.activatedRoute.snapshot.data["asset"];
    this.formGroup = this.formBuilder.group({
      id: [ (this.asset && this.asset.id != 0) ? this.asset.id: 0],
      name: [ (this.asset && this.asset.name) ? this.asset.name : "", Validators.required],
      manufacturer: [ (this.asset && this.asset.manufacturer) ? this.asset.manufacturer: 0, Validators.required],
      category: [ (this.asset && this.asset.category) ? this.asset.category : 0 , Validators.required],
      manufactureDate: [ (this.asset && this.asset.manufactureDate) ? this.datepipe.transform(this.asset.manufactureDate, "yyyy-MM-dd")?.toString().split('T', 1)[0] : new Date().toISOString().split('T', 1)[0], Validators.required],
      serial: [(this.asset && this.asset.serial) ? this.asset.serial: "", Validators.required],
      active: [true],
    })
  }

  save(){

    if(this.asset && this.asset.id != 0)
    {
      this.assetsService.update(this.formGroup.value).subscribe(
        assetInserted => {
          this.router.navigateByUrl("/assets");
        },
        error => {
          alert("Erro ao atualizar");
        }
      )
    }else{
      this.assetsService.insert(this.formGroup.value).subscribe(
        assetInserted => {
          this.router.navigateByUrl("/assets");
        },
        error => {
          alert("Erro ao cadastrar");
        }
      )
    }
  }

  delete(){
    if(confirm("Deseja deletar este ativos?"))
    {
      this.assetsService.delete(this.asset.id).subscribe(
        response => {
          this.router.navigateByUrl("/assets")
        },
        error => {
          alert("Erro ao deletar")
        }
      )
    }
  }

  maxDate(){
    return new Date().toISOString().split('T', 1)[0];
  }

}
