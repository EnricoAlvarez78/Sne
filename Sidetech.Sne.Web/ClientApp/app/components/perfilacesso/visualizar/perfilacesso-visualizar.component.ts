/**
 * Componente de visualização de perfilacesso.
 *
 * @author Márcio Casale de Souza <contato@kazale.com>
 * @since 0.0.3
 */

import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Perfilacesso, PerfilacessoService } from '../shared';

@Component({
	selector: 'kz-perfilacesso-visualizar',
	templateUrl: './perfilacesso-visualizar.component.html',
	styleUrls: ['./perfilacesso-visualizar.component.css']
})
export class PerfilacessoVisualizarComponent implements OnInit {

	private id: number;
	private perfilacesso: Perfilacesso;

	/**
	 * Construtor.
	 *
	 * @param ActivatedRoute route
	 * @param PerfilacessoService perfilacessoService
	 */
	constructor(
		private route: ActivatedRoute, 
		private perfilacessoService: PerfilacessoService) {
	}

	/**
	 * Método executado logo após a criação do componente.
	 */
	ngOnInit() {
		this.id = +this.route.snapshot.params['id'];
		this.perfilacesso = this.perfilacessoService.buscarPorId(this.id);
	}
}