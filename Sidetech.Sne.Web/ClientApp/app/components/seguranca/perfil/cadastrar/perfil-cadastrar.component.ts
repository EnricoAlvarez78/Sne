/**
 * Componente de cadastro de perfils.
 *
 * @author Márcio Casale de Souza <contato@kazale.com>
 * @since 0.0.3
 */

import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { Router } from '@angular/router'; 

import { Perfil, PerfilService } from '../shared';

@Component({
	selector: 'kz-perfil-cadastrar',
	templateUrl: './perfil-cadastrar.component.html',
	styleUrls: ['./perfil-cadastrar.component.css']
})
export class PerfilCadastrarComponent implements OnInit {

	private perfil: Perfil;

	/**
	 * Construtor.
	 *
	 * @param Router router
	 * @param PerfilService perfilService
	 */
	constructor(
		private router: Router, 
		private perfilService: PerfilService) {
	}

	/**
	 * Método executado logo após a criação do componente.
	 */
	ngOnInit() {
		this.perfil = new Perfil();
	}

	/**
	 * Método responsável por cadastrar um novo perfil.
	 */
	cadastrar() {
        this.perfil.id = new Date().getTime();
        this.perfilService.add(this.perfil);
		this.router.navigate(['/perfils']);
	}
}