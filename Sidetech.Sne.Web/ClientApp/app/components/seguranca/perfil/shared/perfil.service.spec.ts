import { Http } from '@angular/http';
import { TestBed } from '@angular/core/testing';

import { PerfilService } from './perfil.service';

describe('PerfilService', () => {

    let perfilService: PerfilService;

    let _http: Http;
    let _baseUrl: string;

  beforeEach(() => {
    perfilService = new PerfilService(_http, _baseUrl);
  });

  it ('deve criar o PerfilService', () => {
    //TODO
  });
  
});
