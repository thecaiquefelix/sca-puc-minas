import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MaintenanceInsertUpdateComponent } from './maintenance-insert-update.component';

describe('MaintenanceInsertUpdateComponent', () => {
  let component: MaintenanceInsertUpdateComponent;
  let fixture: ComponentFixture<MaintenanceInsertUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MaintenanceInsertUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MaintenanceInsertUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
