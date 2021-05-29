import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Contact } from './contact-model';

@Injectable({
  providedIn: 'root'
})
export class ContactsService {

  private baseURL = "https://localhost:5001"
  private endpoint = "api/v1/contacts"

  constructor(private httpClient: HttpClient) { }

  insert(contact: Contact): Observable<Contact>{
    return this.httpClient.post<Contact>(`${this.baseURL}/${this.endpoint}`, contact);
  }

}
