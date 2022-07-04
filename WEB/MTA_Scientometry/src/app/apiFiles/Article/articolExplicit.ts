import { AutorDetalii } from '../Author/autorDetalii';
import { Citari } from './citari';
import { Detalii } from './detalii';
import { ModPrezentare } from './modPrezentare';
import { Publicatie } from './publicatie';

export interface ArticolExplicit {
  idarticol: number;
  idutilizator: number;
  nume: string;
  factorImpact: number;
  wos: string;
  doi: string;
  jurnal: string;
  vizitatori: number;
  autori: AutorDetalii[];
  citari: Citari[];
  detalii: Detalii;
  modPrezentare: ModPrezentare;
  publicatie: Publicatie;
}
