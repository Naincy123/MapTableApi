import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListstudentComponent } from './student/liststudent/liststudent.component';
import { ListstudentcourseComponent } from './student/liststudentcourse/liststudentcourse.component';
import { ListcourseComponent } from './student/listcourse/listcourse.component';


const routes: Routes = [
  {path:'liststudent',component: ListstudentComponent},
  {path:'',redirectTo:'liststudent',pathMatch:'full'},
  {path:'listcourse',component: ListcourseComponent},
  {path:'',redirectTo:'listcourse',pathMatch:'full'},
  {path:'liststudentcourse',component: ListstudentcourseComponent},
  {path:'',redirectTo:'liststudentcourse',pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
