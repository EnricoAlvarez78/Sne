/**
 * Arquivo de teste do componente PerfilListarComponent.
 *
 * @author Márcio Casale de Souza <contato@kazale.com>
 * @since 0.0.3
 */

import { TestBed, ComponentFixture } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';

import { PerfilListarComponent } from './';
import { PerfilService } from '../';
import { 
	ModalUtilComponent, 
	KzPaginacaoComponent,
	RouterLinkStubDirective,
	ActivatedRouteStub
} from '../../../../shared/index';

describe('PerfilListar', () => {

  let fixture: ComponentFixture<PerfilListarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({ 
    	declarations: [ 
    		PerfilListarComponent,
    		ModalUtilComponent,
    		KzPaginacaoComponent,
    		RouterLinkStubDirective
    	],
    	providers:    [
    	  PerfilService,
    	  { 
    	  	provide: ActivatedRoute, 
    	  	useValue: new ActivatedRouteStub() 
    	  }
    	]
    });

    fixture = TestBed.createComponent(PerfilListarComponent);
  });

  it('deve garantir que o componente tenha sido criado', () => {
    expect(fixture).toBeDefined();
  });
  
});
