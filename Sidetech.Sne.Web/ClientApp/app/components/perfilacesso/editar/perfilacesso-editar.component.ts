/**
 * Componente de edição de perfilacesso.
 *
 * @author Márcio Casale de Souza <contato@kazale.com>
 * @since 0.0.3
 */

import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'; 

import { Perfilacesso, PerfilacessoService } from '../shared';

@Component({
	selector: 'kz-perfilacesso-editar',
	templateUrl: './perfilacesso-editar.component.html',
	styleUrls: ['./perfilacesso-editar.component.css']
})
export class PerfilacessoEditarComponent implements OnInit {

	private id: number;
	private perfilacesso: Perfilacesso;

	/**
	 * Construtor.
	 *
	 * @param ActivatedRoute route
	 * @param Router router
	 * @param PerfilacessoService perfilacessoService
	 */
	constructor(
		private route: ActivatedRoute, 
		private router: Router, 
		private perfilacessoService: PerfilacessoService) {
	}

	/**
	 * Método executado logo após a criação do componente.
	 */
	ngOnInit() {
		this.id = +this.route.snapshot.params['id'];
		this.perfilacesso = this.perfilacessoService.buscarPorId(this.id);
	}

	/**
	 * Método responsável por atualizar os dados de um perfilacesso.
	 */
	atualizar() {
		this.perfilacessoService.atualizar(this.id, this.perfilacesso);
		this.router.navigate(['/perfilacessos']);
	}
}