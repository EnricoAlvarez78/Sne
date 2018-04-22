/**
 * Arquivo de teste do componente UsuarioVisualizarComponent.
 *
 * @author Márcio Casale de Souza <contato@kazale.com>
 * @since 0.0.3
 */

import { TestBed, ComponentFixture } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';

import { UsuarioVisualizarComponent } from './';
import { UsuarioService } from '../';
import { 
	RouterLinkStubDirective,
	ActivatedRouteStub
} from '../../../../shared/index';

describe('UsuarioVisualizar', () => {

  let fixture: ComponentFixture<UsuarioVisualizarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({ 
    	declarations: [ 
    		UsuarioVisualizarComponent,
    		RouterLinkStubDirective
    	],
    	providers:    [
    	  UsuarioService,
    	  { 
    	  	provide: ActivatedRoute, 
    	  	useValue: new ActivatedRouteStub() 
    	  }
    	]
    });

    fixture = TestBed.createComponent(UsuarioVisualizarComponent);
  });

  it('deve garantir que o componente tenha sido criado', () => {
    expect(fixture).toBeDefined();
  });
  
});
