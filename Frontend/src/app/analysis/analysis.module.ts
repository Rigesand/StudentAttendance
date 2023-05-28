import {NgModule} from '@angular/core'
import {RouterModule, Routes} from '@angular/router'
import {ReactiveFormsModule} from '@angular/forms'
import {NgForOf} from '@angular/common'
import {AngularSvgIconModule} from 'angular-svg-icon'
import {PieComponent} from './components/pie/pie.component'
import {StudentModule} from '../student/student.module'
import {MatInputModule} from '@angular/material/input'
import {MatAutocompleteModule} from '@angular/material/autocomplete'
import {PieStudentComponent} from './components/pieStudent/pieStudent.component'
import {BarComponent} from './components/bar/bar.component'

const routes: Routes = [
  {
    path: 'analysis/pie',
    component: PieComponent,
  },
  {
    path: 'analysis/pieStudent',
    component: PieStudentComponent,
  },
  {
    path: 'analysis/bar',
    component: BarComponent,
  },
]

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    ReactiveFormsModule,
    NgForOf,
    AngularSvgIconModule.forRoot(),
    StudentModule,
    MatInputModule,
    MatAutocompleteModule,
  ],
  declarations: [PieComponent, PieStudentComponent, BarComponent],
  providers: [],
  exports: [],
})
export class AnalysisModule {}
