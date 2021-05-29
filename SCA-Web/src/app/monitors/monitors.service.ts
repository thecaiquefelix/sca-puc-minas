import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Monitor } from './monitors.model';

export interface MonitorResponse
{
    monitors: Monitor[],
    message:string
}

@Injectable({
  providedIn: 'root'
})
export class MonitorsService {

  private baseURL = "https://localhost:5001"

  constructor(private httpClient: HttpClient) { }

  listDisplacement(dam:number):Observable<MonitorResponse>{
    return this.httpClient.get<MonitorResponse>(`${this.baseURL}/api/v1/monitors/dam/${dam}/metric/1`);    
  }

  listPiezometer(dam:number):Observable<MonitorResponse>{
    return this.httpClient.get<MonitorResponse>(`${this.baseURL}/api/v1/monitors/dam/${dam}/metric/2`);
  }

  listInclinometer(dam:number):Observable<MonitorResponse>{
    return this.httpClient.get<MonitorResponse>(`${this.baseURL}/api/v1/monitors/dam/${dam}/metric/3`);
  }

  listWater(dam:number):Observable<MonitorResponse>{
    return this.httpClient.get<MonitorResponse>(`${this.baseURL}/api/v1/monitors/dam/${dam}/metric/4`);
  }
  
}
