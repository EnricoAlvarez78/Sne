/**
 * Componente de cadastro de perfilacessos.
 *
 * @author Márcio Casale de Souza <contato@kazale.com>
 * @since 0.0.3
 */

import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { Router } from '@angular/router'; 

import { Perfilacesso, PerfilacessoService } from '../shared';

@Component({
	selector: 'kz-perfilacesso-cadastrar',
	templateUrl: './perfilacesso-cadastrar.component.html',
	styleUrls: ['./perfilacesso-cadastrar.component.css']
})
export class PerfilacessoCadastrarComponent implements OnInit {

	private perfilacesso: Perfilacesso;

	/**
	 * Construtor.
	 *
	 * @param Router router
	 * @param PerfilacessoService perfilacessoService
	 */
	constructor(
		private router: Router, 
		private perfilacessoService: PerfilacessoService) {
	}

	/**
	 * Método executado logo após a criação do componente.
	 */
	ngOnInit() {
		this.perfilacesso = new Perfilacesso();
	}

	/**
	 * Método responsável por cadastrar um novo perfilacesso.
	 */
	cadastrar() {
		this.perfilacesso.id = new Date().getTime();
		this.perfilacessoService.cadastrar(this.perfilacesso);
		this.router.navigate(['/perfilacessos']);
	}
}