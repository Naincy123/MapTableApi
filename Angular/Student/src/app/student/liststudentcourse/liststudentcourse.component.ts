import { Component, OnInit } from '@angular/core';
import { StudentService } from '../student.service';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-liststudentcourse',
  templateUrl: './liststudentcourse.component.html',
  styleUrls: ['./liststudentcourse.component.css']
})
export class ListstudentcourseComponent implements OnInit {
  title="StudentCourses";
  studentcourses: any;
  searchText='';

  constructor(private ps : StudentService, private router: Router) { }

  ngOnInit() {
   this.getStudentCourses();
  }
  getStudentCourses(){
    
    this.ps.getStudentCourses().subscribe(data =>{
      this.studentcourses=data;
    });
  }
  idtofetch=1;
  getStudentCourseById(){
    
    this.ps.getStudentCourseById(this.idtofetch).subscribe(data => {
      this.studentcourses=data;
    });
  }
  

}
