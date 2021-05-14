import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Asset } from './asset.model';

@Injectable({
  providedIn: 'root'
})
export class AssetsService {

  private baseURL = "https://localhost:5001"
  private endpoint = "api/v1/assets"

  constructor(private httpClient: HttpClient) { }

  list():Observable<Asset[]>{
    return this.httpClient.get<Asset[]>(`${this.baseURL}/${this.endpoint}`);
  }

  insert(asset: Asset): Observable<Asset>{
    return this.httpClient.post<Asset>(`${this.baseURL}/${this.endpoint}`, asset);
  }

  getById(id: number): Observable<Asset>{
    return this.httpClient.get<Asset>(`${this.baseURL}/${this.endpoint}/${id}`); 
  }

  update(asset: Asset): Observable<Asset>{
    return this.httpClient.put<Asset>(`${this.baseURL}/${this.endpoint}`, asset);
  }

  delete(id: number){
    return this.httpClient.delete(`${this.baseURL}/${this.endpoint}/${id}`); 
  }

}
