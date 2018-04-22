/**
 * Arquivo de configuração do módulo.
 *
 * @author Márcio Casale de Souza <contato@kazale.com>
 * @since 0.0.3
 */

import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { 
	UsuarioCadastrarComponent,
	UsuarioEditarComponent,
	UsuarioListarComponent,
	UsuarioVisualizarComponent,
	UsuarioService
} from './';

import { SharedModule } from '../../../shared';

@NgModule({
	imports: [ 
		RouterModule,
		SharedModule
	],
	declarations: [
		UsuarioCadastrarComponent,
		UsuarioEditarComponent,
		UsuarioListarComponent,
		UsuarioVisualizarComponent
	],
	providers: [
		UsuarioService
	]
})
export class UsuarioModule {}
