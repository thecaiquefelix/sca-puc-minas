import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Maintenance } from '../../maintenance.model';
import { MaintenancesService } from '../../maintenances.service';
import { Router, ActivatedRoute } from '@angular/router';
import { DatePipe } from '@angular/common';
import { Asset } from 'src/app/assets/asset.model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-maintenance-insert-update',
  templateUrl: './maintenance-insert-update.component.html',
  styleUrls: ['./maintenance-insert-update.component.scss']
})
export class MaintenanceInsertUpdateComponent implements OnInit {

  formGroup!: FormGroup;
  maintenance!: Maintenance;
  assets$!: Observable<Asset[]>;

  constructor(
    private formBuilder: FormBuilder, 
    private maintenancesService: MaintenancesService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    public datepipe: DatePipe) { }

  ngOnInit(){
    this.maintenance = this.activatedRoute.snapshot.data["maintenance"];
    this.assets$ = this.maintenancesService.listAssets();

    this.formGroup = this.formBuilder.group({
      id: [ (this.maintenance && this.maintenance.id != 0) ? this.maintenance.id: 0],
      assetId: [ (this.maintenance && this.maintenance.id != 0) ? this.maintenance.assetId: 0],
      type: [ (this.maintenance && this.maintenance.id != 0) ? this.maintenance.type: 0],
      status: [ (this.maintenance && this.maintenance.id != 0) ? this.maintenance.status: 0],
      date: [ (this.maintenance && this.maintenance.date) ? this.datepipe.transform(this.maintenance.date, "yyyy-MM-dd")?.toString().split('T', 1)[0] : new Date().toISOString().split('T', 1)[0], Validators.required],
      active: [true],
    })
  }

  save(){

    if(this.maintenance && this.maintenance.id != 0)
    {
      this.maintenancesService.update(this.formGroup.value).subscribe(
        maintenanceInserted => {
          this.router.navigateByUrl("/maintenances");
        },
        error => {
          alert("Erro ao atualizar");
        }
      )
    }else{
      this.maintenancesService.insert(this.formGroup.value).subscribe(
        maintenanceInserted => {
          this.router.navigateByUrl("/maintenances");
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
      this.maintenancesService.delete(this.maintenance.id).subscribe(
        response => {
          this.router.navigateByUrl("/maintenances")
        },
        error => {
          alert("Erro ao deletar")
        }
      )
    }
  }

  minDate(){
    return new Date().toISOString().split('T', 1)[0];
  }
}
