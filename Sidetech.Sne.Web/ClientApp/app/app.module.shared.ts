import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';

import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';

// Components
import {
    AppComponent,
    NavComponent,
    FooterComponent,
    HomeComponent,
    PerfilacessoModule,
    UsuarioModule,
    PerfilModule
} from './components';

@NgModule({
    declarations: [
        AppComponent,
        NavComponent,
        FooterComponent,

        CounterComponent,
        FetchDataComponent,
        HomeComponent
    ],
    providers: [],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        AppRoutingModule,
        PerfilacessoModule,
        UsuarioModule,
        PerfilModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
