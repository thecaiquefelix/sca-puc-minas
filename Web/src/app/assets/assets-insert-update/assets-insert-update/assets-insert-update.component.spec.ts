import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssetsInsertUpdateComponent } from './assets-insert-update.component';

describe('AssetsInsertUpdateComponent', () => {
  let component: AssetsInsertUpdateComponent;
  let fixture: ComponentFixture<AssetsInsertUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AssetsInsertUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AssetsInsertUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
