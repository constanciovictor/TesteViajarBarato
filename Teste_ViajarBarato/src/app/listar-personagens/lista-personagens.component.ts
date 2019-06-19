import { Starwars } from './../model/starwars.model';
import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import {PersonagemService} from "../service/personagem.service";
import {Personagem} from "../model/Personagem.model";
import {debounceTime, distinctUntilChanged, map} from 'rxjs/operators';
import {Observable} from 'rxjs';

@Component({
  selector: 'app-lista-personagens',
  templateUrl: './lista-personagens.component.html',
  styleUrls: ['./lista-personagens.component.css']
})
export class ListaPersonagensComponent implements OnInit {

  starWars: Starwars[];  

  constructor(private router: Router, private personagemService: PersonagemService) { }

  ngOnInit() {
   this.listaStarWars();
  }

  search = (text$: Observable<string>) =>
    

    text$.pipe(
      debounceTime(200),
      distinctUntilChanged(),
      map(term => term.length < 2 ? []
        : this.starWars.filter(v => v.Especie[0].name.indexOf(term.toLowerCase()) > -1).slice(0, 10))
    )

    listaStarWars() {
      this.personagemService.listaPersonagens()        
      .subscribe(data => {
        this.starWars = data;
        console.log("teste", data);
      });
    }
}
