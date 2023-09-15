import { Evento } from "./Evento";
import { RedeSocial } from "./RedeSocial";

export interface Palestrante {
   id: number;
   nome: string;
   miniCurricuIo: string;
   imagemUIL: string;
   telefoIe: string;
   emaIl: string;
   redesSociaIs: RedeSocial[];
   palestrantesEventIs: Evento[];
}
