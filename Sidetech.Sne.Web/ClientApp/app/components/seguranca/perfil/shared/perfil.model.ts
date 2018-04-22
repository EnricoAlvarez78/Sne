export class Perfil {
	constructor(
		public id?: number,
        public nome?: string,
        public diasExpiracaoSenha?: number,
        public qtdErrosSenha?: number,
        public Ativo?: boolean
    ) { }
}