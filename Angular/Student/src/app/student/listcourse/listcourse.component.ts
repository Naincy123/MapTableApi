import { Component, OnInit } from '@angular/core';
import { StudentService } from '../student.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-listcourse',
  templateUrl: './listcourse.component.html',
  styleUrls: ['./listcourse.component.css']
})
export class ListcourseComponent implements OnInit {
  title="Courses";
  courses: any;
  searchText='';

  constructor(private ps : StudentService, private router: Router) { }

  ngOnInit() {
    this.getCourses();
  }
  getCourses(){
    this.ps.getCourses().subscribe(data =>{
      this.courses=data;
    });
  }
  idtofetch=1;
  getCourseById(){
    
    this.ps.getCourseById(this.idtofetch).subscribe(data => {
      this.courses=data;
    });
  }

}
