/**
 * Arquivo de teste do componente PerfilVisualizarComponent.
 *
 * @author Márcio Casale de Souza <contato@kazale.com>
 * @since 0.0.3
 */

import { TestBed, ComponentFixture } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';

import { PerfilVisualizarComponent } from './';
import { PerfilService } from '../';
import { 
	RouterLinkStubDirective,
	ActivatedRouteStub
} from '../../../../shared/index';

describe('PerfilVisualizar', () => {

  let fixture: ComponentFixture<PerfilVisualizarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({ 
    	declarations: [ 
    		PerfilVisualizarComponent,
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

    fixture = TestBed.createComponent(PerfilVisualizarComponent);
  });

  it('deve garantir que o componente tenha sido criado', () => {
    expect(fixture).toBeDefined();
  });
  
});
