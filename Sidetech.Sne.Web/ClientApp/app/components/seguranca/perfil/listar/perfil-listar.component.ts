import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Perfil, PerfilService } from '../shared';
import { PaginationComponent, PaginationModel, SortDirection, Dictionary } from '../../../../shared';

@Component({
	selector: 'kz-perfil-listar',
	templateUrl: './perfil-listar.component.html',
	styleUrls: ['./perfil-listar.component.css']
})
export class PerfilListarComponent implements OnInit {
    private perfils: Perfil[];
    private paginationModel: PaginationModel;
    private idExcluir: number;

    constructor(private perfilService: PerfilService) { }  

    ngOnInit(): void {
        this.perfils = [];

        this.paginationModel = new PaginationModel();
        this.paginationModel.pageIndex = 1;
        this.paginationModel.pageSize = 10;
        this.paginationModel.sortField = 'id';
        this.paginationModel.sortDirection = SortDirection.Descending.toString();
        this.paginationModel.filters = {};
        this.paginationModel.total = 0;

        this.buscar();
    }

    goToPage(n: number): void {
        this.paginationModel.pageIndex = n;
        this.buscar();
    }

    onNext(): void {
        this.paginationModel.pageIndex++;
        this.buscar();
    }

    onPrev(): void {
        this.paginationModel.pageIndex--;
        this.buscar();
    }

    /**
     * Método responsável pela ordenação.
     *
     * @param any key coluna que será ordenada.
     */
    ordenar(coluna: any) {
        this.paginationModel.sortField = coluna;
        this.paginationModel.sortDirection = this.paginationModel.sortDirection === SortDirection.Ascending.toString() ?
                                                                                        SortDirection.Descending.toString() :
                                                                                        SortDirection.Ascending.toString();
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
                    this.paginationModel.filters[JSON.stringify(filtro.name)] = JSON.stringify(filtro.value);
                }
            }

            this.goToPage(1);
        }
    }

    /**
    * Método responsável por remover filtros
    */
    limparPesquisar() {
        this.paginationModel.filters = {};
        this.goToPage(1);
    }

    async buscar() {
        const result = await this.perfilService.getMany(this.paginationModel);
        this.perfils = result.entities;
        this.paginationModel.total = result.totalAmount;
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
        this.perfilService.delete(this.idExcluir);
        location.reload();
    }
}