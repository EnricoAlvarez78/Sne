/**
 * Componente de listagem de #MODULO#s.
 *
 * @author Márcio Casale de Souza <contato@kazale.com>
 * @since 0.0.3
 */

/*#import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { #MODULO_CAP#, #MODULO_CAP#Service } from '../shared';
import { KzPaginacaoComponent } from '../../../shared';

@Component({
	selector: 'kz-#MODULO#-listar',
	templateUrl: './#MODULO#-listar.component.html',
	styleUrls: ['./#MODULO#-listar.component.css']
})
export class #MODULO_CAP#ListarComponent implements OnInit {#*/
    /**
    * Array do modelo de estado
    */
    /*#private #MODULO#s: #MODULO_CAP#[];#*/

    /**
    * Propriedades de paginação
    */
    /*#private paginaAtual: number;
	private pagina: number;
    private totalRegistros: number;#*/

    /**
    * Prorpiedades de ordenação
    */
    /*#private coluna: string;
    private sentido: boolean;#*/

    /**
    * id do #MODULO#
    */
	/*#private idExcluir: number;#*/

	/**
	 * Construtor.
	 *
	 * @param #MODULO_CAP#Service #MODULO#Service
	 */
	/*#constructor(private #MODULO#Service: #MODULO_CAP#Service, private route: ActivatedRoute) {}#*/

	/**
	 * Método executado logo após a criação do componente.
	 */
	/*#ngOnInit() {
        this.usuarios = [];
        this.paginaAtual = KzPaginacaoComponent.PAG_PADRAO;
        this.pagina = KzPaginacaoComponent.TOTAL_PAGS_PADRAO;
        this.coluna = 'id';
        this.sentido = false;

        this.buscar();
	}#*/

 	/**
 	 * Método responsável pela paginação.
 	 *
 	 * @param any $event Número da página atual.
 	 */
 	/*#paginar($event: any) {
		this.paginaAtual = $event;

        this.buscar();
	}#*/

    /**
     * Método responsável pela ordenação.
     *
     * @param any key coluna que será ordenada.
     */
    /*#ordenar(coluna: any) {
        this.coluna = coluna;
        this.sentido = !this.sentido;

        this.buscar();
    }#*/

    /**
    * Método responsável pela chamada do serviço httpclient genérico
    */
    /*#async buscar() {
        let paginationModel: PaginationModel = new PaginationModel();
        paginationModel.pageIndex = this.paginaAtual;
        paginationModel.pageSize = this.pagina;
        paginationModel.sortField = this.coluna;
        paginationModel.sortDirection = this.sentido ? 'Ascending' : 'Descending';
        //paginationModel.filters['nome'] = 'si';

        let result = await this.usuarioService.getMany(paginationModel);

        this.usuarios = result.entities;
        this.totalRegistros = result.totalAmount;
    }#*/

	/**
	 * Método responsável por armazenar o id do #MODULO# a 
	 * removido.
	 *
	 * @param number id
	 */
	/*#excluir(id: number) {
 		this.idExcluir = id;
 	}#*/

 	/**
	 * Método responsável por remover um #MODULO#.
	 */
 	/*#onExcluir() {
 		this.#MODULO#Service.delete(this.idExcluir);
 		location.reload();
 	}
}#*/