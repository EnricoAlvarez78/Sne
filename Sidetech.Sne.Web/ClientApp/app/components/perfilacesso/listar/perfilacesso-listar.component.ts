/**
 * Componente de listagem de perfilacessos.
 *
 * @author Márcio Casale de Souza <contato@kazale.com>
 * @since 0.0.3
 */

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Perfilacesso, PerfilacessoService } from '../shared';
import { KzPaginacaoComponent } from '../../../shared';

@Component({
	selector: 'kz-perfilacesso-listar',
	templateUrl: './perfilacesso-listar.component.html',
	styleUrls: ['./perfilacesso-listar.component.css']
})
export class PerfilacessoListarComponent implements OnInit {

	private perfilacessos: Perfilacesso[];
    private idExcluir: number;

	private pagina: number;
	private totalRegistros: number;
    //sorting
    private key: string = 'id'; //set default
    private reverse: boolean = false;

	/**
	 * Construtor.
	 *
	 * @param PerfilacessoService perfilacessoService
	 */
	constructor(private perfilacessoService: PerfilacessoService,
		private route: ActivatedRoute) {
	}

	/**
	 * Método executado logo após a criação do componente.
	 */
	ngOnInit() {
		this.totalRegistros = this.perfilacessoService.totalRegistros();
		this.pagina = +this.route.snapshot.queryParams['pagina'] || KzPaginacaoComponent.PAG_PADRAO;
		this.perfilacessos = this.perfilacessoService.listarParcial(
            --this.pagina, KzPaginacaoComponent.TOTAL_PAGS_PADRAO);
    }

	/**
	 * Método responsável por armazenar o id do perfilacesso a 
	 * removido.
	 *
	 * @param number id
	 */
	excluir(id: number) {
 		this.idExcluir = id;
 	}

 	/**
	 * Método responsável por remover um perfilacesso.
	 */
 	onExcluir() {
 		this.perfilacessoService.excluir(this.idExcluir);
 		location.reload();
 	}

 	/**
 	 * Método responsável pela paginação.
 	 *
 	 * @param any $event Número da página atual.
 	 */
 	paginar($event: any) {
		this.pagina = $event - 1;
		this.totalRegistros = this.perfilacessoService.totalRegistros();
		this.perfilacessos = this.perfilacessoService.listarParcial(
			this.pagina, KzPaginacaoComponent.TOTAL_PAGS_PADRAO);
	}

    sort(key : any) {
        this.key = key;
        this.reverse = !this.reverse;
    }
}