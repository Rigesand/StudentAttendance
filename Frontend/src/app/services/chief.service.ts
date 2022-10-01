import { Injectable } from '@angular/core';
import {IChief} from "../models/chief";

@Injectable({
  providedIn: 'root'
})
export class ChiefService {

  constructor() { }

  chiefs:IChief[]=[]


  getAll()
  {
    return this.chiefs
  }
  add(chief:IChief)
  {
    return this.chiefs.push(chief)
  }
}
