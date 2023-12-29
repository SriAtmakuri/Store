import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FashionStoreComponent } from './fashion-store.component';

describe('FashionStoreComponent', () => {
  let component: FashionStoreComponent;
  let fixture: ComponentFixture<FashionStoreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FashionStoreComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FashionStoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
