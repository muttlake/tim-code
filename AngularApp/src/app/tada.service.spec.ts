import { TestBed, inject } from '@angular/core/testing';

import { TadaService } from './tada.service';

describe('TadaService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TadaService]
    });
  });

  it('should be created', inject([TadaService], (service: TadaService) => {
    expect(service).toBeTruthy();
  }));
});
