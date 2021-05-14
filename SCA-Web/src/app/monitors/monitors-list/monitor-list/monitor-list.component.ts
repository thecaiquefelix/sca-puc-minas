import { Component, OnInit, ViewChild, ElementRef  } from '@angular/core';
import { Chart } from 'chart.js';

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

  constructor() { }

  ngOnInit(){

    new Chart(this.deslocamento.nativeElement, {
      type: 'line',
      data: {
        labels: ["22:00","22:01","22:02","22:03","22:04","22:05","22:06","22:07","22:09","22:10"],
        datasets: [
          {
            data: [85,72,86,81,84,86,94,60,62,65],
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
        labels: ["22:00","22:01","22:02","22:03","22:04","22:05","22:06","22:07","22:09","22:10"],
        datasets: [
          {
            data: [85,72,86,81,84,86,94,60,62,65],
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
        labels: ["22:00","22:01","22:02","22:03","22:04","22:05","22:06","22:07","22:09","22:10"],
        datasets: [
          {
            data: [85,72,86,81,84,86,94,60,62,65],
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
        labels: ["22:00","22:01","22:02","22:03","22:04","22:05","22:06","22:07","22:09","22:10"],
        datasets: [
          {
            data: [85,72,86,81,84,86,94,60,62,65],
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
