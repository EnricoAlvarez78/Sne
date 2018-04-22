/**
 * Componente de edição de perfil.
 *
 * @author Márcio Casale de Souza <contato@kazale.com>
 * @since 0.0.3
 */

import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'; 

import { Perfil, PerfilService } from '../shared';

@Component({
	selector: 'kz-perfil-editar',
	templateUrl: './perfil-editar.component.html',
	styleUrls: ['./perfil-editar.component.css']
})
export class PerfilEditarComponent implements OnInit {

	private id: number;
	private perfil: Perfil;

	/**
	 * Construtor.
	 *
	 * @param ActivatedRoute route
	 * @param Router router
	 * @param PerfilService perfilService
	 */
	constructor(
		private route: ActivatedRoute, 
		private router: Router, 
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
        this.perfil = result.entities ;
    }

	/**
	 * Método responsável por atualizar os dados de um perfil.
	 */
    atualizar() {
        this.perfilService.update(this.perfil);
		this.router.navigate(['/perfils']);
	}
}