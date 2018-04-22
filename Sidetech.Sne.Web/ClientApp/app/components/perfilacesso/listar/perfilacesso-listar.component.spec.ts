/**
 * Arquivo de teste do componente PerfilacessoListarComponent.
 *
 * @author Márcio Casale de Souza <contato@kazale.com>
 * @since 0.0.3
 */

import { TestBed, ComponentFixture } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';

import { PerfilacessoListarComponent } from './';
import { PerfilacessoService } from '../';
import { 
	ModalUtilComponent, 
	KzPaginacaoComponent,
	RouterLinkStubDirective,
	ActivatedRouteStub
} from '../../../shared/index';

describe('PerfilacessoListar', () => {

  let fixture: ComponentFixture<PerfilacessoListarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({ 
    	declarations: [ 
    		PerfilacessoListarComponent,
    		ModalUtilComponent,
    		KzPaginacaoComponent,
    		RouterLinkStubDirective
    	],
    	providers:    [
    	  PerfilacessoService,
    	  { 
    	  	provide: ActivatedRoute, 
    	  	useValue: new ActivatedRouteStub() 
    	  }
    	]
    });

    fixture = TestBed.createComponent(PerfilacessoListarComponent);
  });

  it('deve garantir que o componente tenha sido criado', () => {
    expect(fixture).toBeDefined();
  });
  
});
