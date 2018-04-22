/**
 * Arquivo de configuração de rotas.
 *
 * @author Márcio Casale de Souza <contato@kazale.com>
 * @since 0.0.3
 */

import { Routes } from '@angular/router'; 

import { 
	PerfilListarComponent,
	PerfilCadastrarComponent,
	PerfilEditarComponent,
	PerfilVisualizarComponent
} from './';

export const PerfilRoutes: Routes = [
	{ path: 'perfils', redirectTo: 'perfils/listar' },
	{ path: 'perfils/listar', component: PerfilListarComponent }, 
	{ path: 'perfils/cadastrar', component: PerfilCadastrarComponent }, 
	{ path: 'perfils/editar/:id', component: PerfilEditarComponent },
	{ path: 'perfils/visualizar/:id', component: PerfilVisualizarComponent }
];
