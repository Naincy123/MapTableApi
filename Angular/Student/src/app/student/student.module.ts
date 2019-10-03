import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListstudentComponent } from './liststudent/liststudent.component';
import { Routes, RouterModule } from '@angular/router';
import { StudentService } from './student.service';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { ListcourseComponent } from './listcourse/listcourse.component'
import { StudentFilterPipe } from './studentfilter.pipe';
import { CourseFilterPipe } from './coursefilter.pipe';
import { ListstudentcourseComponent } from './liststudentcourse/liststudentcourse.component';
import { ListdetailsComponent } from './listdetails/listdetails.component';

const productroutes: Routes = [
{path:'liststudent',component: ListstudentComponent},
{path:'listcourse',component:ListcourseComponent},
{path:'liststudentcourse',component:ListstudentcourseComponent},
{path:'listdetails/:id',component:ListdetailsComponent}
];
@NgModule({
  declarations: [ListstudentComponent, ListcourseComponent,StudentFilterPipe,CourseFilterPipe, ListstudentcourseComponent, ListdetailsComponent],
  providers:[StudentService],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(productroutes),
    ReactiveFormsModule
  ]
})
export class StudentModule { }
