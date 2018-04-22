/**
 * Arquivo de configuração do módulo.
 *
 * @author Márcio Casale de Souza <contato@kazale.com>
 * @since 0.0.3
 */

import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { 
	PerfilacessoCadastrarComponent,
	PerfilacessoEditarComponent,
	PerfilacessoListarComponent,
	PerfilacessoVisualizarComponent,
	PerfilacessoService
} from './';

import { SharedModule } from '../../shared';

@NgModule({
	imports: [ 
		RouterModule,
		SharedModule
	],
	declarations: [
		PerfilacessoCadastrarComponent,
		PerfilacessoEditarComponent,
		PerfilacessoListarComponent,
		PerfilacessoVisualizarComponent
	],
	providers: [
		PerfilacessoService
	]
})
export class PerfilacessoModule {}
