import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import {CollapseModule} from 'ngx-bootstrap/collapse';
import {TooltipModule} from 'ngx-bootstrap/tooltip';
import {BsDropdownModule} from 'ngx-bootstrap/dropdown';
import {ModalModule} from 'ngx-bootstrap/modal';

import {ToastrModule} from 'ngx-toastr';
import{NgxSpinnerModule} from 'ngx-spinner';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContatosComponent } from './components/contatos/contatos.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { EventosComponent } from './components/eventos/eventos.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';
import { PerfilComponent } from './components/user/perfil/perfil.component';
import { NavComponent } from './shared/nav/nav.component';

import { EventoService } from './services/evento.service';
import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/compiler';
import { TituloComponent } from './shared/titulo/titulo.component';
import { EventoDetalheComponent } from './components/eventos/evento-detalhe/evento-detalhe.component';
import { EventoListaComponent } from './components/eventos/evento-lista/evento-lista.component';
import { UserComponent } from './components/user/user.component';
import { LoginComponent } from './components/user/login/login.component';
import { RegistrationComponent } from './components/user/registration/registration.component';



@NgModule({
  declarations: [
    AppComponent,
    EventosComponent,
      PalestrantesComponent,
      ContatosComponent,
      DashboardComponent,
      PerfilComponent,
      NavComponent,
      TituloComponent,
      DateTimeFormatPipe,
      EventoDetalheComponent,
      EventoListaComponent,
      UserComponent,
      LoginComponent,
      RegistrationComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
  HttpClientModule,
  CollapseModule.forRoot(),
  FormsModule,
  CollapseModule.forRoot(),
  BsDropdownModule.forRoot(),
  ModalModule.forRoot(),
  ToastrModule.forRoot({ timeOut:5000, positionClass:'toast-bottom-right', preventDuplicates:true, progressBar:true}),
  NgxSpinnerModule


  ],
  providers: [EventoService],
  bootstrap: [AppComponent]
  // schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }