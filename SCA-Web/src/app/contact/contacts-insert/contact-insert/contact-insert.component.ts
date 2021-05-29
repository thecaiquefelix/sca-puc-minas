import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ContactsService } from '../../contacts.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-contact-insert',
  templateUrl: './contact-insert.component.html',
  styleUrls: ['./contact-insert.component.scss']
})
export class ContactInsertComponent implements OnInit {

  formGroup!: FormGroup;
  
  constructor(private formBuilder: FormBuilder, 
              private contactsService: ContactsService,
              private router: Router) { }


ngOnInit(){
  this.formGroup = this.formBuilder.group({
    damId: [ 1 , Validators.required],
    phone: [ "", Validators.required]
  })
}

save()
{
  this.contactsService.insert(this.formGroup.value).subscribe(
    contactInserted => {
      this.router.navigateByUrl("/notifications");
    },
    error => {
      alert("Erro ao adicionar o contato");
    }
  )
}

}
