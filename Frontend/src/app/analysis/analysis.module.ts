import {NgModule} from '@angular/core'
import {RouterModule, Routes} from '@angular/router'
import {ReactiveFormsModule} from '@angular/forms'
import {NgForOf} from '@angular/common'
import {AngularSvgIconModule} from 'angular-svg-icon'
import {PieComponent} from './components/pie/pie.component'
import {StudentModule} from '../student/student.module'

const routes: Routes = [
  {
    path: 'analysis/pie',
    component: PieComponent,
  },
]

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    ReactiveFormsModule,
    NgForOf,
    AngularSvgIconModule.forRoot(),
    StudentModule,
  ],
  declarations: [PieComponent],
  providers: [],
  exports: [],
})
export class AnalysisModule {}
