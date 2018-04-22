/**
 * Arquivo de teste do componente UsuarioListarComponent.
 *
 * @author Márcio Casale de Souza <contato@kazale.com>
 * @since 0.0.3
 */

import { TestBed, ComponentFixture } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';

import { UsuarioListarComponent } from './';
import { UsuarioService } from '../';
import { 
	ModalUtilComponent, 
	KzPaginacaoComponent,
	RouterLinkStubDirective,
	ActivatedRouteStub
} from '../../../../shared/index';

describe('UsuarioListar', () => {

  let fixture: ComponentFixture<UsuarioListarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({ 
    	declarations: [ 
    		UsuarioListarComponent,
    		ModalUtilComponent,
    		KzPaginacaoComponent,
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

    fixture = TestBed.createComponent(UsuarioListarComponent);
  });

  it('deve garantir que o componente tenha sido criado', () => {
    expect(fixture).toBeDefined();
  });
  
});
