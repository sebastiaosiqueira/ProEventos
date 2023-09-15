import { Evento } from "./Evento";
import { Palestrante } from "./Palestrante";

export interface RedeSocial {
      id: number;
      nome: string;
      imagemURL: string;
      eventoId?: number;
      palestranteId?: number;

}
