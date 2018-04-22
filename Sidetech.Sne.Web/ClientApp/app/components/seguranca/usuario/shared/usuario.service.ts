import { Injectable, Inject } from '@angular/core';
import { Http } from "@angular/http";

import { Usuario } from './usuario.model';
import { GenericHttpClientService } from "../../../../shared/index";

@Injectable()
export class UsuarioService extends GenericHttpClientService<Usuario> {

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {

        let actionUrl: string = 'Usuario';
        let apiVersion: string = 'v1';

        super(http, baseUrl, apiVersion, actionUrl);
    }

    

	///**
	// * Retorna listagem de todos os usuarios.
	// *
	// * @return Usuario[] usuarios
	// */
	//listarTodos(): Usuario[] {
	//	var usuarios:string = sessionStorage['usuarios'];
	//	return usuarios ? JSON.parse(usuarios) : [];
	//}

	///**
	// * Cadastra um novo usuario.
	// *
	// * @param Usuario usuario
	// */
	//cadastrar(usuario: Usuario): void {
	//	var usuarios:Usuario[] = this.listarTodos();
	//	usuarios.push(usuario);
	//	sessionStorage['usuarios'] = JSON.stringify(usuarios);
	//}

	///**
	// * Retorna os dados de um usuario por id.
	// *
	// * @param number id
	// * @return Usuario usuario
	// */
	//buscarPorId(id: number):Usuario {
	//	var usuarios:Usuario[] = this.listarTodos();
	//	for (let usuario of usuarios) {
	//		if (usuario.id == id) {
	//			return usuario;
	//		}
	//	}

	//	return new Usuario();
	//}

	///**
	// * Atualiza os dados de um usuario.
	// *
	// * @param number id
	// * @param Usuario usuario
	// */
	//atualizar(id: number, usuario: Usuario): void {
	//	var usuarios:Usuario[] = this.listarTodos();
	//	for (var i=0; i<usuarios.length; i++) {
	//		if (usuarios[i].id == id) {
	//			usuarios[i] = usuario;
	//		}
	//	}

	//	sessionStorage['usuarios'] = JSON.stringify(usuarios);
	//}

	///**
	// * Remove um usuario.
	// *
	// * @param number id
	// */
	//excluir(id: number): void {
	//	var usuarios:Usuario[] = this.listarTodos();
	//	var usuariosFinal:Usuario[] = [];

	//	for (let usuario of usuarios) {
	//		if (usuario.id != id) {
	//			usuariosFinal.push(usuario);
	//		}
	//	}

	//	sessionStorage['usuarios'] = JSON.stringify(usuariosFinal);
	//}

	///**
	// * Retorna listagem parcial de usuarios.
	// *
	// * @param number pagina
	// * @param number qtdPorPagina
	// * @return Usuario[] usuarios
	// */
	//listarParcial(pagina: number, qtdPorPagina: number): Usuario[] {
	//	let storage: string = sessionStorage['usuarios'];
	//	let usuarios: Usuario[] = storage ? JSON.parse(storage) : [];

	//	let usuariosParcial: Usuario[] = [];
	//	for (let i = ( pagina * qtdPorPagina ); i < (pagina * qtdPorPagina + qtdPorPagina); i++) {
	//		if (i >= usuarios.length) {
	//			break;
	//		}
	//		usuariosParcial.push(usuarios[i]);
	//	}

	//	return usuariosParcial;
	//}

	///**
	// * Retorna o total de pessoas.
	// *
	// * @return number total de registros
	// */
	//totalRegistros(): number {
	//	return this.listarTodos().length;
 //   }
    
}
