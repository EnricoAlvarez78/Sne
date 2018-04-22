import { Routes } from '@angular/router'; 

import { 
	UsuarioListarComponent,
	UsuarioCadastrarComponent,
	UsuarioEditarComponent,
	UsuarioVisualizarComponent
} from './';

export const UsuarioRoutes: Routes = [
	{ path: 'usuarios', redirectTo: 'usuarios/listar' },
	{ path: 'usuarios/listar', component: UsuarioListarComponent }, 
	{ path: 'usuarios/cadastrar', component: UsuarioCadastrarComponent }, 
	{ path: 'usuarios/editar/:id', component: UsuarioEditarComponent },
	{ path: 'usuarios/visualizar/:id', component: UsuarioVisualizarComponent }
];
