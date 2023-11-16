import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';
import {map, take}from 'rxjs/operators'
import { environment } from '@environments/environment';
import { PaginatedResult } from '@app/models/Pagination';

@Injectable( )
export class EventoService {
  baseUrl =environment.apiURL + HttpClient;
  tokenHeader = new HttpHeaders({'Authorization':);

constructor(private http: HttpClient) { }

public getEventos(page?: number, itemsPerPage?: number, term?: string): Observable<PaginatedResult<Evento[]>>{
  const paginatedResult: PaginatedResult<Evento[]> = new PaginatedResult<Evento[]>();

  let params = new HttpParams;
  if(page!= null && itemsPerPage !=null){
    params = params.append('pageNumber', page.toString());
    params = params.append('pageSize', itemsPerPage.toString());

  }
  if(term!= null && term!='')
  params = params.append('term', term);
  return this.http
              .get<Evento[]>(this.baseUrl,{observe:'response', params})
              .pipe(take(1),
              map((response)=>{
              paginatedResult.result =response.body;
              if(response.headers.has('Pagination')){
                paginatedResult.pagination = Json.parse(response.headers.get('Pagination'));

              }
              return paginatedResult;

              }));
}

public getEventoByTema(tema: string ): Observable<Evento[]>{
  return this.http.get<Evento[]>(`${this.baseUrl}/${tema}`).pipe(take(1));
}

public getEventoById(id: number): Observable<Evento>{
  return this.http.get<Evento>(`${this.baseUrl}/${id}`).pipe(take(1));
}
public post(evento:Evento): Observable<Evento>{
  return this.http.post<Evento>(this.baseUrl, evento).pipe(take(1));
}

public put(  evento: Evento): Observable<Evento>{
  return this.http.put<Evento>(`${this.baseUrl}/${evento.id}`, evento).pipe(take(1));
}

public deleteEvento(id: number): Observable<any>{
  return this.http.delete<string>(`${this.baseUrl}/${id}`).pipe(take(1));
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
