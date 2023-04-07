import {Pipe, PipeTransform} from '@angular/core'
import {IUserResponse} from '../admin/types/UserResponse'

@Pipe({
  name: 'filterUsers',
})
export class FilterUsersPipe implements PipeTransform {
  transform(products: IUserResponse[], search: string): IUserResponse[] {
    if (search.length === 0) return products
    return products.filter((p) =>
      p.email.toLowerCase().includes(search.toLowerCase())
    )
  }
}
