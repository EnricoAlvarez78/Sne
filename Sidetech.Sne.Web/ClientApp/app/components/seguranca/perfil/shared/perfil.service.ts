import { Http } from '@angular/http';
import { Injectable, Inject } from '@angular/core';

import { Perfil } from './perfil.model';
import { GenericHttpClientService } from '../../../../shared';

@Injectable()
export class PerfilService extends GenericHttpClientService<Perfil> {

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {

        let actionUrl: string = 'Perfil';
        let apiVersion: string = 'v1';

        super(http, baseUrl, apiVersion, actionUrl);
    }
}
