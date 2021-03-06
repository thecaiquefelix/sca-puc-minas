import { Component, OnInit, ViewChild, ElementRef  } from '@angular/core';
import { Chart } from 'chart.js';
import { interval, Observable } from 'rxjs';
import { MonitorsService } from '../../monitors.service';
import { Monitor } from '../../monitors.model';
import { DatePipe } from '@angular/common';
import { Status } from 'src/app/maintenances/maintenance.model';

@Component({
  selector: 'app-monitor-list',
  templateUrl: './monitor-list.component.html',
  styleUrls: ['./monitor-list.component.scss']
})
export class MonitorListComponent implements OnInit {

  @ViewChild("deslocamento", { static: true }) deslocamento!: ElementRef;
  @ViewChild("piezometro", { static: true }) piezometro!: ElementRef;
  @ViewChild("inclinometro", { static: true }) inclinometro!: ElementRef;
  @ViewChild("agua", { static: true }) agua!: ElementRef;

  selectedDam = 1;

  displacement$: Monitor[] = [];
  piezometer$: Monitor[] = [];
  inclinometer$: Monitor[] = [];
  water$: Monitor[] = [];

  messageDisplacement$!: string;
  messagePiezometer$!: string;
  messageInclinometer$!: string;
  messageWater$!: string;

  constructor(private monitorsService: MonitorsService, public datepipe: DatePipe) { }

  ngOnInit(){
    const obs$ = interval(1000);
      obs$.subscribe(() => {
        this.list();
        this.load();
      });
  }

  list(){
   
    this.monitorsService.listDisplacement(this.selectedDam).subscribe((result) => {
      this.displacement$ = result.monitors;
      this.messageDisplacement$ = result.message;
    });

    this.monitorsService.listPiezometer(this.selectedDam).subscribe((result) => {
      this.piezometer$ = result.monitors;
      this.messagePiezometer$ = result.message;
    });

    this.monitorsService.listInclinometer(this.selectedDam).subscribe((result) => {
      this.inclinometer$ = result.monitors;
      this.messageInclinometer$ = result.message;
    });

    this.monitorsService.listWater(this.selectedDam).subscribe((result) => {
      this.water$ = result.monitors;
      this.messageWater$ = result.message;
    });

  }

  load(){
    
    new Chart(this.deslocamento.nativeElement, {
      type: 'line',
      data: {
        labels: this.displacement$.map((a) => {return this.datepipe.transform(a.date, 'hh:mm:ss')!}),
        datasets: [
          {
            data: this.displacement$.map(function(a) {return a.value;}),
            borderColor: '#673ab7',
            fill: false
          }
        ]
      },
      options: {
        legend: {
          display: false
        },
        title: {
          display: true,
          text: 'Deslocamento'
        }
      }
    });

    new Chart(this.piezometro.nativeElement, {
      type: 'line',
      data: {
        labels: this.piezometer$.map((a) => {return this.datepipe.transform(a.date, 'hh:mm:ss')!}),
        datasets: [
          {
            data: this.piezometer$.map(function(a) {return a.value;}),
            borderColor: '#673ab7',
            fill: false
          }
        ]
      },
      options: {
        legend: {
          display: false
        },
        title: {
          display: true,
          text: 'Piezometro'
        }
      }
    });

    new Chart(this.inclinometro.nativeElement, {
      type: 'line',
      data: {
        labels: this.inclinometer$.map((a) => {return this.datepipe.transform(a.date, 'hh:mm:ss')!}),
        datasets: [
          {
            data: this.inclinometer$.map(function(a) {return a.value;}),
            borderColor: '#673ab7',
            fill: false
          }
        ]
      },
      options: {
        legend: {
          display: false
        },
        title: {
          display: true,
          text: 'Inclinometro'
        }
      }
    });

    new Chart(this.agua.nativeElement, {
      type: 'line',
      data: {
        labels: this.water$.map((a) => {return this.datepipe.transform(a.date, 'hh:mm:ss')!}),
        datasets: [
          {
            data: this.water$.map(function(a) {return a.value;}),
            borderColor: '#673ab7',
            fill: false
          }
        ]
      },
      options: {
        legend: {
          display: false
        },
        title: {
          display: true,
          text: 'Nivel de Agua'
        }
      }
    });

  }

}
