import { TestBed } from '@angular/core/testing';

import { UrlBaseService } from './url-base.service';

describe('UrlBaseServiceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: UrlBaseService = TestBed.get(UrlBaseService);
    expect(service).toBeTruthy();
  });
});
