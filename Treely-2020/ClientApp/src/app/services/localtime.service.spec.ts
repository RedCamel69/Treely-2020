import { TestBed } from '@angular/core/testing';

import { LocaltimeService } from './localtime.service';

describe('LocaltimeService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LocaltimeService = TestBed.get(LocaltimeService);
    expect(service).toBeTruthy();
  });
});
