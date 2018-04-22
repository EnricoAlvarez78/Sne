/**
 * Arquivo de configuração do módulo.
 *
 * @author Márcio Casale de Souza <contato@kazale.com>
 * @since 0.0.3
 */

import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { 
	PerfilCadastrarComponent,
	PerfilEditarComponent,
	PerfilListarComponent,
	PerfilVisualizarComponent,
	PerfilService
} from './';

import { SharedModule } from '../../../shared';

@NgModule({
	imports: [ 
		RouterModule,
		SharedModule
	],
	declarations: [
		PerfilCadastrarComponent,
		PerfilEditarComponent,
		PerfilListarComponent,
		PerfilVisualizarComponent
	],
	providers: [
		PerfilService
	]
})
export class PerfilModule {}
