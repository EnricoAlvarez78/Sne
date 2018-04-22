/**
 * Componente de edição de usuario.
 *
 * @author Márcio Casale de Souza <contato@kazale.com>
 * @since 0.0.3
 */

import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'; 

import { Usuario, UsuarioService } from '../shared';

@Component({
	selector: 'kz-usuario-editar',
	templateUrl: './usuario-editar.component.html',
	styleUrls: ['./usuario-editar.component.css']
})
export class UsuarioEditarComponent implements OnInit {

	private id: number;
	private usuario: Usuario;

	/**
	 * Construtor.
	 *
	 * @param ActivatedRoute route
	 * @param Router router
	 * @param UsuarioService usuarioService
	 */
	constructor(
		private route: ActivatedRoute, 
		private router: Router, 
		private usuarioService: UsuarioService) {
	}

	/**
	 * Método executado logo após a criação do componente.
	 */
	ngOnInit() {
		this.id = +this.route.snapshot.params['id'];
		//this.usuario = this.usuarioService.buscarPorId(this.id);
	}

	/**
	 * Método responsável por atualizar os dados de um usuario.
	 */
	atualizar() {
		//this.usuarioService.atualizar(this.id, this.usuario);
		this.router.navigate(['/usuarios']);
	}
}