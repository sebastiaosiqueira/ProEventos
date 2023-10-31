import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';
import {take}from 'rxjs/operators'
import { environment } from '@environments/environment';

@Injectable( )
export class EventoService {
  baseUrl =environment.apiURL + HttpClient;

constructor(private http: HttpClient) { }

public getEventos(): Observable<Evento[]>{
  return this.http.get<Evento[]>(this.baseUrl).pipe(take(1));
}

public getEventoByTema(tema: string ): Observable<Evento[]>{
  return this.http.get<Evento[]>(`${this.baseUrl}/${tema}`).pipe(take(1));;
}

public getEventoById(id: number): Observable<Evento>{
  return this.http.get<Evento>(`${this.baseUrl}/${id}`).pipe(take(1));;
}
public post(evento:Evento): Observable<Evento>{
  return this.http.post<Evento>(this.baseUrl, evento).pipe(take(1));;
}

public put(  evento: Evento): Observable<Evento>{
  return this.http.put<Evento>(`${this.baseUrl}/${evento.id}`, evento).pipe(take(1));;
}

public deleteEvento(id: number): Observable<any>{
  return this.http.delete<string>(`${this.baseUrl}/${id}`).pipe(take(1));;
}

postUpload(eventoId: number, file: File): Observable<Evento>{
  const fileToUpload = file[0] as File;
  const formData = new FormData();
  formData.append('file', fileToUpload);
  return this.http
  .post<Evento>(`$this{this.baseURL}/upload-image/${eventoId}`, formData)
  .pipe(take(1));
}
}
