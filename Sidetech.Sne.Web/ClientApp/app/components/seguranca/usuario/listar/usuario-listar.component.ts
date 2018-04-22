import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Usuario, UsuarioService } from '../shared';
import { PaginationComponent, PaginationModel } from '../../../../shared';
import { Dictionary } from '../../../../shared/interfaces';

@Component({
	selector: 'kz-usuario-listar',
	templateUrl: './usuario-listar.component.html',
	styleUrls: ['./usuario-listar.component.css']
})
export class UsuarioListarComponent implements OnInit {

    /**
    * Array do modelo de estado
    */
    private usuarios: Usuario[];

    /**
    * Propriedades de paginação
    */
    private loading : boolean;
    private total: number;
    private page: number;
    private limit: number;

    /**
    * Prorpiedades de ordenação
    */
    private coluna: string;
    private sentido: boolean;

    /**
    * Dictionary de filtro de dados
    */
    private filtro: Dictionary<string>;

    /**
    * 
    */
	private idExcluir: number;

    constructor(private usuarioService: UsuarioService) {
    }

    ngOnInit(): void {
        this.usuarios = [];
        this.loading = false;
        this.total = 0;
        this.page = 1;
        this.limit = 10;
        this.coluna = 'id';
        this.sentido = false;
        this.filtro = {};

        this.buscar();
    }

    goToPage(n: number): void {
        this.page = n;
        this.buscar();
    }

    onNext(): void {
        this.page++;
        this.buscar();
    }

    onPrev(): void {
        this.page--;
        this.buscar();
    }

    /**
     * Método responsável pela ordenação.
     *
     * @param any key coluna que será ordenada.
     */
    ordenar(coluna: any) {
        this.coluna = coluna;
        this.sentido = !this.sentido;
        this.buscar();
    }

    /**
    * Método responsável pela criação do array de filtros
    */
    filtrar() {
        var filtros = document.getElementsByClassName('valorFiltro');
        if (filtros !== null && filtros.length > 0) {
            for (var i = 0, len = filtros.length; i < len; i++) {
                let filtro = (filtros[i] as HTMLInputElement)
                if (filtro.name !== "" && filtro.value !== "") {
                    this.filtro[JSON.stringify(filtro.name)] = JSON.stringify(filtro.value);
                }
            }   

            this.goToPage(1);
        }
    }

    /**
    * Método responsável por remover filtros
    */
    limparPesquisar() {
        this.filtro = {};
        this.goToPage(1);
    }

    /**
    * Método responsável pela chamada do serviço httpclient genérico
    */
    async buscar() {
        this.loading = true;
        let paginationModel: PaginationModel = new PaginationModel();
        paginationModel.pageIndex = this.page;
        paginationModel.pageSize = this.limit;
        paginationModel.sortField = this.coluna;
        paginationModel.sortDirection = this.sentido ? 'Ascending' : 'Descending';
        paginationModel.filters = this.filtro;

        let result = await this.usuarioService.getMany(paginationModel);

        this.usuarios = result.entities;
        this.total = result.totalAmount;
    }

	/**
	 * Método responsável por armazenar o id do usuario a 
	 * removido.
	 *
	 * @param number id
	 */
	excluir(id: number) {
 		this.idExcluir = id;
 	}

 	/**
	 * Método responsável por remover um usuario.
	 */
    onExcluir() {
        this.usuarioService.delete(this.idExcluir);
 		location.reload();
    }
}