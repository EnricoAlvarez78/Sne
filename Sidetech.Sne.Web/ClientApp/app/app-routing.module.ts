import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { PerfilacessoRoutes, UsuarioRoutes, PerfilRoutes } from '../app/components';

export const routes: Routes = [
    ...PerfilacessoRoutes,
    ...UsuarioRoutes,
    ...PerfilRoutes
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }