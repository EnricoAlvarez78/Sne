import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { 
// Pipes
  KzCepPipe,
  KzCpfPipe,
  KzCnpjPipe,
  KzCpfCnpjPipe,
// Directives
  KzCpfValidatorDirective,
  KzCnpjValidatorDirective, 
  KzCpfCnpjValidatorDirective,
  KzPikadayDirective,
  KzMaskDirective,
  KzMaskCurrencyDirective,
// Component
  ModalUtilComponent,
  KzPaginacaoComponent,
  PaginationComponent,
// Interfaces
  Dictionary
} from './';

@NgModule({
  imports:      [ 
  	CommonModule,
  	FormsModule 
  ],
  declarations: [ 
// Pipes
    KzCepPipe,
    KzCpfPipe,
    KzCnpjPipe,
    KzCpfCnpjPipe,
// Directives
    KzCpfValidatorDirective,
    KzCnpjValidatorDirective, 
    KzCpfCnpjValidatorDirective,
    KzMaskDirective,
    KzMaskCurrencyDirective,
    KzPikadayDirective,
// Component
    ModalUtilComponent,
    KzPaginacaoComponent,
    PaginationComponent
  ],
  exports: [ 
// Pipes
    KzCepPipe,
  	KzCpfPipe,
  	KzCnpjPipe,
    KzCpfCnpjPipe,
// Directives
  	KzCpfValidatorDirective,
  	KzCnpjValidatorDirective, 
  	KzCpfCnpjValidatorDirective,
    KzMaskDirective,
    KzMaskCurrencyDirective,
    KzPikadayDirective,
// Component
  	ModalUtilComponent,
  	KzPaginacaoComponent,
    PaginationComponent,
// Module
    CommonModule, 
    FormsModule 
  ]
})
export class SharedModule {}