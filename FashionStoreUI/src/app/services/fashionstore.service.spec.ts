import { TestBed } from '@angular/core/testing';

import { FashionstoreService } from './fashionstore.service';

describe('FashionstoreService', () => {
  let service: FashionstoreService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FashionstoreService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
