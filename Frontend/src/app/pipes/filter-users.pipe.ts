import { Pipe, PipeTransform } from '@angular/core';
import {IUserDto} from "../models/UserDto";

@Pipe({
  name: 'filterUsers'
})
export class FilterUsersPipe implements PipeTransform {

  transform(products: IUserDto[], search:string): IUserDto[] {
    if (search.length===0) return products
    return products.filter(p=>p.email.toLowerCase().includes(search.toLowerCase()));
  }
}
