/**
 * Componente de cadastro de usuarios.
 *
 * @author Márcio Casale de Souza <contato@kazale.com>
 * @since 0.0.3
 */

import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { Router } from '@angular/router'; 

import { Usuario, UsuarioService } from '../shared';

@Component({
	selector: 'kz-usuario-cadastrar',
	templateUrl: './usuario-cadastrar.component.html',
	styleUrls: ['./usuario-cadastrar.component.css']
})
export class UsuarioCadastrarComponent implements OnInit {

	private usuario: Usuario;

	/**
	 * Construtor.
	 *
	 * @param Router router
	 * @param UsuarioService usuarioService
	 */
	constructor(
		private router: Router, 
		private usuarioService: UsuarioService) {
	}

	/**
	 * Método executado logo após a criação do componente.
	 */
	ngOnInit() {
		this.usuario = new Usuario();
	}

	/**
	 * Método responsável por cadastrar um novo usuario.
	 */
	cadastrar() {
		//this.usuario.id = new Date().getTime();
		//this.usuarioService.cadastrar(this.usuario);
		this.router.navigate(['/usuarios']);
	}
}