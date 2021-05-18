import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Maintenance } from './maintenance.model';
import { Asset } from '../assets/asset.model';

@Injectable({
  providedIn: 'root'
})
export class MaintenancesService {
 
  private baseURL = "https://localhost:5001"
  private endpoint = "api/v1/maintenances";
  private endpointAssets = "api/v1/assets";

  constructor(private httpClient: HttpClient) { }

  listAssets():Observable<Asset[]>{
    return this.httpClient.get<Asset[]>(`${this.baseURL}/${this.endpointAssets}`);
  }

  list():Observable<Maintenance[]>{
    return this.httpClient.get<Maintenance[]>(`${this.baseURL}/${this.endpoint}`)
  }

  insert(maintenance: Maintenance): Observable<Maintenance>{
    return this.httpClient.post<Maintenance>(`${this.baseURL}/${this.endpoint}`, maintenance);
  }

  getById(id: number): Observable<Maintenance>{
    return this.httpClient.get<Maintenance>(`${this.baseURL}/${this.endpoint}/${id}`); 
  }

  update(maintenance: Maintenance): Observable<Maintenance>{
    return this.httpClient.put<Maintenance>(`${this.baseURL}/${this.endpoint}`, maintenance);
  }

  delete(id: number){
    return this.httpClient.delete(`${this.baseURL}/${this.endpoint}/${id}`); 
  }

}
