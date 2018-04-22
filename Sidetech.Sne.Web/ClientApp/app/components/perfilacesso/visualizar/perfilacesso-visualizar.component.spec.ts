/**
 * Arquivo de teste do componente PerfilacessoVisualizarComponent.
 *
 * @author Márcio Casale de Souza <contato@kazale.com>
 * @since 0.0.3
 */

import { TestBed, ComponentFixture } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';

import { PerfilacessoVisualizarComponent } from './';
import { PerfilacessoService } from '../';
import { 
	RouterLinkStubDirective,
	ActivatedRouteStub
} from '../../../shared/index';

describe('PerfilacessoVisualizar', () => {

  let fixture: ComponentFixture<PerfilacessoVisualizarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({ 
    	declarations: [ 
    		PerfilacessoVisualizarComponent,
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

    fixture = TestBed.createComponent(PerfilacessoVisualizarComponent);
  });

  it('deve garantir que o componente tenha sido criado', () => {
    expect(fixture).toBeDefined();
  });
  
});
