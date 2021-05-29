import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NotificationsService {

  private baseURL = "https://localhost:5001"
  private endpoint = "api/v1/notifications"

  constructor(private httpClient: HttpClient) { }

  insert(notification: Notification): Observable<Notification>{
    return this.httpClient.post<Notification>(`${this.baseURL}/${this.endpoint}`, notification);
  }
  
  list():Observable<Notification[]>{
    return this.httpClient.get<Notification[]>(`${this.baseURL}/${this.endpoint}`)
  }

  getById(id: number): Observable<Notification>{
    return this.httpClient.get<Notification>(`${this.baseURL}/${this.endpoint}/${id}`); 
  }

}
