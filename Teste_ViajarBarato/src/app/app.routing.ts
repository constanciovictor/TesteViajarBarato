import { RouterModule, Routes } from '@angular/router';
import {ListaPersonagensComponent} from "./listar-personagens/lista-personagens.component";

const routes: Routes = [    
  {path : '', component : ListaPersonagensComponent}
];

export const routing = RouterModule.forRoot(routes);
