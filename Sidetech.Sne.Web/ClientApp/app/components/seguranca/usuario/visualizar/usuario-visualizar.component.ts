/**
 * Componente de visualização de usuario.
 *
 * @author Márcio Casale de Souza <contato@kazale.com>
 * @since 0.0.3
 */

import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Usuario, UsuarioService } from '../shared';

@Component({
	selector: 'kz-usuario-visualizar',
	templateUrl: './usuario-visualizar.component.html',
	styleUrls: ['./usuario-visualizar.component.css']
})
export class UsuarioVisualizarComponent implements OnInit {

	private id: number;
	private usuario: Usuario;

	/**
	 * Construtor.
	 *
	 * @param ActivatedRoute route
	 * @param UsuarioService usuarioService
	 */
	constructor(
		private route: ActivatedRoute, 
		private usuarioService: UsuarioService) {
	}

	/**
	 * Método executado logo após a criação do componente.
	 */
	ngOnInit() {
		this.id = +this.route.snapshot.params['id'];
		//this.usuario = this.usuarioService.buscarPorId(this.id);
	}
}