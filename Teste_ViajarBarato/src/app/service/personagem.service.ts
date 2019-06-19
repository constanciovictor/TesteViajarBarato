import { Starwars } from './../model/starwars.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Personagem} from "../model/personagem.model";
import { Observable } from 'rxjs';

@Injectable()
export class PersonagemService {
  constructor(private http: HttpClient) { }
  Url: string = 'https://localhost:44307/api/Personagem';

  listaPersonagens(): Observable<Starwars[]> {    
    return this.http.get<Starwars[]>(this.Url);
  }

}
