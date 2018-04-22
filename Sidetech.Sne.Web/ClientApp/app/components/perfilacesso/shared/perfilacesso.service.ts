/**
 * Serviço de gerenciamento de perfilacessos.
 *
 * @author Márcio Casale de Souza <contato@kazale.com>
 * @since 0.0.3
 */
 
import { Injectable, Inject } from '@angular/core';

import { Perfilacesso } from './perfilacesso.model';
import { GenericHttpClientService } from '../../../shared';
import { Http } from '@angular/http';

@Injectable()
export class PerfilacessoService extends GenericHttpClientService<Perfilacesso> {

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {

        let actionUrl: string = 'Perfilacesso';
        let apiVersion: string = 'v1';

        super(http, baseUrl, apiVersion, actionUrl);
    }

	/**
	 * Retorna listagem de todos os perfilacessos.
	 *
	 * @return Perfilacesso[] perfilacessos
	 */
	listarTodos(): Perfilacesso[] {
		var perfilacessos:string = sessionStorage['perfilacessos'];
		return perfilacessos ? JSON.parse(perfilacessos) : [];
	}

	/**
	 * Cadastra um novo perfilacesso.
	 *
	 * @param Perfilacesso perfilacesso
	 */
	cadastrar(perfilacesso: Perfilacesso): void {
		var perfilacessos:Perfilacesso[] = this.listarTodos();
		perfilacessos.push(perfilacesso);
		sessionStorage['perfilacessos'] = JSON.stringify(perfilacessos);
	}

	/**
	 * Retorna os dados de um perfilacesso por id.
	 *
	 * @param number id
	 * @return Usuario perfilacesso
	 */
	buscarPorId(id: number):Perfilacesso {
		var perfilacessos:Perfilacesso[] = this.listarTodos();
		for (let perfilacesso of perfilacessos) {
			if (perfilacesso.id == id) {
				return perfilacesso;
			}
		}

		return new Perfilacesso();
	}

	/**
	 * Atualiza os dados de um perfilacesso.
	 *
	 * @param number id
	 * @param Perfilacesso perfilacesso
	 */
	atualizar(id: number, perfilacesso: Perfilacesso): void {
		var perfilacessos:Perfilacesso[] = this.listarTodos();
		for (var i=0; i<perfilacessos.length; i++) {
			if (perfilacessos[i].id == id) {
				perfilacessos[i] = perfilacesso;
			}
		}

		sessionStorage['perfilacessos'] = JSON.stringify(perfilacessos);
	}

	/**
	 * Remove um perfilacesso.
	 *
	 * @param number id
	 */
	excluir(id: number): void {
		var perfilacessos:Perfilacesso[] = this.listarTodos();
		var perfilacessosFinal:Perfilacesso[] = [];

		for (let perfilacesso of perfilacessos) {
			if (perfilacesso.id != id) {
				perfilacessosFinal.push(perfilacesso);
			}
		}

		sessionStorage['perfilacessos'] = JSON.stringify(perfilacessosFinal);
	}

	/**
	 * Retorna listagem parcial de perfilacessos.
	 *
	 * @param number pagina
	 * @param number qtdPorPagina
	 * @return Perfilacesso[] perfilacessos
	 */
	listarParcial(pagina: number, qtdPorPagina: number): Perfilacesso[] {
		let storage: string = sessionStorage['perfilacessos'];
		let perfilacessos: Perfilacesso[] = storage ? JSON.parse(storage) : [];

		let perfilacessosParcial: Perfilacesso[] = [];
		for (let i = ( pagina * qtdPorPagina ); i < (pagina * qtdPorPagina + qtdPorPagina); i++) {
			if (i >= perfilacessos.length) {
				break;
			}
			perfilacessosParcial.push(perfilacessos[i]);
		}

		return perfilacessosParcial;
	}

	/**
	 * Retorna o total de pessoas.
	 *
	 * @return number total de registros
	 */
	totalRegistros(): number {
		return this.listarTodos().length;
	}
}
