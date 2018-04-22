/**
 * Arquivo de configuração de rotas.
 *
 * @author Márcio Casale de Souza <contato@kazale.com>
 * @since 0.0.3
 */

import { Routes } from '@angular/router'; 

import { 
	PerfilacessoListarComponent,
	PerfilacessoCadastrarComponent,
	PerfilacessoEditarComponent,
	PerfilacessoVisualizarComponent
} from './';

export const PerfilacessoRoutes: Routes = [
	{ path: 'perfilacessos', redirectTo: 'perfilacessos/listar' },
	{ path: 'perfilacessos/listar', component: PerfilacessoListarComponent }, 
	{ path: 'perfilacessos/cadastrar', component: PerfilacessoCadastrarComponent }, 
	{ path: 'perfilacessos/editar/:id', component: PerfilacessoEditarComponent },
	{ path: 'perfilacessos/visualizar/:id', component: PerfilacessoVisualizarComponent }
];
