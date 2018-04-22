import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Perfil, PerfilService } from '../shared';

@Component({
	selector: 'kz-perfil-visualizar',
	templateUrl: './perfil-visualizar.component.html',
	styleUrls: ['./perfil-visualizar.component.css']
})
export class PerfilVisualizarComponent implements OnInit {

	private id: number;
	private perfil: Perfil;

	/**
	 * Construtor.
	 *
	 * @param ActivatedRoute route
	 * @param PerfilService perfilService
	 */
	constructor(
		private route: ActivatedRoute, 
		private perfilService: PerfilService) {
	}

	/**
	 * Método executado logo após a criação do componente.
	 */
	ngOnInit() {
		this.id = +this.route.snapshot.params['id'];
		this.buscarPorId(this.id);
    }

    async buscarPorId(id: number) {
        const result = await this.perfilService.getById(this.id);
        this.perfil = result.entities;
    }
}